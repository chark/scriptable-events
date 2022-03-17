using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Search window for Scriptable Event assets.
    /// </summary>
    internal class ScriptableEventSearchWindowProvider : ScriptableObject, ISearchWindowProvider
    {
        #region Private Properties

        private List<BaseScriptableEvent> assets;

        private Action<BaseScriptableEvent> onClick;

        #endregion

        #region Public Methods

        /// <summary>
        /// Show a search window for Scriptable Event assets which can be used in
        /// listener with type <paramref name="listenerType"/>.
        /// </summary>
        public static void SearchListenerEvent(
            Type listenerType,
            Action<BaseScriptableEvent> onClick
        )
        {
            var screenMousePosition = GetScreenMousePosition();
            var assets = GetEventAssets(listenerType);

            // TODO: offset position so its below the button
            var searchContext = new SearchWindowContext(screenMousePosition);
            var searchProvider = CreateInstance<ScriptableEventSearchWindowProvider>();

            searchProvider.assets = assets;
            searchProvider.onClick = onClick;

            SearchWindow.Open(searchContext, searchProvider);
        }

        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            return GetSortedEntries();
        }

        public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
        {
            if (searchTreeEntry.userData is BaseScriptableEvent eventAsset)
            {
                onClick?.Invoke(eventAsset);
            }

            return true;
        }

        #endregion

        #region Private Methods

        private static Vector2 GetScreenMousePosition()
        {
            var mousePosition = Event.current.mousePosition;
            var screenMousePosition = GUIUtility.GUIToScreenPoint(mousePosition);

            return screenMousePosition;
        }

        private static List<BaseScriptableEvent> GetEventAssets(Type listenerType)
        {
            var argumentType = GetListenerArgumentType(listenerType);
            var assets = GetEventAssetsByArgumentType(argumentType);

            return assets;
        }

        private List<SearchTreeEntry> GetSortedEntries()
        {
            var entriesByPath = GetEntriesByPath();
            var sortedEntries = entriesByPath.Values
                .SelectMany(entries => entries.OrderBy(entry => entry.name))
                .ToList();

            return sortedEntries;
        }

        private SortedDictionary<string, List<SearchTreeEntry>> GetEntriesByPath()
        {
            var rootEntryContent = new GUIContent("List");
            var rootEntry = new SearchTreeGroupEntry(rootEntryContent);

            var entriesByPath = new SortedDictionary<string, List<SearchTreeEntry>>
            {
                {string.Empty, new List<SearchTreeEntry> {rootEntry}}
            };

            foreach (var asset in assets)
            {
                var assetPath = AssetDatabase.GetAssetPath(asset);
                var assetPathParts = assetPath.Split('/');

                var groupName = string.Empty;
                for (var index = 0; index < assetPathParts.Length - 1; index++)
                {
                    var assetPathPart = assetPathParts[index];
                    groupName += assetPathPart;

                    if (entriesByPath.ContainsKey(groupName) == false)
                    {
                        var groupEntry = CreateGroupEntry(assetPathPart, index + 1);
                        entriesByPath.Add(groupName, new List<SearchTreeEntry> {groupEntry});
                    }

                    groupName += "/";
                }

                if (entriesByPath.TryGetValue(groupName, out var entries) == false)
                {
                    entries = new List<SearchTreeEntry>();
                    entriesByPath.Add(groupName, entries);
                }

                var entry = CreateEntry(asset, assetPathParts);
                entries.Add(entry);
            }

            return entriesByPath;
        }

        private static SearchTreeGroupEntry CreateGroupEntry(
            string assetPathPart,
            int level
        )
        {
            var entryContent = new GUIContent(assetPathPart);
            var entry = new SearchTreeGroupEntry(entryContent)
            {
                level = level
            };

            return entry;
        }

        private static SearchTreeEntry CreateEntry(
            Object asset,
            IReadOnlyCollection<string> assetPathParts
        )
        {
            var assetType = asset.GetType();
            var assetContent = EditorGUIUtility.ObjectContent(asset, assetType);
            var assetImage = assetContent.image;

            var entryContent = new GUIContent(asset.name, assetImage);
            var entry = new SearchTreeEntry(entryContent)
            {
                userData = asset,
                level = assetPathParts.Count
            };

            return entry;
        }

        private static Type GetListenerArgumentType(Type listenerType)
        {
            var baseType = typeof(BaseScriptableEventListener<>);
            var argTypes = GetGenericArgumentTypes(listenerType, baseType);
            var listenerArgumentType = argTypes.FirstOrDefault();

            return listenerArgumentType;
        }

        private static List<BaseScriptableEvent> GetEventAssetsByArgumentType(Type type)
        {
            var matchingEventAssets = new List<BaseScriptableEvent>();
            var baseEventType = typeof(BaseScriptableEvent<>);
            var eventAssets = Resources.FindObjectsOfTypeAll<BaseScriptableEvent>();

            foreach (var eventAsset in eventAssets)
            {
                var eventType = eventAsset.GetType();
                var eventArgTypes = GetGenericArgumentTypes(eventType, baseEventType);

                if (eventArgTypes.Contains(type))
                {
                    matchingEventAssets.Add(eventAsset);
                }
            }

            return matchingEventAssets;
        }

        private static List<Type> GetGenericArgumentTypes(Type fromType, Type baseType)
        {
            while (fromType != null && fromType != typeof(object))
            {
                var current = fromType.IsGenericType
                    ? fromType.GetGenericTypeDefinition()
                    : fromType;

                if (baseType == current)
                {
                    return fromType.GetGenericArguments().ToList();
                }

                fromType = fromType.BaseType;
            }

            return new List<Type>();
        }

        #endregion
    }
}
