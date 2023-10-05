using CHARK.ScriptableEvents.Editor.ScriptCreation;
using NUnit.Framework;

namespace CHARK.ScriptableEvents.Tests.Editor
{
    [TestFixture]
    internal class ScriptBuilderTest
    {
        [Test]
        public void ShouldCreateScriptFromEventTemplate()
        {
            var expectedContent = @"
                using CHARK.ScriptableEvents;
                using TestEventArg.Namespace;
                using UnityEngine;

                namespace TestEvent.Namespace
                {
                    [CreateAssetMenu(
                        fileName = ""TestEventMenuFileName"",
                        menuName = ScriptableEventConstants.MenuNameCustom + ""/TestEventMenuName"",
                        order = ScriptableEventConstants.MenuOrderCustom + 123
                    )]
                    public class TestEventName : ScriptableEvent<TestEventArgName>
                    {
                    }
                }
                "
                .TrimStart()
                .Replace("                ", "");

            var scriptContent = new ScriptBuilder("EventTemplate")
                .AddSubstitute("EVENT_NAMESPACE", "TestEvent.Namespace")
                .AddSubstitute("EVENT_NAME", "TestEventName")
                .AddSubstitute("EVENT_ARG_NAME", "TestEventArgName")
                .AddSubstitute("EVENT_MENU_FILE_NAME", "TestEventMenuFileName")
                .AddSubstitute("EVENT_MENU_ORDER", 123)
                .AddSubstitute("EVENT_MENU_NAME", "TestEventMenuName")

                // Already exists in namespace, should be skipped.
                .AddImport("TestEventArg.Namespace")
                .AddImport("TestEvent.Namespace")
                .AddImport("CHARK.ScriptableEvents")
                .Build();

            Assert.AreEqual(NormaliseCRs(expectedContent), NormaliseCRs(scriptContent));
        }

        [Test]
        public void ShouldCreateScriptFromListenerTemplate()
        {
            var expectedContent = @"
                using CHARK.ScriptableEvents;
                using TestEventArg.Namespace;
                using UnityEngine;

                namespace TestListener.Namespace
                {
                    [AddComponentMenu(
                        ScriptableEventConstants.MenuNameCustom + ""/TestListenerMenuName"",
                        ScriptableEventConstants.MenuOrderCustom + 123
                    )]
                    public class TestListenerName : ScriptableEventListener<TestEventArgName>
                    {
                    }
                }
                "
                .TrimStart()
                .Replace("                ", "");

            var scriptContent = new ScriptBuilder("ListenerTemplate")
                .AddSubstitute("LISTENER_NAMESPACE", "TestListener.Namespace")
                .AddSubstitute("LISTENER_NAME", "TestListenerName")
                .AddSubstitute("EVENT_ARG_NAME", "TestEventArgName")
                .AddSubstitute("LISTENER_MENU_ORDER", 123)
                .AddSubstitute("LISTENER_MENU_NAME", "TestListenerMenuName")

                // Already exists in namespace, should be skipped.
                .AddImport("TestListener.Namespace")
                .AddImport("TestEventArg.Namespace")
                .AddImport("CHARK.ScriptableEvents")
                .Build();

            Assert.AreEqual(NormaliseCRs(expectedContent), NormaliseCRs(scriptContent));
        }

        [Test]
        public void ShouldCreateScriptFromEditorTemplate()
        {
            var expectedContent = @"
                using CHARK.ScriptableEvents.Editor;
                using TestEvent.Namespace;
                using TestEventArg.Namespace;
                using UnityEditor;

                namespace TestEditor.Namespace
                {
                    [CustomEditor(typeof(TestEvent))]
                    public class TestEditor : ScriptableEventEditor<TestEventArg>
                    {
                        protected override TestEventArg DrawArgField(TestEventArg value)
                        {
                            // Use EditorGUILayout.TextField, etc., to draw inputs next to Raise button on the
                            // TestEvent asset.
                            return value;
                        }
                    }
                }
                "
                .TrimStart()
                .Replace("                ", "");

            var scriptContent = new ScriptBuilder("EditorTemplate")
                .AddSubstitute("EDITOR_NAMESPACE", "TestEditor.Namespace")
                .AddSubstitute("EDITOR_NAME", "TestEditor")
                .AddSubstitute("EVENT_NAME", "TestEvent")
                .AddSubstitute("EVENT_ARG_NAME", "TestEventArg")

                // Already exists in namespace, should be skipped.
                .AddImport("TestEditor.Namespace")
                .AddImport("TestEventArg.Namespace")
                .AddImport("TestEvent.Namespace")
                .AddImport("CHARK.ScriptableEvents.Editor")
                .Build();

            Assert.AreEqual(NormaliseCRs(expectedContent), NormaliseCRs(scriptContent));
        }

        /// <summary>
        /// Helper routine to make sure CRLF values (and CR values) are all treated as LF
        /// This is relevant as this file may be in either windows or mac/unix format, as may the template.
        /// </summary>
        private static string NormaliseCRs(string source)
        {
            return source.Replace("\r\n", "\n").Replace("\r", "\n");
        }

    }
}
