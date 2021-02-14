using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Tools
{
    public class ScriptableEventCreator : EditorWindow
    {
        #region Fields

        private const string TemplatePath =
            "Packages/com.chark.scriptable-events/Editor/Tools/Templates";

        private readonly Field dataTypeField =
            new Field("Data type", "Type name of event data", true);

        private readonly Field namespaceField =
            new Field("Namespace", "Namespace of new event", false);

        private readonly Field directoryField =
            new Field("Directory", "Directory of new event", true);

        private readonly Field editorDirectoryField =
            new Field("Editor directory", "Editor directory of new event", true);

        private readonly List<Field> fields;

        #endregion

        #region Unity Lifecylce

        [MenuItem("Scriptable Events/Create Custom Scriptable Event")]
        private static void Init()
        {
            var window = GetWindow<ScriptableEventCreator>("Create Scriptable event");
            window.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();
            DrawFields(out var missingValues);

            if (missingValues)
            {
                DrawRequiredFieldsHelpBox();
            }

            GUI.enabled = !missingValues;
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Create"))
            {
                CreateEvent();
            }
        }

        #endregion

        #region Methods

        public ScriptableEventCreator()
        {
            fields = new List<Field>
            {
                dataTypeField,
                namespaceField,
                directoryField,
                editorDirectoryField
            };
        }

        private void DrawFields(out bool missingValues)
        {
            missingValues = false;
            foreach (var field in fields)
            {
                if (string.IsNullOrWhiteSpace(field.Value) && field.Required)
                {
                    missingValues = true;
                }

                field.Value = EditorGUILayout.TextField(field.Label, field.Value);
            }
        }

        private void DrawRequiredFieldsHelpBox()
        {
            EditorGUILayout.HelpBox(
                $"Missing values: {GetMissingValuesText()}",
                MessageType.Warning
            );
        }

        private string GetMissingValuesText()
        {
            var labels = fields
                .Where(field => field.Required && string.IsNullOrWhiteSpace(field.Value))
                .Select(field => field.Label.text);

            return string.Join(", ", labels);
        }

        // todo finish templating
        private void CreateEvent()
        {
            var eventTemplate = FindTemplate("EventTemplate");
            Debug.Log(eventTemplate);

            var unityEventTemplate = FindTemplate("UnityEventTemplate");
            Debug.Log(unityEventTemplate);

            var listenerTemplate = FindTemplate("ListenerTemplate");
            Debug.Log(listenerTemplate);

            var editorTemplate = FindTemplate("EditorTemplate");
            Debug.Log(editorTemplate);
        }

        private static string FindTemplate(string name)
        {
            var asset = AssetDatabase.LoadAssetAtPath<TextAsset>($"{TemplatePath}/{name}.txt");
            return asset.text;
        }

        #endregion
    }
}
