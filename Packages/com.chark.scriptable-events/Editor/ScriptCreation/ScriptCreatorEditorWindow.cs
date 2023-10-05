using System;
using System.Linq;
using CHARK.ScriptableEvents.Editor.States;
using UnityEditor;
using UnityEngine;

namespace CHARK.ScriptableEvents.Editor.ScriptCreation
{
    /// <summary>
    /// Editor window for creating custom Scriptable Event and Listener scripts.
    /// </summary>
    internal class ScriptCreatorEditorWindow : EditorWindow
    {
        #region Window Constants

        private const string WindowTitle = "Script Creator";
        private const string MenuTitle = "Custom Scriptable Event";

        #endregion

        #region Private Event Argument Script Fields

        [SerializeField]
        private bool isUseMonoScript = true;

        [SerializeField]
        private MonoScript eventArgScript;

        [SerializeField]
        private string eventArgName;

        [SerializeField]
        private string eventArgNamespace;

        #endregion

        #region Private Event Script Fields

        [SerializeField]
        private string eventName;

        [SerializeField]
        private string eventNamespace;

        [SerializeField]
        private bool isCreateEventNamespaceDirs;

        [SerializeField]
        private string eventMenuName;

        [SerializeField]
        private int eventMenuOrder;

        #endregion

        #region Private Listener Script Fields

        [SerializeField]
        private bool isCreateListener;

        [SerializeField]
        private string listenerName;

        [SerializeField]
        private string listenerNamespace;

        [SerializeField]
        private bool isCreateListenerNamespaceDirs;

        [SerializeField]
        private string listenerMenuName;

        [SerializeField]
        private int listenerMenuOrder;

        #endregion

        #region Private Editor Script Fields

        [SerializeField]
        private string editorName;

        [SerializeField]
        private bool isCreateEditor;

        [SerializeField]
        private string editorNamespace;

        [SerializeField]
        private bool isCreateEditorNamespaceDirs;

        #endregion

        #region Private Fields

        [SerializeField]
        private string scriptDirectory;

        [SerializeField]
        private Vector2 scrollPosition;

        private Rect optionsButtonPosition;

        #endregion

        #region Unity Lifecycle

        [MenuItem(
            "Assets/Create/" + ScriptableEventConstants.MenuNameBase + "/" + MenuTitle,
            priority = ScriptableEventConstants.MenuOrderTools
        )]
        public static void ShowWindow()
        {
            var window = GetWindow<ScriptCreatorEditorWindow>(false, WindowTitle);

            var selectedMonoScript = Selection.activeObject as MonoScript;
            if (selectedMonoScript != null)
            {
                window.eventArgScript = selectedMonoScript;
            }

            window.ApplyDefaults();
            window.Show();
        }

        private void OnGUI()
        {
            DrawWindowHeader();
            scrollPosition = ScriptableEventGUI.Scroll(scrollPosition, DrawContent);
            DrawCreateButton();
        }

        #endregion

        #region Private Drawing Methods

        private void DrawWindowHeader()
        {
            var state = ScriptableEventEditorState.ScriptCreatorState;
            var isBuiltInDefaults = state.IsBuiltInDefaults;

            optionsButtonPosition = ScriptCreatorEditorWindowGUI.DrawWindowHeader(
                optionsButtonPosition,
                isBuiltInDefaults,
                ApplyDefaults,
                RevertDefaults,
                OverrideDefaults
            );
        }

        private void DrawContent()
        {
            ScriptableEventGUI.Group(DrawEventArgumentGroup);
            ScriptableEventGUI.Group(DrawEventGroup);
            ScriptableEventGUI.Group(DrawListenerGroup);
            ScriptableEventGUI.Group(DrawEditorGroup);

            GUILayout.FlexibleSpace();

            scriptDirectory = this.DrawScriptDirectory(scriptDirectory);
        }

