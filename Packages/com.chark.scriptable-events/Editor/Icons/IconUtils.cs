using System;
using System.IO;
using UnityEditor;
using Object = UnityEngine.Object;

namespace ScriptableEvents.Editor.Icons
{
    /// <summary>
    /// Utilities to set icons for Scriptable Events and Listeners. Inspired by:
    /// https://github.com/unity-atoms/unity-atoms/blob/master/Packages/Core/Editor/PostProcessors/EditorIconPostProcessor.cs
    /// </summary>
    internal static class IconUtils
    {
        #region Private Fields

        private const string IconPath = ScriptableEventConstants.PackagePath + "/Editor/Textures";
        private const string IconPathEvent = IconPath + "/IconEvent.png";
        private const string IconPathListener = IconPath + "/IconListener.png";

        #endregion

        #region Internal Methods

        /// <summary>
        /// Attempt to set an icon on the given object.
        /// </summary>
        internal static bool TrySetIcon(Object obj, ScriptableIcon icon)
        {
            var iconGuid = GetIconGuid(icon);
            if (iconGuid.Empty())
            {
                return false;
            }

            var metaFilePath = GetMetaFilePath(obj);
            if (string.IsNullOrWhiteSpace(metaFilePath))
            {
                return false;
            }

            var metaFileLines = File.ReadAllLines(metaFilePath);
            var iconGuidString = iconGuid.ToString();
            var iconMeta = GetIconMetaString(iconGuidString);

            var isContainsMonoImporter = false;
            for (var index = 0; index < metaFileLines.Length; index++)
            {
                var metaFileLine = metaFileLines[index];
                if (!isContainsMonoImporter && metaFileLine.Contains("MonoImporter:"))
                {
                    isContainsMonoImporter = true;
                }

                if (IsIconMetaString(metaFileLine))
                {
                    if (metaFileLine.Contains(iconGuidString))
                    {
                        // Icon already set.
                        return false;
                    }

                    metaFileLines[index] = iconMeta;
                    File.WriteAllLines(metaFilePath, metaFileLines);

                    // Icon successfully set.
                    return true;
                }
            }

            // "icon:" line did not exist in the .meta file.

            if (isContainsMonoImporter)
            {
                // Unsupported .meta file format.
                return false;
            }

            var customMonoImporter = GetMonoImporterString(iconGuidString);
            File.AppendAllText(metaFilePath, Environment.NewLine + customMonoImporter);

            // Meta file successfully updated with the new icon.
            return true;
        }

        #endregion

        #region Private Methods

        private static string GetMetaFilePath(Object obj)
        {
            var assetPath = AssetDatabase.GetAssetPath(obj);
            var metaPath = AssetDatabase.GetTextMetaFilePathFromAssetPath(assetPath);

            return metaPath;
        }

        private static GUID GetIconGuid(ScriptableIcon icon)
        {
            var iconType = icon.Type;
            var iconPath = iconType switch
            {
                ScriptableIconType.Event => IconPathEvent,
                ScriptableIconType.Listener => IconPathListener,
                _ => string.Empty
            };

            if (iconPath == string.Empty)
            {
                return new GUID();
            }

            return AssetDatabase.GUIDFromAssetPath(iconPath);
        }

        private static string GetIconMetaString(string iconGuid)
        {
            return $"  icon: {{fileID: 2800000, guid: {iconGuid}, type: 3}}";
        }

        private static bool IsIconMetaString(string str)
        {
            return str.Contains("icon:");
        }

        private static string GetMonoImporterString(string iconGuid)
        {
            return $@"MonoImporter:
  externalObjects: {{}}
  serializedVersion: 2
  defaultReferences: []
  executionOrder: 0
  icon: {{fileID: 2800000, guid: {iconGuid}, type: 3}}
  userData:
  assetBundleName:
  assetBundleVariant:
";
        }

        #endregion
    }
}
