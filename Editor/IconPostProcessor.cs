using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    public class IconPostProcessor : AssetPostprocessor
    {
        #region Fields

        private const string ScriptFileType = "cs";
        private const string IconFileType = "png";
        private const string IconPath = ScriptableEventConstants.PackagePath + "/Editor/Icons";

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
                if (IsScript(importedAssetPath))
                {
                    // TODO: requires re-import of script assets
                    var monoScript = GetMonoScript(importedAssetPath);
                    var iconAttribute = monoScript.GetIconAttribute();
                    if (iconAttribute == null)
                    {
                        return;
                    }

                    SetIcon(monoScript, iconAttribute);
                }
            }
        }

        #endregion

        #region Private Methods

        private static bool IsScript(string assetPath)
        {
            return assetPath.EndsWith($".{ScriptFileType}");
        }

        private static MonoScript GetMonoScript(string assetPath)
        {
            return AssetDatabase.LoadAssetAtPath<MonoScript>(assetPath);
        }

        private static void SetIcon(MonoScript monoScript, ScriptableEventIcon iconAttribute)
        {
            var iconName = iconAttribute.IconName;
            var icon = GetIconTexture(iconName);

            monoScript.SetIcon(icon);
        }

        private static Texture2D GetIconTexture(string iconName)
        {
            var iconPath = $"{IconPath}/{iconName}.{IconFileType}";
            var texture = AssetDatabase.LoadAssetAtPath<Texture2D>(iconPath);

            return texture;
        }

        #endregion
    }
}
