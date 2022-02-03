using System.IO;
using NUnit.Framework;
using ScriptableEvents.Editor.ScriptCreation;

namespace ScriptableEvents.Tests.Editor
{
    [TestFixture]
    internal class ScriptUtilsTest
    {
        #region Private Fields

        private const string ScriptDirectory = "Assets/TestScripts";

        #endregion

        #region Public Methods

        [TearDown]
        public void DeleteScriptDirectory()
        {
            Directory.Delete(ScriptDirectory, true);
        }

        [Test]
        public void ShouldSaveScript()
        {
            const string expectedContent = "public class Test { }";
            const string expectedPath = ScriptDirectory + "/TestScript.cs";

            ScriptUtils.SaveScript(
                expectedContent,
                ScriptDirectory,
                "TestScript"
            );

            var fileContent = File.ReadAllText(expectedPath);
            Assert.AreEqual(expectedContent, fileContent);
        }

        [Test]
        public void ShouldSaveScriptWithNamespaceDirectories()
        {
            const string expectedContent = "public class Test { }";
            const string expectedPath = ScriptDirectory + "/Project/Namespace/TestScript.cs";

            ScriptUtils.SaveScript(
                expectedContent,
                ScriptDirectory,
                "TestScript",
                "Project.Namespace"
            );

            var fileContent = File.ReadAllText(expectedPath);
            Assert.AreEqual(expectedContent, fileContent);
        }

        #endregion
    }
}
