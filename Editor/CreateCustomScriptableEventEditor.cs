using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    internal class CustomEventCreatorEditor : EditorWindow
    {
        #region GUI Label Fields

        private static readonly GUIContent EventArgScriptLabel = new GUIContent
        {
            text = "Event Argument Script",
            tooltip = "Script which will be used as an argument for ScriptableEvent"
        };

        private static readonly GUIContent ScriptDirectoryLabel = new GUIContent
        {
            text = "Script Directory",
            tooltip = "Directory where to generate the scripts"
        };

        private static readonly GUIContent EventNamespaceLabel = new GUIContent
        {
            text = "Event Namespace",
            tooltip = "Namespace and directory used for the ScriptableEvent script"
        };

        private static readonly GUIContent EventNameLabel = new GUIContent
        {
            text = "Event Name",
            tooltip = "Name of the ScriptableEvent script"
        };

        private static readonly GUIContent EventMenuOrderLabel = new GUIContent
        {
            text = "Event Menu Order",
            tooltip = "Menu order of the ScriptableEvent asset"
        };

        private static readonly GUIContent ListenerNamespaceLabel = new GUIContent
        {
            text = "Listener Namespace",
            tooltip = "Namespace and directory used for the ScriptableEvent listener script"
        };

        private static readonly GUIContent ListenerNameLabel = new GUIContent
        {
            text = "Listener Name",
            tooltip = "Name of the ScriptableEvent listener script"
        };

        private static readonly GUIContent ListenerMenuOrderLabel = new GUIContent
        {
            text = "Listener Name",
            tooltip = "Menu order of the ScriptableEventListener asset"
        };

        private static readonly GUIContent EditorNamespaceLabel = new GUIContent
        {
            text = "Editor Namespace",
            tooltip = "Namespace and directory used for the ScriptableEvent editor script"
        };

        private static readonly GUIContent EditorNameLabel = new GUIContent
        {
            text = "Editor Name",
            tooltip = "Name of the ScriptableEvent editor script"
        };

        private static readonly GUIContent IsCreateListenerLabel = new GUIContent
        {
            text = "Is Create Listener",
            tooltip = "Should a ScriptableEvent listener script be generated?"
        };

        private static readonly GUIContent IsCreateEditorLabel = new GUIContent
        {
            text = "Is Create Editor",
            tooltip = "Should a ScriptableEvent editor script be generated?"
        };

        #endregion

        #region Regex Fields

        private static readonly Regex NamespaceRegex = new Regex("[^a-zA-Z0-9\\. -]");
        private static readonly Regex NameRegex = new Regex("[^a-zA-Z0-9 -]");

        #endregion

        #region Fields

        private MonoScript eventArgScript;
        private string scriptDirectory = "Assets/Scripts";

        private string eventArgName;
        private string eventArgNamespace;

        private string eventNamespace;
        private string eventName;
        private int eventMenuOrder;

        private bool isCreateListener;
        private string listenerNamespace;
        private string listenerName;
        private int listenerMenuOrder;

        private bool isCreateEditor;
        private string editorNamespace;
        private string editorName;

        #endregion

        #region Private Properties

        private bool IsEventArgsSet => eventArgScript != null;

        private bool IsFieldsEntered
        {
            get
            {
                if (IsAnyEmpty(scriptDirectory, eventName, eventNamespace))
                {
                    return false;
                }

                if (isCreateListener && IsAnyEmpty(listenerName, listenerNamespace))
                {
                    return false;
                }

                if (isCreateEditor && IsAnyEmpty(editorNamespace, editorName))
                {
                    return false;
                }

                return true;
            }
        }

        #endregion

        #region Unity Lifecycle

        [MenuItem(
            "Assets/Create/" + ScriptableEventConstants.MenuNamePrefix + "/Custom Scriptable Event",
            priority = ScriptableEventConstants.MenuOrderTools
        )]
        public static void ShowWindow()
        {
            var window = GetWindow<CustomEventCreatorEditor>(true, "Create Custom ScriptableEvent");
            var minSize = window.minSize;
            minSize.x = 350f;
            minSize.y = 400f;
            window.minSize = minSize;
        }

        private void OnGUI()
        {
            DrawArgScriptFields();
            DrawDirectoryFields();

            DrawFields();

            GUILayout.FlexibleSpace();

            GUI.enabled = IsEventArgsSet && IsFieldsEntered;
            if (GUILayout.Button("Create"))
            {
                CreateEvent();
            }

            GUI.enabled = true;
        }

        #endregion

        #region Private Methods

        private void DrawArgScriptFields()
        {
            EditorGUILayout.LabelField("General", EditorStyles.boldLabel);

            var oldScript = eventArgScript;
            var newScript = (MonoScript) EditorGUILayout.ObjectField(
                EventArgScriptLabel,
                eventArgScript,
                typeof(MonoScript),
                false
            );

            eventArgScript = newScript;

            if (IsNewArgScript(oldScript, newScript))
            {
                SetFieldDefaults(newScript);
                SetEventArgFields(newScript);
            }
            else if (IsChangedArgScript(oldScript, newScript))
            {
                SetFieldDefaults(oldScript, newScript);
                SetEventArgFields(newScript);
            }
        }

        private void DrawDirectoryFields()
        {
            EditorGUILayout.BeginHorizontal();

            scriptDirectory = EditorGUILayout.TextField(ScriptDirectoryLabel, scriptDirectory);
            if (GUILayout.Button("Browse"))
            {
                scriptDirectory = EditorUtility.OpenFolderPanel("Choose script directory", "", "");
            }

            EditorGUILayout.EndHorizontal();
        }

        private void DrawFields()
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Event", EditorStyles.boldLabel);
            DrawEventFields();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Listener", EditorStyles.boldLabel);

            isCreateListener = EditorGUILayout.Toggle(IsCreateListenerLabel, isCreateListener);
            GUI.enabled = isCreateListener;
            DrawListenerFields();
            GUI.enabled = true;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Editor", EditorStyles.boldLabel);

            isCreateEditor = EditorGUILayout.Toggle(IsCreateEditorLabel, isCreateEditor);
            GUI.enabled = isCreateEditor;
            DrawEditorFields();
            GUI.enabled = true;
        }

        private void DrawEventFields()
        {
            DrawValidatedTextField(EventNamespaceLabel, ref eventNamespace, NamespaceRegex);
            DrawValidatedTextField(EventNameLabel, ref eventName, NameRegex);
            DrawValidatedIntField(EventMenuOrderLabel, ref eventMenuOrder);
        }

        private void DrawListenerFields()
        {
            DrawValidatedTextField(ListenerNamespaceLabel, ref listenerNamespace, NamespaceRegex);
            DrawValidatedTextField(ListenerNameLabel, ref listenerName, NameRegex);
            DrawValidatedIntField(ListenerMenuOrderLabel, ref listenerMenuOrder);
        }

        private void DrawEditorFields()
        {
            DrawValidatedTextField(EditorNamespaceLabel, ref editorNamespace, NamespaceRegex);
            DrawValidatedTextField(EditorNameLabel, ref editorName, NameRegex);
        }

        private void CreateEvent()
        {
            CreateEventScript();

            if (isCreateListener)
            {
                CreateListenerScript();
            }

            if (isCreateEditor)
            {
                CreateEditorScript();
            }

            AssetDatabase.Refresh();
        }

        #endregion

        #region Private Script Creation Methods

        private void CreateEventScript()
        {
            var eventMenuName = ObjectNames.NicifyVariableName(eventName);
            var scriptContent = "EventTemplate".CreateScript(new Dictionary<string, object>
                {
                    ["EVENT_NAMESPACE"] = eventNamespace,
                    ["EVENT_NAME"] = eventName,
                    ["EVENT_ARG_NAME"] = eventArgName,
                    ["EVENT_MENU_FILE_NAME"] = eventName,
                    ["EVENT_MENU_ORDER"] = eventMenuOrder,
                    ["EVENT_MENU_NAME"] = eventMenuName
                },
                new[]
                {
                    eventArgNamespace,
                    eventNamespace,
                    typeof(BaseScriptableEvent<>).Namespace
                }
            );

            scriptContent.SaveScript(scriptDirectory, eventName, eventNamespace);
        }

        private void CreateListenerScript()
        {
            var listenerMenuName = ObjectNames.NicifyVariableName(listenerName);
            var scriptContent = "ListenerTemplate".CreateScript(new Dictionary<string, object>
                {
                    ["LISTENER_NAMESPACE"] = listenerNamespace,
                    ["LISTENER_NAME"] = listenerName,
                    ["EVENT_ARG_NAMESPACE"] = eventArgNamespace,
                    ["EVENT_ARG_NAME"] = eventArgName,
                    ["LISTENER_MENU_ORDER"] = listenerMenuOrder,
                    ["LISTENER_MENU_NAME"] = listenerMenuName
                },
                new[]
                {
                    eventArgNamespace,
                    typeof(BaseScriptableEvent<>).Namespace
                }
            );

            scriptContent.SaveScript(scriptDirectory, listenerName, listenerNamespace);
        }

        private void CreateEditorScript()
        {
            var scriptContent = "EditorTemplate".CreateScript(new Dictionary<string, object>
                {
                    ["EDITOR_NAMESPACE"] = editorNamespace,
                    ["EDITOR_NAME"] = editorName,
                    ["EVENT_NAME"] = eventName,
                    ["EVENT_ARG_NAME"] = eventArgName
                },
                new[]
                {
                    eventArgNamespace,
                    eventNamespace,
                    typeof(BaseScriptableEventEditor).Namespace
                }
            );

            scriptContent.SaveScript(scriptDirectory, editorName, editorNamespace);
        }

        #endregion

        #region Private Utility Methods

        private static bool IsAnyEmpty(params string[] values)
        {
            return values.Any(string.IsNullOrWhiteSpace);
        }

        private bool IsNewArgScript(MonoScript oldScript, MonoScript newScript)
        {
            return oldScript == null && newScript != null;
        }

        private bool IsChangedArgScript(MonoScript oldScript, MonoScript newScript)
        {
            return oldScript != null && newScript != null && oldScript != newScript;
        }

        private void SetFieldDefaults(MonoScript newScript)
        {
            var scriptName = newScript.name;

            if (string.IsNullOrWhiteSpace(listenerNamespace))
            {
                listenerNamespace = "ScriptableEvents.Listeners";
            }

            if (string.IsNullOrWhiteSpace(listenerName))
            {
                listenerName = $"{scriptName}ScriptableEventListener";
            }

            if (string.IsNullOrWhiteSpace(editorNamespace))
            {
                editorNamespace = "ScriptableEvents.Editor.Events";
            }

            if (string.IsNullOrWhiteSpace(editorName))
            {
                editorName = $"{scriptName}ScriptableEventEditor";
            }

            if (string.IsNullOrWhiteSpace(eventNamespace))
            {
                eventNamespace = "ScriptableEvents.Events";
            }

            if (string.IsNullOrWhiteSpace(eventName))
            {
                eventName = $"{scriptName}ScriptableEvent";
            }
        }

        private void SetFieldDefaults(MonoScript oldScript, MonoScript newScript)
        {
            var oldScriptName = oldScript.name;
            var newScriptName = newScript.name;

            if (listenerName == $"{oldScriptName}ScriptableEventListener")
            {
                listenerName = $"{newScriptName}ScriptableEventListener";
            }

            if (editorName == $"{oldScriptName}ScriptableEventEditor")
            {
                editorName = $"{newScriptName}ScriptableEventEditor";
            }

            if (eventName == $"{oldScriptName}ScriptableEvent")
            {
                eventName = $"{newScriptName}ScriptableEvent";
            }
        }

        private void SetEventArgFields(MonoScript script)
        {
            var eventArgClass = script.GetClass();
            eventArgName = eventArgClass.Name;
            eventArgNamespace = eventArgClass.Namespace;
        }

        private static void DrawValidatedTextField(GUIContent label, ref string value, Regex regex)
        {
            value = EditorGUILayout.TextField(label, value);

            if (value != null)
            {
                value = regex.Replace(value, string.Empty);
            }
        }

        private static void DrawValidatedIntField(GUIContent label, ref int value)
        {
            value = EditorGUILayout.IntField(label, value);
            value = Math.Max(0, value);
        }

        #endregion
    }
}
