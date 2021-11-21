using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    public class CustomEventCreatorEditor : EditorWindow
    {
        #region Fields

        private MonoScript eventArgsScript;

        private string eventNamespace;
        private string eventName;
        private int eventMenuOrder;

        private string listenerNamespace;
        private string listenerName;
        private int listenerMenuOrder;

        private string editorNamespace;
        private string editorName;

        #endregion

        #region Private Properties

        private bool IsEventArgsSet => eventArgsScript != null;

        private bool IsFieldsEntered
        {
            get
            {
                var isAnyEmpty = string.IsNullOrWhiteSpace(eventNamespace)
                                 || string.IsNullOrWhiteSpace(eventName)
                                 || string.IsNullOrWhiteSpace(listenerNamespace)
                                 || string.IsNullOrWhiteSpace(listenerName)
                                 || string.IsNullOrWhiteSpace(editorNamespace)
                                 || string.IsNullOrWhiteSpace(editorName);

                return !isAnyEmpty;
            }
        }

        #endregion

        #region Unity Lifecycle

        [MenuItem("Assets/Create/Scriptable Events/Tools/Create Custom Event")]
        public static void ShowWindow()
        {
            GetWindow<CustomEventCreatorEditor>();
        }

        private void OnGUI()
        {
            DrawArgumentScriptFields();

            GUI.enabled = IsEventArgsSet;
            DrawFields();

            GUI.enabled = IsEventArgsSet && IsFieldsEntered;
            if (GUILayout.Button("Create"))
            {
                CreateEvent();
            }

            GUI.enabled = true;
        }

        #endregion

        #region Private Methods

        private void DrawArgumentScriptFields()
        {
            var newEventArgsScript = (MonoScript) EditorGUILayout.ObjectField(
                "Event Argument Script",
                eventArgsScript,
                typeof(MonoScript),
                false
            );

            if (IsNewEventArgsScript(newEventArgsScript))
            {
                if (string.IsNullOrWhiteSpace(listenerNamespace))
                {
                    listenerNamespace = "ScriptableEvents.Listeners";
                }

                if (string.IsNullOrWhiteSpace(listenerName))
                {
                    listenerName = $"{newEventArgsScript.name}ScriptableEventListener";
                }

                if (string.IsNullOrWhiteSpace(editorNamespace))
                {
                    editorNamespace = "ScriptableEvents.Editor.Events";
                }

                if (string.IsNullOrWhiteSpace(editorName))
                {
                    editorName = $"{newEventArgsScript.name}ScriptableEventEditor";
                }

                if (string.IsNullOrWhiteSpace(eventNamespace))
                {
                    eventNamespace = "ScriptableEvents.Events";
                }

                if (string.IsNullOrWhiteSpace(eventName))
                {
                    eventName = $"{newEventArgsScript.name}ScriptableEvent";
                }
            }

            eventArgsScript = newEventArgsScript;
        }

        private void DrawFields()
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Event", EditorStyles.boldLabel);
            DrawEventFields();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Listener", EditorStyles.boldLabel);
            DrawListenerFields();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Editor", EditorStyles.boldLabel);
            DrawEditorFields();
        }

        private void DrawEventFields()
        {
            eventNamespace = EditorGUILayout.TextField("Event Namespace", eventNamespace);
            eventName = EditorGUILayout.TextField("Event Name", eventName);
            eventMenuOrder = EditorGUILayout.IntField("Event Menu Order", eventMenuOrder);
            eventMenuOrder = Math.Max(0, eventMenuOrder);
        }

        private void DrawListenerFields()
        {
            listenerNamespace = EditorGUILayout.TextField("Listener Namespace", listenerNamespace);
            listenerName = EditorGUILayout.TextField("Listener Name", listenerName);
            listenerMenuOrder = EditorGUILayout.IntField("Listener Menu Order", listenerMenuOrder);
            listenerMenuOrder = Math.Max(0, listenerMenuOrder);
        }

        private void DrawEditorFields()
        {
            editorNamespace = EditorGUILayout.TextField("Editor Namespace", editorNamespace);
            editorName = EditorGUILayout.TextField("Editor Name", editorName);
        }

        private void CreateEvent()
        {
            var eventTemplate = LoadTemplate("ScriptableEventTemplate");
            var eventScript = CreateEventScript(eventTemplate);
            // todo: listeners
            // todo: editor
            // todo: create script files
            // todo: reimport assets
            // todo: improve editor UX (pre-fill fields)
            // todo: trim input
        }

        #endregion

        #region Private Script Creation Methods

        private string CreateEventScript(TextAsset template)
        {
            var eventMenuName = ObjectNames.NicifyVariableName(eventName);

            var eventArgsClass = eventArgsScript.GetClass();
            var eventArgNamespace = eventArgsClass.Namespace;
            var eventArgFullName = eventArgsClass.FullName;

            var context = new Dictionary<string, object>
            {
                ["EVENT_NAMESPACE"] = eventNamespace,
                ["EVENT_NAME"] = eventName,
                ["EVENT_FILE_NAME"] = eventName,
                ["EVENT_MENU_ORDER"] = eventMenuOrder,
                ["EVENT_MENU_NAME"] = eventMenuName,
                ["EVENT_ARG_NAMESPACE"] = eventArgNamespace,
                ["EVENT_ARG_FULL_NAME"] = eventArgFullName,
            };

            var script = CreateScript(template, context);

            return script;
        }

        #endregion

        #region Private Utility Methods

        private bool IsNewEventArgsScript(MonoScript script)
        {
            return eventArgsScript != script && script != null;
        }

        private static string CreateScript(TextAsset template, Dictionary<string, object> context)
        {
            var builder = new StringBuilder(template.text);

            foreach (var pair in context)
            {
                var key = pair.Key;
                var value = pair.Value;

                builder.Replace(key, value.ToString());
            }

            return builder.ToString();
        }

        private static TextAsset LoadTemplate(string name)
        {
            var templatePath = $"Packages/com.chark.scriptable-events/Editor/Templates/{name}.txt";
            var template = AssetDatabase.LoadAssetAtPath<TextAsset>(templatePath);

            return template;
        }

        #endregion
    }
}
