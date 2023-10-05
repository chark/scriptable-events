using System.IO;
using CHARK.ScriptableEvents.Editor.Icons;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace CHARK.ScriptableEvents.Tests.Editor
{
    [TestFixture]
    internal class IconUtilsTest
    {
        #region Private Fields

        private const string TestScriptContent =
            "public class TestScript : UnityEngine.MonoBehaviour {}";

        private const string AssetDirectory = "Assets/TestAssets";
        private const string AssetPath = AssetDirectory + "/TestScript.cs";
        private const string AssetMetaPath = AssetPath + ".meta";

        #endregion

        #region Public Methods

        [SetUp]
        public void CreateAssetDirectory()
        {
            Directory.CreateDirectory(AssetDirectory);
        }

        [TearDown]
        public void DeleteAssetDirectory()
        {
            Directory.Delete(AssetDirectory, true);
        }

        [Test]
        public void ShouldSetEventIconForAsset()
        {
            var asset = CreateAsset();
            var icon = new ScriptableIcon(ScriptableIconType.Event);
            Assert.True(IconUtils.TrySetIcon(asset, icon));

            var metaText = File.ReadAllText(AssetMetaPath);
            var iconGuid = GetIconGuid("IconEvent");
            var iconMetaText = GetIconMetaText(iconGuid);
            Assert.True(metaText.Contains(iconMetaText));
        }

        [Test]
        public void ShouldSetListenerIconForAsset()
        {
            var asset = CreateAsset();
            var icon = new ScriptableIcon(ScriptableIconType.Listener);
            Assert.True(IconUtils.TrySetIcon(asset, icon));

            var metaText = File.ReadAllText(AssetMetaPath);
            var iconGuid = GetIconGuid("IconListener");
            var iconMetaText = GetIconMetaText(iconGuid);
            Assert.True(metaText.Contains(iconMetaText));
        }

        #endregion

        #region Private Methods

        private static Object CreateAsset()
        {
            File.WriteAllText(AssetPath, TestScriptContent);
            AssetDatabase.Refresh();

            return AssetDatabase.LoadAssetAtPath<MonoScript>(AssetPath);
        }

        private static GUID GetIconGuid(string name)
        {
            return AssetDatabase.GUIDFromAssetPath(
                $"{ScriptableEventConstants.PackagePath}/Editor/Textures/{name}.png"
            );
        }

        private static string GetIconMetaText(GUID iconGuid)
        {
            return $"  icon: {{fileID: 2800000, guid: {iconGuid}, type: 3}}";
        }

        #endregion
    }
}
