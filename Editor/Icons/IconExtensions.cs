using System.IO;
using UnityEditor;

namespace ScriptableEvents.Editor.Icons
{
    /// <summary>
    /// Utilities to set icons for Scriptable Events and Listeners. Inspired by:
    /// https://github.com/unity-atoms/unity-atoms/blob/master/Packages/Core/Editor/PostProcessors/EditorIconPostProcessor.cs
    /// </summary>
    internal static class IconExtensions
    {
        private const string IconFileType = "png";

        private const string IconPath = ScriptableEventConstants.PackagePath
                                        + "/Editor/Icons/Textures";

        private const string EventIconName = "EventIcon";
        private const string ListenerIconName = "ListenerIcon";

        #region Internal Methods

        /// <summary>
        /// Set event icon for the provided meta file.
        /// </summary>
        /// <returns>
        /// <c>true</c> if icon was set or <c>false</c> otherwise.
        /// </returns>
        internal static bool SetEventIcon(string metaPath)
        {
            return SetIcon(metaPath, EventIconName);
        }

        /// <summary>
        /// Set listener icon for the provided meta file.
        /// </summary>
        /// <returns>
        /// <c>true</c> if icon was set or <c>false</c> otherwise.
        /// </returns>
        internal static bool SetListenerIcon(string metaPath)
        {
            return SetIcon(metaPath, ListenerIconName);
        }

        #endregion

        #region Private Methods

        private static bool SetIcon(string metaPath, string iconName)
        {
            var iconGuid = GetIconTextureGuid(iconName).ToString();
            var iconMeta = CreateIconInfo(iconGuid);

            var lines = File.ReadAllLines(metaPath);
            for (var index = 0; index < lines.Length; index++)
            {
                var metaLine = lines[index];
                if (IsIconInfo(metaLine))
                {
                    if (IsContainsGuid(metaLine, iconGuid))
                    {
                        return false;
                    }

                    lines[index] = iconMeta;
                    WriteMeta(metaPath, lines);

                    return true;
                }
            }

            return false;
        }

        private static GUID GetIconTextureGuid(string iconName)
        {
            var iconPath = $"{IconPath}/{iconName}.{IconFileType}";
            var guid = AssetDatabase.GUIDFromAssetPath(iconPath);

            return guid;
        }

        private static bool IsIconInfo(string line)
        {
            return line.Contains("icon:");
        }

        private static bool IsContainsGuid(string line, string guid)
        {
            return line.Contains(guid);
        }

        private static string CreateIconInfo(string guid)
        {
            return $"  icon: {{fileID: 2800000, guid: {guid}, type: 3}}";
        }

        private static void WriteMeta(string metaPath, string[] metaLines)
        {
            File.WriteAllLines(metaPath, metaLines);
        }

        #endregion
    }
}
