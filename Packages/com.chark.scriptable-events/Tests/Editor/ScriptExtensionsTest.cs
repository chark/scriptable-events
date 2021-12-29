using System.IO;
using NUnit.Framework;

namespace ScriptableEvents.Editor.Tests
{
    [TestFixture]
    internal class ScriptExtensionsTest
    {
        private const string ScriptDirectory = "Assets/TestScripts";

        [TearDown]
        public void DeleteScriptDirectory()
        {
            Directory.Delete(ScriptDirectory, true);
        }

        [Test]
        public void ShouldSaveScript()
        {
            const string expectedContent = "public class Test { }";
            const string expectedDirectory = ScriptDirectory + "/TestScript";
            const string expectedPath = expectedDirectory + "/Namespace/TestScript.cs";

            expectedContent.SaveScript(
                ScriptDirectory,
                "TestScript",
                "TestScript.Namespace"
            );

            var fileContent = File.ReadAllText(expectedPath);
            Assert.AreEqual(expectedContent, fileContent);
        }
    }
}
