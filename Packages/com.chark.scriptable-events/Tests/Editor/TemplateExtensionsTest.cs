using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace ScriptableEvents.Editor.Tests
{
    [TestFixture]
    internal class TemplateExtensionsTest
    {
        [Test]
        public void ShouldCreateScriptFromEventTemplate()
        {
            const string expectedDirectory = "Assets/Scripts/TestEvent";
            const string expectedPath = expectedDirectory + "/Namespace/TestEvent.cs";

            var expectedContent = @"
                using ScriptableEvents;
                using TestEventArg.Namespace;
                using UnityEngine;

                namespace TestEvent.Namespace
                {
                    [CreateAssetMenu(
                        fileName = ""TestEventMenuFileName"",
                        menuName = ScriptableEventConstants.MenuNamePrefix + ""/TestEventMenuName"",
                        order = ScriptableEventConstants.MenuOrderCustomEvent + 123
                    )]
                    public class TestEventName : BaseScriptableEvent<TestEventArgName>
                    {
                    }
                }
                "
                .TrimStart()
                .Replace("                ", "");

            var scriptContent = "EventTemplate".CreateScript(
                new Dictionary<string, object>
                {
                    ["EVENT_NAMESPACE"] = "TestEvent.Namespace",
                    ["EVENT_NAME"] = "TestEventName",
                    ["EVENT_ARG_NAME"] = "TestEventArgName",
                    ["EVENT_MENU_FILE_NAME"] = "TestEventMenuFileName",
                    ["EVENT_MENU_ORDER"] = 123,
                    ["EVENT_MENU_NAME"] = "TestEventMenuName"
                },
                new[]
                {
                    // Already exists in namespace, should be skipped.
                    "TestEventArg.Namespace",
                    "TestEvent.Namespace",
                    "ScriptableEvents"
                }
            );

            scriptContent.SaveScript(
                "Assets/Scripts",
                "TestEvent",
                "TestEvent.Namespace"
            );

            var fileContent = File.ReadAllText(expectedPath);
            Directory.Delete(expectedDirectory, true);

            Assert.AreEqual(expectedContent, fileContent);
        }

        [Test]
        public void ShouldCreateScriptFromListenerTemplate()
        {
            const string expectedDirectory = "Assets/Scripts/TestListener";
            const string expectedPath = expectedDirectory + "/Namespace/TestListener.cs";

            var expectedContent = @"
                using ScriptableEvents;
                using TestEventArg.Namespace;
                using UnityEngine;

                namespace TestListener.Namespace
                {
                    [AddComponentMenu(
                        ScriptableEventConstants.MenuNamePrefix + ""/TestListenerMenuName"",
                        ScriptableEventConstants.MenuOrderCustomEvent + 123
                    )]
                    public class TestListenerName : BaseScriptableEventListener<TestEventArgName>
                    {
                    }
                }
                "
                .TrimStart()
                .Replace("                ", "");

            var scriptContent = "ListenerTemplate".CreateScript(
                new Dictionary<string, object>
                {
                    ["LISTENER_NAMESPACE"] = "TestListener.Namespace",
                    ["LISTENER_NAME"] = "TestListenerName",
                    ["EVENT_ARG_NAME"] = "TestEventArgName",
                    ["LISTENER_MENU_ORDER"] = 123,
                    ["LISTENER_MENU_NAME"] = "TestListenerMenuName"
                },
                new[]
                {
                    // Already exists in namespace, should be skipped.
                    "TestListener.Namespace",
                    "TestEventArg.Namespace",
                    "ScriptableEvents"
                }
            );

            scriptContent.SaveScript(
                "Assets/Scripts",
                "TestListener",
                "TestListener.Namespace"
            );

            var fileContent = File.ReadAllText(expectedPath);
            Directory.Delete(expectedDirectory, true);

            Assert.AreEqual(expectedContent, fileContent);
        }

        [Test]
        public void ShouldCreateScriptFromEditorTemplate()
        {
            const string expectedDirectory = "Assets/Scripts/TestEditor";
            const string expectedPath = expectedDirectory + "/Namespace/TestEditor.cs";

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

            var scriptContent = "EditorTemplate".CreateScript(
                new Dictionary<string, object>
                {
                    ["EDITOR_NAMESPACE"] = "TestEditor.Namespace",
                    ["EDITOR_NAME"] = "TestEditor",
                    ["EVENT_NAME"] = "TestEvent",
                    ["EVENT_ARG_NAME"] = "TestEventArg"
                },
                new[]
                {
                    // Already exists in namespace, should be skipped.
                    "TestEditor.Namespace",
                    "TestEventArg.Namespace",
                    "TestEvent.Namespace",
                    "ScriptableEvents.Editor"
                }
            );

            scriptContent.SaveScript(
                "Assets/Scripts",
                "TestEditor",
                "TestEditor.Namespace"
            );

            var fileContent = File.ReadAllText(expectedPath);
            Directory.Delete(expectedDirectory, true);

            Assert.AreEqual(expectedContent, fileContent);
        }
    }
}
