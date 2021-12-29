using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Editor window for creating custom scriptable event scripts.
    /// </summary>
    internal class EventCreatorEditorWindow : EditorWindow
    {
        #region GUI Label Fields

        private static readonly GUIContent EventArgScriptLabel = new GUIContent
        {
            text = "Event Argument Script",
            tooltip = "Script which will be used as an argument for the custom event"
        };

        private static readonly GUIContent ScriptDirectoryLabel = new GUIContent
        {
            text = "Output Directory",
            tooltip = "Directory where to generate the scripts"
        };

        private static readonly GUIContent IsUseMonoScriptLabel = new GUIContent
        {
            text = "Is Use Mono Script",
            tooltip = "Should a MonoScript be used for gathering event argument type information?"
        };

        private static readonly GUIContent IsCreateListenerLabel = new GUIContent
        {
            text = "Is Create Listener",
            tooltip = "Should a custom event listener script be generated?"
        };

        private static readonly GUIContent IsCreateEditorLabel = new GUIContent
        {
            text = "Is Create Editor",
            tooltip = "Should a custom event editor script be generated?"
        };

        #endregion

        #region Regex Fields

        // Numbers, letters & dots - namespaces are restrictive, but not as restrictive as type
        // names.
        private static readonly Regex NamespaceRegex = new Regex("[^a-zA-Z0-9\\. -]");

        // Numbers & letters only - type names are rather restrictive.
        private static readonly Regex TypeNameRegex = new Regex("[^a-zA-Z0-9-]");

        // Numbers, letters & spaces can be used in menu names.
        private static readonly Regex MenuNameRegex = new Regex("[^a-zA-Z0-9 -]");

        #endregion

        #region Event Arg Fields

        private bool isUseMonoScript = true;

        private MonoScript eventArgScript;

        private readonly ValidatedStringField eventArgNamespace = new ValidatedStringField(
            "Event Argument Namespace",
            "Namespace of the event argument type",
            NamespaceRegex
        );

        private readonly ValidatedStringField eventArgName = new ValidatedStringField(
            "Event Argument Name",
            "Name of the event argument type",
            TypeNameRegex
        );

        #endregion

        #region Event Fields

        private readonly ValidatedStringField eventNamespace = new ValidatedStringField(
            "Event Namespace",
            "Namespace used for the custom event script. Note that this namespace will also be " +
            "used to generate directories for the event asset script (e.g., namespace " +
            "MyScriptableEvents.Events will result in MyScriptableEvents/Events directory)",
            NamespaceRegex
        );

        private readonly ValidatedStringField eventName = new ValidatedStringField(
            "Event Name",
            "Name of the custom event script",
            TypeNameRegex
        );

        private readonly ValidatedStringField eventMenuName = new ValidatedStringField(
            "Event Menu Name",
            "Menu name of the custom event asset",
            MenuNameRegex
        );

        private readonly ValidatedIntField eventMenuOrder = new ValidatedIntField(
            "Event Menu Order",
            "Menu order of the custom event asset",
            0
        );

        #endregion

        #region Listener Fields

        private bool isCreateListener = true;

        private readonly ValidatedStringField listenerNamespace = new ValidatedStringField(
            "Listener Namespace",
            "Namespace used for the custom event listener script. Note that this namespace will " +
            "also be used to generate directories for the event listener script (e.g., namespace " +
            "MyScriptableEvents.Listeners will result in MyScriptableEvents/Listeners " +
            "directory)",
            NamespaceRegex
        );

        private readonly ValidatedStringField listenerName = new ValidatedStringField(
            "Listener Name",
            "Name of the custom event listener script",
            TypeNameRegex
        );

        private readonly ValidatedStringField listenerMenuName = new ValidatedStringField(
            "Listener Menu Name",
            "Menu name of the custom event listener component",
            MenuNameRegex
        );

        private readonly ValidatedIntField listenerMenuOrder = new ValidatedIntField(
            "Listener Menu Order",
            "Menu order of the custom event listener component",
            0
        );

        #endregion

        #region Editor Fields

        private bool isCreateEditor;

        private readonly ValidatedStringField editorNamespace = new ValidatedStringField(
            "Editor Namespace",
            "Namespace used for the custom event editor script. Note that this namespace will " +
            "also be used to generate directories for the event editor script (e.g., " +
            "namespace MyScriptableEvents.Editor will result in MyScriptableEvents/Editor " +
            "directory)",
            NamespaceRegex
        );

        private readonly ValidatedStringField editorName = new ValidatedStringField(
            "Editor Name",
            "Name of the custom event editor script",
            TypeNameRegex
        );

        #endregion

        #region Other Fields

        private string scriptDirectory = "Assets/Scripts";

        #endregion

        #region Private Properties

        private bool IsRequiredFieldsSet
        {
            get
            {
                // Event argument type info is always required, regardless if mono script is used
                // or not.
                if (isUseMonoScript && eventArgScript == null)
                {
                    return false;
                }

                if (!isUseMonoScript && IsAnyEventArgFieldsBlank)
                {
                    return false;
                }

                // Event must always have all fields entered as its the base.
                if (IsAnyEventFieldsBlank)
                {
                    return false;
                }

                // Listener is optional, as event might be used via code.
                if (isCreateListener && IsAnyListenerFieldsBlank)
                {
                    return false;
                }

                // Editor is always optional.
                if (isCreateEditor && IsAnyEditorFieldsBlanks)
                {
                    return false;
                }

                if (IsAnyBlank(scriptDirectory))
                {
                    return false;
                }

                return true;
            }
        }

        private bool IsAnyEventArgFieldsBlank => IsAnyBlank(eventArgNamespace, eventArgName);

        private bool IsAnyEventFieldsBlank => IsAnyBlank(eventNamespace, eventName, eventMenuName);

        private bool IsAnyListenerFieldsBlank =>
            IsAnyBlank(listenerNamespace, listenerName, listenerMenuName);

        private bool IsAnyEditorFieldsBlanks => IsAnyBlank(editorNamespace, editorName);

        #endregion

        #region Unity Lifecycle

        [MenuItem(
            "Assets/Create/" + ScriptableEventConstants.MenuNameBase + "/Custom Scriptable Event",
            priority = ScriptableEventConstants.MenuOrderTools
        )]
        public static void ShowWindow()
        {
            var window = GetWindow<EventCreatorEditorWindow>(
                true,
                "Create Custom Scriptable Event"
            );

            var minSize = window.minSize;
            minSize.x = 350f;
            minSize.y = 500f;
            window.minSize = minSize;
        }

        private void OnGUI()
        {
            DrawFields();

            GUILayout.FlexibleSpace();
            DrawDirectoryFields();

            GUI.enabled = IsRequiredFieldsSet;
            if (GUILayout.Button("Create"))
            {
                CreateEvent();
            }

            GUI.enabled = true;
        }

        #endregion

        #region Private Drawing Methods

        private void DrawFields()
        {
            EditorGUILayout.LabelField("Event Argument Script", EditorStyles.boldLabel);
            isUseMonoScript = EditorGUILayout.Toggle(IsUseMonoScriptLabel, isUseMonoScript);
            if (isUseMonoScript)
            {
                DrawArgMonoScriptFields();
            }
            else
            {
                DrawArgScriptFields();
            }

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Event Asset Script", EditorStyles.boldLabel);
            DrawEventFields();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Listener Component Script", EditorStyles.boldLabel);

            isCreateListener = EditorGUILayout.Toggle(IsCreateListenerLabel, isCreateListener);
            GUI.enabled = isCreateListener;
            DrawListenerFields();
            GUI.enabled = true;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Editor Script", EditorStyles.boldLabel);

            isCreateEditor = EditorGUILayout.Toggle(IsCreateEditorLabel, isCreateEditor);
            GUI.enabled = isCreateEditor;
            DrawEditorFields();
            GUI.enabled = true;
        }

        private void DrawArgMonoScriptFields()
        {
            var oldScript = eventArgScript;
            var newScript = (MonoScript) EditorGUILayout.ObjectField(
                EventArgScriptLabel,
                eventArgScript,
                typeof(MonoScript),
                false
            );

            eventArgScript = newScript;

            // New script is removed, cannot proceed as we can't get Name or Namespace of the args
            // script.
            if (newScript == null)
            {
                return;
            }

            // At the moment, args script type name must match the file name, otherwise Unity can't
            // find the type info inside the file.
            var newScriptType = newScript.GetClass();
            if (newScriptType == null)
            {
                EditorGUILayout.HelpBox(
                    $"Provided script is invalid, make sure that a class exists in " +
                    $"{newScript.name} file with a matching name. Alternatively, uncheck " +
                    $"{ObjectNames.NicifyVariableName(nameof(isUseMonoScript))} and enter " +
                    $"details manually",
                    MessageType.Error
                );

                return;
            }

            if (oldScript == newScript)
            {
                return;
            }

            var newScriptName = newScriptType.Name;
            var newScriptNamespace = newScriptType.Namespace;

            SetFieldDefaults(newScriptName);
            SetEventArgFields(newScriptName, newScriptNamespace);
        }

        private void DrawArgScriptFields()
        {
            eventArgNamespace.Draw();

            string oldEventArgName = eventArgName;
            eventArgName.Draw();
            string newEventArgName = eventArgName;

            if (oldEventArgName != newEventArgName)
            {
                SetFieldDefaults(eventArgName);
            }
        }

        private void DrawEventFields()
        {
            eventNamespace.Draw();
            eventName.Draw();

            EditorGUILayout.Space();

            eventMenuName.Draw();
            eventMenuOrder.Draw();
        }

        private void DrawListenerFields()
        {
            listenerNamespace.Draw();
            listenerName.Draw();

            EditorGUILayout.Space();

            listenerMenuName.Draw();
            listenerMenuOrder.Draw();
        }

        private void DrawEditorFields()
        {
            editorNamespace.Draw();
            editorName.Draw();
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

        #endregion

        #region Private Script Creation Methods

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

        private void CreateEventScript()
        {
            var baseNamespace = typeof(BaseScriptableEvent<>);

            var scriptContent = new ScriptBuilder("EventTemplate")
                .AddSubstitute("EVENT_NAMESPACE", eventNamespace)
                .AddSubstitute("EVENT_NAME", eventName)
                .AddSubstitute("EVENT_ARG_NAME", eventArgName)
                .AddSubstitute("EVENT_MENU_FILE_NAME", eventName)
                .AddSubstitute("EVENT_MENU_ORDER", eventMenuOrder)
                .AddSubstitute("EVENT_MENU_NAME", eventMenuName)
                .AddImport(eventArgNamespace)
                .AddImport(eventNamespace)
                .AddImport(baseNamespace)
                .Build();

            scriptContent.SaveScript(
                scriptDirectory,
                eventName,
                eventNamespace
            );
        }

        private void CreateListenerScript()
        {
            var baseNamespace = typeof(BaseScriptableEvent<>);

            var scriptContent = new ScriptBuilder("ListenerTemplate")
                .AddSubstitute("LISTENER_NAMESPACE", listenerNamespace)
                .AddSubstitute("LISTENER_NAME", listenerName)
                .AddSubstitute("EVENT_ARG_NAME", eventArgName)
                .AddSubstitute("LISTENER_MENU_ORDER", listenerMenuOrder)
                .AddSubstitute("LISTENER_MENU_NAME", listenerMenuName)
                .AddImport(eventArgNamespace)
                .AddImport(baseNamespace)
                .Build();

            scriptContent.SaveScript(
                scriptDirectory,
                listenerName,
                listenerNamespace
            );
        }

        private void CreateEditorScript()
        {
            var baseNamespace = typeof(BaseScriptableEventEditor);

            var scriptContent = new ScriptBuilder("EditorTemplate")
                .AddSubstitute("EDITOR_NAMESPACE", editorNamespace)
                .AddSubstitute("EDITOR_NAME", editorName)
                .AddSubstitute("EVENT_NAME", eventName)
                .AddSubstitute("EVENT_ARG_NAME", eventArgName)
                .AddImport(eventArgNamespace)
                .AddImport(eventNamespace)
                .AddImport(baseNamespace)
                .Build();

            scriptContent.SaveScript(
                scriptDirectory,
                editorName,
                editorNamespace
            );
        }

        #endregion

        #region Private Utility Methods

        private static bool IsAnyBlank(params string[] values)
        {
            return values.Any(string.IsNullOrWhiteSpace);
        }

        private void SetFieldDefaults(string scriptName)
        {
            var prettyEventName = ObjectNames.NicifyVariableName($"{scriptName}ScriptableEvent");

            eventNamespace.DefaultValue = "ScriptableEvents.Events";
            eventName.DefaultValue = $"{scriptName}ScriptableEvent";
            eventMenuName.DefaultValue = prettyEventName;

            listenerNamespace.DefaultValue = "ScriptableEvents.Listeners";
            listenerName.DefaultValue = $"{scriptName}ScriptableEventListener";
            listenerMenuName.DefaultValue = prettyEventName;

            editorNamespace.DefaultValue = "ScriptableEvents.Editor.Events";
            editorName.DefaultValue = $"{scriptName}ScriptableEventEditor";
        }

        private void SetEventArgFields(string scriptName, string scriptNamespace)
        {
            eventArgName.CurrentValue = scriptName;
            eventArgNamespace.CurrentValue = scriptNamespace;
        }

        #endregion
    }
}
