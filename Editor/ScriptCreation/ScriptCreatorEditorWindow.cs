using System;
using System.Linq;
using System.Text.RegularExpressions;
using ScriptableEvents.Editor.States;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

// TODO: updated readme, there is some funky wording there
// TODO: update icons
// TODO: option to disable namespace folder creation (disabled by default)
// TODO: perhaps event name should update components, not the arg type (arg type only initially)?
// TODO: need to save defaults, this will get annoying otherwise
// TODO: UX could be improved, and perhaps a dock window should be used
namespace ScriptableEvents.Editor.ScriptCreation
{
    /// <summary>
    /// Editor window for creating custom Scriptable Event and Listener scripts.
    /// </summary>
    internal class ScriptCreatorEditorWindow : EditorWindow
    {
        #region Regex Constants

        private static readonly Regex NamespaceRegex = new Regex("[^a-zA-Z0-9\\.]");
        private static readonly Regex TypeNameRegex = new Regex("[^a-zA-Z0-9]");
        private static readonly Regex MenuNameRegex = new Regex("[^a-zA-Z0-9 ]");

        #endregion

        #region Window Constants

        private const string WindowTitle = "Script Creator";
        private const string MenuTitle = "Custom Scriptable Event";

        private static readonly Vector2 MinWindowSize = new Vector2(350f, 500f);
        private static readonly Vector2 MaxWindowSize = new Vector2(600f, 600f);

        #endregion

        #region Private Fields

        // Event arg script fields
        [SerializeField]
        private bool isUseMonoScript = true;

        [SerializeField]
        private MonoScript eventArgScript;

        [SerializeField]
        private string eventArgNamespace;

        [SerializeField]
        private string eventArgName;

        // TODO: these values cannot be set from GUI
        // Event script fields
        [SerializeField]
        private bool isCreateEventNamespaceDirectories;

        [SerializeField]
        private string eventNamespace;

        [SerializeField]
        private string eventName;

        [SerializeField]
        private string eventMenuName;

        [SerializeField]
        private int eventMenuOrder;

        // Listener script fields
        [SerializeField]
        private bool isCreateListener;

        [SerializeField]
        private bool isCreateListenerNamespaceDirectories;

        [SerializeField]
        private string listenerNamespace;

        [SerializeField]
        private string listenerName;

        [SerializeField]
        private string listenerMenuName;

        [SerializeField]
        private int listenerMenuOrder;

        // Editor script fields
        [SerializeField]
        private bool isCreateEditor;

        [SerializeField]
        private bool isCreateEditorNamespaceDirectories;

        [SerializeField]
        private string editorNamespace;

        [SerializeField]
        private string editorName;

        // Script output fields
        [SerializeField]
        private string scriptDirectory;

        #endregion

        #region Private Properties

        private bool IsRequiredFieldsSet
        {
            get
            {
                // Event argument type info is always required, regardless if mono script is used
                // or not.
                if (isUseMonoScript && IsArgScriptInvalid)
                {
                    return false;
                }

                if (!isUseMonoScript && IsAnyEventArgFieldsBlank)
                {
                    return false;
                }

                // Event must always have all fields entered as its the base for further scripts.
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
                if (isCreateEditor && IsAnyEditorFieldsBlank)
                {
                    return false;
                }

                // Need to always know where to output.
                if (IsScriptDirectoryBlank)
                {
                    return false;
                }

                return true;
            }
        }

        private bool IsArgScriptInvalid =>
            eventArgScript == null || eventArgScript.GetClass() == null;

        private bool IsAnyEventArgFieldsBlank => IsAnyBlank(eventArgNamespace, eventArgName);

        private bool IsAnyEventFieldsBlank => IsAnyBlank(eventNamespace, eventName, eventMenuName);

        private bool IsAnyListenerFieldsBlank =>
            IsAnyBlank(listenerNamespace, listenerName, listenerMenuName);

        private bool IsAnyEditorFieldsBlank => IsAnyBlank(editorNamespace, editorName);

        private bool IsScriptDirectoryBlank => IsAnyBlank(scriptDirectory);

        #endregion

        #region Unity Lifecycle

