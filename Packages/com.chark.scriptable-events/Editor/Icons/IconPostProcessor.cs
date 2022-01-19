using System.Collections.Generic;
using ScriptableEvents.Editor.States;
using Sirenix.Utilities;
using UnityEditor;
using UnityEditor.Callbacks;

namespace ScriptableEvents.Editor.Icons
{
    /// <summary>
    /// Applies icons to Scriptable Event and Listener assets.
    /// </summary>
    internal class IconPostProcessor : AssetPostprocessor
    {
        #region Private Fields

        private const string ScriptFileType = "cs";

        #endregion

        #region Unity Lifecycle

        private static void OnPostprocessAllAssets(
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetPaths
        )
        {
            AddPendingAssetPathsToIconState(importedAssets);
        }

        [DidReloadScripts]
        private static void OnScriptsReloaded()
        {
            ApplyPendingAssetPathsFromIconState();
        }

        #endregion

        #region Private Methods

        private static void AddPendingAssetPathsToIconState(IEnumerable<string> importedAssets)
        {
            var pendingAssetPaths = new List<string>();
            foreach (var importedAssetPath in importedAssets)
            {
                if (IsScriptAsset(importedAssetPath) && IsMetaFileExits(importedAssetPath))
                {
                    // These assets MIGHT be valid for icon processing. But that is unclear at this
                    // phase as the scripts might not be compiled.
                    pendingAssetPaths.Add(importedAssetPath);
                }
            }

            UpdatePendingAssetPaths(pendingAssetPaths);
        }

        private static void ApplyPendingAssetPathsFromIconState()
        {
            var iconState = ScriptableEventEditorState.IconState;
            foreach (var assetPath in iconState.PendingAssetPaths)
            {
                var monoScript = AssetDatabase.LoadAssetAtPath<MonoScript>(assetPath);
                if (monoScript == null)
                {
                    continue;
                }

                var scriptableIcon = monoScript
                    .GetClass()
                    ?.GetCustomAttribute<ScriptableIcon>(true);

                if (scriptableIcon == null)
                {
                    continue;
                }

                if (IconUtils.TrySetIcon(monoScript, scriptableIcon))
                {
                    AssetDatabase.ImportAsset(assetPath);
                }
            }

            iconState.ClearPendingAssetPaths();
            ScriptableEventEditorState.IconState = iconState;
        }

        private static bool IsScriptAsset(string assetPath)
        {
            return assetPath.EndsWith($".{ScriptFileType}");
        }

        private static bool IsMetaFileExits(string assetPath)
        {
            var metaPath = AssetDatabase.GetTextMetaFilePathFromAssetPath(assetPath);
            return !string.IsNullOrWhiteSpace(metaPath);
        }

        private static void UpdatePendingAssetPaths(IEnumerable<string> assetPaths)
        {
            var iconState = ScriptableEventEditorState.IconState;
            iconState.AddPendingAssetPaths(assetPaths);
            ScriptableEventEditorState.IconState = iconState;
        }

        #endregion
    }
}
