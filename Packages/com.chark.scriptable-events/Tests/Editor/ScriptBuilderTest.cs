using NUnit.Framework;

namespace ScriptableEvents.Editor.Tests
{
    [TestFixture]
    internal class ScriptBuilderTest
    {
        [Test]
        public void ShouldCreateScriptFromEventTemplate()
        {
            var expectedContent = @"
                using ScriptableEvents;
                using TestEventArg.Namespace;
                using UnityEngine;

                namespace TestEvent.Namespace
                {
                    [CreateAssetMenu(
                        fileName = ""TestEventMenuFileName"",
                        menuName = ScriptableEventConstants.MenuNameCustom + ""/TestEventMenuName"",
                        order = ScriptableEventConstants.MenuOrderCustom + 123
                    )]
                    public class TestEventName : BaseScriptableEvent<TestEventArgName>
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
                .AddImport("ScriptableEvents")
                .Build();

            Assert.AreEqual(expectedContent, scriptContent);
        }

        [Test]
        public void ShouldCreateScriptFromListenerTemplate()
        {
            var expectedContent = @"
                using ScriptableEvents;
                using TestEventArg.Namespace;
                using UnityEngine;

                namespace TestListener.Namespace
                {
                    [AddComponentMenu(
                        ScriptableEventConstants.MenuNameCustom + ""/TestListenerMenuName"",
                        ScriptableEventConstants.MenuOrderCustom + 123
                    )]
                    public class TestListenerName : BaseScriptableEventListener<TestEventArgName>
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
                .AddImport("ScriptableEvents")
                .Build();

            Assert.AreEqual(expectedContent, scriptContent);
        }

        [Test]
        public void ShouldCreateScriptFromEditorTemplate()
        {
            var expectedContent = @"
                using ScriptableEvents.Editor;
                using TestEvent.Namespace;
                using TestEventArg.Namespace;
                using UnityEditor;

                namespace TestEditor.Namespace
                {
                    [CustomEditor(typeof(TestEvent))]
                    public class TestEditor : BaseScriptableEventEditor<TestEventArg>
                    {
                        protected override TestEventArg DrawArgField(TestEventArg value)
                        {
                            // Use EditorGUILayout.TextField, etc., to draw inputs next to Raise button on your
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
                .AddImport("ScriptableEvents.Editor")
                .Build();

            Assert.AreEqual(expectedContent, scriptContent);
        }
    }
}