        [MenuItem(
            "Assets/Create/" + ScriptableEventConstants.MenuNameBase + "/" + MenuTitle,
            priority = ScriptableEventConstants.MenuOrderTools
        )]
        public static void ShowWindow()
        {
            var window = GetWindow<ScriptCreatorEditorWindow>(true, WindowTitle);

            var selectedMonoScript = Selection.activeObject as MonoScript;
            if (selectedMonoScript != null)
            {
                window.eventArgScript = selectedMonoScript;
            }

            window.minSize = MinWindowSize;
            window.maxSize = MaxWindowSize;
        }

        private void OnEnable()
        {
            SetupDefaults();
        }

        private void OnGUI()
        {
            DrawFields();

            // TODO: clean this up a bit
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Save Defaults"))
            {
                SaveDefaults();
            }

            if (GUILayout.Button("Reset Defaults"))
            {
                ResetDefaults();
            }

            GUI.enabled = IsRequiredFieldsSet;
            if (GUILayout.Button("Create"))
            {
                CreateEvent();
            }

            GUI.enabled = true;

            EditorGUILayout.EndHorizontal();
        }

        #endregion

        #region Private State Methods

        private void SetupDefaults()
        {
            var state = ScriptableEventEditorState.ScriptCreatorState;
            isUseMonoScript = state.IsUseMonoScript;

            isCreateEventNamespaceDirectories = state.IsCreateEventNamespaceDirectories;
            eventNamespace = state.EventNamespace;

            isCreateListener = state.IsCreateListener;
            isCreateListenerNamespaceDirectories = state.IsCreateListenerNamespaceDirectories;
            listenerNamespace = state.ListenerNamespace;

            isCreateEditor = state.IsCreateEditor;
            isCreateEditorNamespaceDirectories = state.IsCreateEditorNamespaceDirectories;
            editorNamespace = state.EditorNamespace;

            scriptDirectory = state.ScriptDirectory;
        }

        private void SaveDefaults()
        {
            var state = ScriptableEventEditorState.ScriptCreatorState;
            state.IsUseMonoScript = isUseMonoScript;

            state.IsCreateEventNamespaceDirectories = isCreateEventNamespaceDirectories;
            state.EventNamespace = eventNamespace;

            state.IsCreateListener = isCreateListener;
            state.IsCreateListenerNamespaceDirectories = isCreateListenerNamespaceDirectories;
            state.ListenerNamespace = listenerNamespace;

            state.IsCreateEditor = isCreateEditor;
            state.IsCreateEditorNamespaceDirectories = isCreateEditorNamespaceDirectories;
            state.EditorNamespace = editorNamespace;

            state.ScriptDirectory = scriptDirectory;
            ScriptableEventEditorState.ScriptCreatorState = state;
        }

        private static void ResetDefaults()
        {
            var state = ScriptableEventEditorState.ScriptCreatorState;
            state.ResetDefaults();
            ScriptableEventEditorState.ScriptCreatorState = state;
        }

        #endregion

        #region Private Drawing Methods

        private void DrawFields()
        {
            EditorGUILayout.LabelField("Event Argument", EditorStyles.boldLabel);
            ToggleFieldWithUndo(ref isUseMonoScript, ScriptableEventGUI.IsUseMonoScriptLabel);
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

            ToggleFieldWithUndo(ref isCreateListener, ScriptableEventGUI.IsCreateListenerLabel);
            GUI.enabled = isCreateListener;
            DrawListenerFields();
            GUI.enabled = true;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Editor Script", EditorStyles.boldLabel);

            ToggleFieldWithUndo(ref isCreateEditor, ScriptableEventGUI.IsCreateEditorLabel);
            GUI.enabled = isCreateEditor;
            DrawEditorFields();
            GUI.enabled = true;

            GUILayout.FlexibleSpace();
            DrawDirectoryFields();
        }