        private void DrawCreateButton()
        {
            var isFieldsSet = IsRequiredFieldsSet();
            ScriptCreatorEditorWindowGUI.DrawCreateEventButton(isFieldsSet, CreateScripts);
        }

        private void DrawEventArgumentGroup()
        {
            ScriptCreatorEditorWindowGUI.DrawEventArgumentHeader();
            isUseMonoScript = this.DrawMonoScriptToggle(isUseMonoScript);

            if (isUseMonoScript)
            {
                DrawEventArgumentMonoFields();
            }
            else
            {
                DrawEventArgumentFields();
            }
        }

        private void DrawEventGroup()
        {
            ScriptCreatorEditorWindowGUI.DrawEventHeader();
            DrawEventFields();
        }

        private void DrawListenerGroup()
        {
            isCreateListener = this.DrawListenerToggle(isCreateListener);
            if (isCreateListener)
            {
                DrawListenerFields();
            }
        }

        private void DrawEditorGroup()
        {
            isCreateEditor = this.DrawEditorToggle(isCreateEditor);
            if (isCreateEditor)
            {
                DrawEditorFields();
            }
        }

        private void DrawEventArgumentMonoFields()
        {
            eventArgScript = this.DrawEventArgumentMonoField(eventArgScript);

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
                ScriptCreatorEditorWindowGUI.DrawEventArgumentHelpBox(eventArgScript);
                return;
            }

            var oldEventArgName = eventArgName;
            var newEventArgName = eventArgScriptType.Name;

            if (oldEventArgName == newEventArgName)
            {
                return;
            }

            SetupFields(oldEventArgName, newEventArgName);

            eventArgName = newEventArgName;
            eventArgNamespace = eventArgScriptType.Namespace;
        }

        private void DrawEventArgumentFields()
        {
            var oldEventArgName = eventArgName;
            eventArgName = this.DrawEventArgumentNameField(eventArgName);
            var newEventArgName = eventArgName;

            if (oldEventArgName != newEventArgName)
            {
                SetupFields(oldEventArgName, newEventArgName);
            }

            eventArgNamespace = this.DrawEventArgumentNamespaceField(eventArgNamespace);
        }

        private void DrawEventFields()
        {
            eventName = this.DrawEventNameField(eventName);
            eventNamespace = this.DrawEventNamespaceField(eventNamespace);
            isCreateEventNamespaceDirs =
                this.DrawEventNamespaceDirToggle(isCreateEventNamespaceDirs);

            EditorGUILayout.Space();

            eventMenuName = this.DrawEventMenuNameField(eventMenuName);
            eventMenuOrder = this.DrawEventMenuOrderField(eventMenuOrder);
        }

        private void DrawListenerFields()
        {
            listenerName = this.DrawListenerNameField(listenerName);
            listenerNamespace = this.DrawListenerNamespaceField(listenerNamespace);
            isCreateListenerNamespaceDirs =
                this.DrawListenerNamespaceDirToggle(isCreateListenerNamespaceDirs);

            EditorGUILayout.Space();

            listenerMenuName = this.DrawListenerMenuNameField(listenerMenuName);
            listenerMenuOrder = this.DrawListenerMenuOrderField(listenerMenuOrder);
        }

        private void DrawEditorFields()
        {
            editorName = this.DrawEditorNameField(editorName);
            editorNamespace = this.DrawEditorNamespaceField(editorNamespace);
            isCreateEditorNamespaceDirs =
                this.DrawEditorNamespaceDirToggle(isCreateEditorNamespaceDirs);
        }

        #endregion

        #region Private Script Creation Methods

        private void CreateScripts()
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
            var baseNamespace = typeof(ScriptableEvent<>);

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
            if (isCreateEventNamespaceDirs)
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
            var baseNamespace = typeof(ScriptableEvent<>);

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
            if (isCreateListenerNamespaceDirs)
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
            var baseNamespace = typeof(ScriptableEventEditor);

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
            if (isCreateEditorNamespaceDirs)
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

