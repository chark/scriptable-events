using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace ScriptableEvents.Editor.Icons
{
    public class IconPostProcessor : AssetPostprocessor
    {
        #region Fields

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
            foreach (var importedAssetPath in importedAssets)
            {
                if (IsScriptAsset(importedAssetPath))
                {
                    var metaPath = $"{importedAssetPath}.meta";
                    if (File.Exists(metaPath))
                    {
                        var scriptLines = ReadAllLines(importedAssetPath);
                        if (IsMonoScript(importedAssetPath, scriptLines))
                        {
                            if (SetIcon(metaPath, scriptLines))
                            {
                                // TODO, meta file modified, but icon does not reload
                                // TODO, if reload loop then sets :(
                                AssetDatabase.ImportAsset(importedAssetPath);
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        private static bool IsScriptAsset(string assetPath)
        {
            return assetPath.EndsWith($".{ScriptFileType}");
        }

        private static bool IsMonoScript(string scriptPath, string[] scriptLines)
        {
            var scriptName = Path.GetFileNameWithoutExtension(scriptPath);
            foreach (var scriptLine in scriptLines)
            {
                if (IsMonoScript(scriptLine, scriptName))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsMonoScript(string scriptLine, string scriptName)
        {
            return scriptLine.Contains($"class {scriptName}");
        }

        private static string[] ReadAllLines(string assetPath)
        {
            return File.ReadAllLines(assetPath);
        }

        private static bool SetIcon(string metaPath, IEnumerable<string> scriptLines)
        {
            foreach (var scriptLine in scriptLines)
            {
                if (IsEvent(scriptLine))
                {
                    return IconExtensions.SetEventIcon(metaPath);
                }

                if (IsListener(scriptLine))
                {
                    return IconExtensions.SetListenerIcon(metaPath);
                }
            }

            return false;
        }

        private static bool IsEvent(string scriptLine)
        {
            return scriptLine.Contains(":BaseScriptableEvent<") ||
                   scriptLine.Contains(": BaseScriptableEvent<");
        }

        private static bool IsListener(string scriptLine)
        {
            return scriptLine.Contains(":BaseScriptableEventListener<") ||
                   scriptLine.Contains(": BaseScriptableEventListener<");
        }

        #endregion
    }
}