        private void DrawArgMonoScriptFields()
        {
            ObjectFieldWithUndo(ref eventArgScript, ScriptableEventGUI.EventArgScriptLabel);

            // Script is set to none, cannot proceed as we can't get Name or Namespace of the args
            // script.
            if (eventArgScript == null)
            {
                return;
            }

            // At the moment, args script type name must match the file name, otherwise Unity can't
            // find the type info inside the file.
            var eventArgScriptType = eventArgScript.GetClass();
            if (eventArgScriptType == null)
            {
                EditorGUILayout.HelpBox(
                    $"Provided script is invalid, make sure that a class exists in " +
                    $"{eventArgScript.name} file with a matching name. Alternatively, uncheck " +
                    $"{ObjectNames.NicifyVariableName(nameof(isUseMonoScript))} and enter " +
                    $"details manually",
                    MessageType.Error
                );

                return;
            }

            var oldEventArgName = eventArgName;
            var newEventArgName = eventArgScriptType.Name;

            if (oldEventArgName == newEventArgName)
            {
                return;
            }

            SetupFields(oldEventArgName, newEventArgName);

            eventArgNamespace = eventArgScriptType.Namespace;
            eventArgName = newEventArgName;
        }

        private void DrawArgScriptFields()
        {
            TextFieldWithUndo(
                ref eventArgNamespace,
                ScriptableEventGUI.EventArgNamespaceLabel,
                NamespaceRegex
            );

            var oldEventArgName = eventArgName;
            TextFieldWithUndo(
                ref eventArgName,
                ScriptableEventGUI.EventArgNameLabel,
                TypeNameRegex
            );

            var newEventArgName = eventArgName;
            if (oldEventArgName == newEventArgName)
            {
                return;
            }

            SetupFields(oldEventArgName, newEventArgName);
        }

        private void DrawEventFields()
        {
            TextFieldWithUndo(
                ref eventNamespace,
                ScriptableEventGUI.EventNamespaceLabel,
                NamespaceRegex
            );

            TextFieldWithUndo(ref eventName, ScriptableEventGUI.EventNameLabel, TypeNameRegex);

            EditorGUILayout.Space();

            TextFieldWithUndo(
                ref eventMenuName,
                ScriptableEventGUI.EventMenuNameLabel,
                MenuNameRegex
            );

            IntFieldWithUndo(ref eventMenuOrder, ScriptableEventGUI.EventMenuOrderLabel);
        }

        private void DrawListenerFields()
        {
            TextFieldWithUndo(
                ref listenerNamespace,
                ScriptableEventGUI.ListenerNamespaceLabel,
                NamespaceRegex
            );

            TextFieldWithUndo(
                ref listenerName,
                ScriptableEventGUI.ListenerNameLabel,
                TypeNameRegex
            );

            EditorGUILayout.Space();

            TextFieldWithUndo(
                ref listenerMenuName,
                ScriptableEventGUI.ListenerMenuNameLabel,
                MenuNameRegex
            );

            IntFieldWithUndo(ref listenerMenuOrder, ScriptableEventGUI.ListenerMenuOrderLabel);
        }

        private void DrawEditorFields()
        {
            TextFieldWithUndo(
                ref editorNamespace,
                ScriptableEventGUI.EditorNamespaceLabel,
                NamespaceRegex
            );

            TextFieldWithUndo(ref editorName, ScriptableEventGUI.EditorNameLabel, TypeNameRegex);
        }