        private void ApplyDefaults()
        {
            var state = ScriptableEventEditorState.ScriptCreatorState;
            isUseMonoScript = state.IsUseMonoScript;

            eventNamespace = state.EventNamespace;
            isCreateEventNamespaceDirs = state.IsCreateEventNamespaceDirs;

            isCreateListener = state.IsCreateListener;
            listenerNamespace = state.ListenerNamespace;
            isCreateListenerNamespaceDirs = state.IsCreateListenerNamespaceDirs;

            isCreateEditor = state.IsCreateEditor;
            editorNamespace = state.EditorNamespace;
            isCreateEditorNamespaceDirs = state.IsCreateEditorNamespaceDirs;

            scriptDirectory = state.ScriptDirectory;
        }

        private void OverrideDefaults()
        {
            var state = ScriptableEventEditorState.ScriptCreatorState;
            state.IsUseMonoScript = isUseMonoScript;

            state.EventNamespace = eventNamespace;
            state.IsCreateEventNamespaceDirs = isCreateEventNamespaceDirs;

            state.IsCreateListener = isCreateListener;
            state.ListenerNamespace = listenerNamespace;
            state.IsCreateListenerNamespaceDirs = isCreateListenerNamespaceDirs;

            state.IsCreateEditor = isCreateEditor;
            state.EditorNamespace = editorNamespace;
            state.IsCreateEditorNamespaceDirs = isCreateEditorNamespaceDirs;

            state.ScriptDirectory = scriptDirectory;
            ScriptableEventEditorState.ScriptCreatorState = state;
        }

        private static void RevertDefaults()
        {
            var state = ScriptableEventEditorState.ScriptCreatorState;
            state.RevertDefaults();
            ScriptableEventEditorState.ScriptCreatorState = state;
        }

        private void SetupFields(string oldArgName, string newArgName)
        {
            SetIfUnmodified(ref eventName, oldArgName, newArgName, GetEventName);
            SetIfUnmodified(ref eventNamespace, oldArgName, newArgName, GetEventNamespace);
            SetIfUnmodified(ref eventMenuName, oldArgName, newArgName, GetEventMenuName);

            SetIfUnmodified(ref listenerName, oldArgName, newArgName, GetListenerName);
            SetIfUnmodified(ref listenerNamespace, oldArgName, newArgName, GetListenerNamespace);
            SetIfUnmodified(ref listenerMenuName, oldArgName, newArgName, GetListenerMenuName);

            SetIfUnmodified(ref editorName, oldArgName, newArgName, GetEditorName);
            SetIfUnmodified(ref editorNamespace, oldArgName, newArgName, GetEditorNamespace);
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

        private bool IsRequiredFieldsSet()
        {
            // Event argument type info is always required, regardless if mono script is used
            // or not.
            if (isUseMonoScript && (eventArgScript == null || eventArgScript.GetClass() == null))
            {
                return false;
            }

            if (!isUseMonoScript && IsAnyBlank(eventArgName, eventArgNamespace))
            {
                return false;
            }

            // Event must always have all fields entered as its the base for further scripts.
            if (IsAnyBlank(eventName, eventNamespace, eventMenuName))
            {
                return false;
            }

            // Listener is optional, as event might be used via code.
            if (isCreateListener && IsAnyBlank(listenerName, listenerNamespace, listenerMenuName))
            {
                return false;
            }

            // Editor is always optional.
            if (isCreateEditor && IsAnyBlank(editorName, editorNamespace))
            {
                return false;
            }

            // Need to always know where to output.
            if (IsAnyBlank(scriptDirectory))
            {
                return false;
            }

            return true;
        }

        private static bool IsAnyBlank(params string[] values)
        {
            return values.Any(IsBlank);
        }

        private static bool IsBlank(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        #endregion
    }
}