        private void DrawDirectoryFields()
        {
            EditorGUILayout.BeginHorizontal();

            TextFieldWithUndo(ref scriptDirectory, ScriptableEventGUI.ScriptDirectoryLabel);
            if (GUILayout.Button("Browse"))
            {
                RecordUndo(ScriptableEventGUI.ScriptDirectoryLabel);
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

            SaveEventScript(scriptContent);
        }

        private void SaveEventScript(string content)
        {
            if (isCreateEventNamespaceDirectories)
            {
                ScriptUtils.SaveScript(content, scriptDirectory, eventName, eventNamespace);
            }
            else
            {
                ScriptUtils.SaveScript(content, scriptDirectory, eventName);
            }
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

            SaveListenerScript(scriptContent);
        }

        private void SaveListenerScript(string content)
        {
            if (isCreateListenerNamespaceDirectories)
            {
                ScriptUtils.SaveScript(content, scriptDirectory, listenerName, listenerNamespace);
            }
            else
            {
                ScriptUtils.SaveScript(content, scriptDirectory, listenerName);
            }
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

            SaveEditorScript(scriptContent);
        }

        private void SaveEditorScript(string content)
        {
            if (isCreateEditorNamespaceDirectories)
            {
                ScriptUtils.SaveScript(content, scriptDirectory, editorName, editorNamespace);
            }
            else
            {
                ScriptUtils.SaveScript(content, scriptDirectory, editorName);
            }
        }

        #endregion

        #region Private Utility Methods

        private void SetupFields(string oldArgName, string newArgName)
        {
            SetIfUnmodified(ref eventNamespace, oldArgName, newArgName, GetEventNamespace);
            SetIfUnmodified(ref eventName, oldArgName, newArgName, GetEventName);
            SetIfUnmodified(ref eventMenuName, oldArgName, newArgName, GetEventMenuName);

            SetIfUnmodified(ref listenerNamespace, oldArgName, newArgName, GetListenerNamespace);
            SetIfUnmodified(ref listenerName, oldArgName, newArgName, GetListenerName);
            SetIfUnmodified(ref listenerMenuName, oldArgName, newArgName, GetListenerMenuName);

            SetIfUnmodified(ref editorNamespace, oldArgName, newArgName, GetEditorNamespace);
            SetIfUnmodified(ref editorName, oldArgName, newArgName, GetEditorName);
        }

        private static string GetEventNamespace(string argName)
        {
            var state = ScriptableEventEditorState.ScriptCreatorState;
            return state.EventNamespace;
        }

        private static string GetEventMenuName(string argName)
        {
            var eventName = GetEventName(argName);
            return ObjectNames.NicifyVariableName(eventName);
        }

        private static string GetEventName(string argName)
        {
            return $"{argName}ScriptableEvent";
        }

        private static string GetListenerNamespace(string argName)
        {
            var state = ScriptableEventEditorState.ScriptCreatorState;
            return state.ListenerNamespace;
        }

        private static string GetListenerMenuName(string argName)
        {
            var listenerName = GetListenerName(argName);
            return ObjectNames.NicifyVariableName(listenerName);
        }

        private static string GetListenerName(string argName)
        {
            return $"{argName}ScriptableEventListener";
        }

        private static string GetEditorNamespace(string argName)
        {
            var state = ScriptableEventEditorState.ScriptCreatorState;
            return state.EditorNamespace;
        }

        private static string GetEditorName(string argName)
        {
            return $"{argName}ScriptableEventEditor";
        }

        private static void SetIfUnmodified(
            ref string value,
            string oldArgName,
            string newArgName,
            Func<string, string> valueMapper
        )
        {
            // Value was not modified when a argument script change was made - results in way better
            // UX as you can swap around scripts quickly.
            if (IsBlank(value) || value == valueMapper(oldArgName))
            {
                value = valueMapper(newArgName);
            }
        }

        private static bool IsAnyBlank(params string[] values)
        {
            return values.Any(string.IsNullOrWhiteSpace);
        }

        private static bool IsBlank(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        private void ObjectFieldWithUndo<T>(ref T value, GUIContent label) where T : Object
        {
            EditorGUI.BeginChangeCheck();

            var newValue = ScriptableEventGUI.ObjectField(value, label);

            if (EditorGUI.EndChangeCheck())
            {
                RecordUndo(label);
                value = newValue;
            }
        }

        private void TextFieldWithUndo(ref string value, GUIContent label, Regex regex = null)
        {
            var originalColor = GUI.color;
            if (GUI.enabled && string.IsNullOrWhiteSpace(value))
            {
                GUI.color = Color.red;
            }

            EditorGUI.BeginChangeCheck();

            var newValue = ScriptableEventGUI.TextField(value, label);
            GUI.color = originalColor;

            if (newValue != null && regex != null)
            {
                newValue = regex.Replace(newValue, string.Empty).Trim();
            }

            if (EditorGUI.EndChangeCheck())
            {
                RecordUndo(label);
                value = newValue;
            }
        }

        private void ToggleFieldWithUndo(ref bool value, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();

            var newValue = ScriptableEventGUI.Toggle(value, label);

            if (EditorGUI.EndChangeCheck())
            {
                RecordUndo(label);
                value = newValue;
            }
        }

        private void IntFieldWithUndo(ref int value, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();

            var newValue = ScriptableEventGUI.IntField(value, label);

            if (EditorGUI.EndChangeCheck())
            {
                RecordUndo(label);
                value = newValue;
            }
        }

        private void RecordUndo(GUIContent targetLabel)
        {
            Undo.RecordObject(this, $"Modify {targetLabel.text}");
        }

        #endregion
    }
}
