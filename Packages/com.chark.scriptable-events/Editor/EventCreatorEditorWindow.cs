using System;
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
        #region GUI Constants

        private static readonly GUIContent IsUseMonoScriptLabel = new GUIContent(
            "Is Use Mono Script",
            "Should a MonoScript be used for gathering event argument type information?"
        );

        private static readonly GUIContent EventArgScriptLabel = new GUIContent(
            "Event Argument Script",
            "Script which will be used as an argument for the custom event"
        );

        private static readonly GUIContent EventArgNamespaceLabel = new GUIContent(
            "Event Argument Namespace",
            "Namespace of the event argument type"
        );

        private static readonly GUIContent EventArgNameLabel = new GUIContent(
            "Event Argument Name",
            "Name of the event argument type"
        );

        private static readonly GUIContent EventNamespaceLabel = new GUIContent(
            "Event Namespace",
            "Namespace used for the custom event script. Note that this namespace will also be " +
            "used to generate directories for the event asset script (e.g., namespace " +
            "MyScriptableEvents.Events will result in MyScriptableEvents/Events directory)"
        );

        private static readonly GUIContent EventNameLabel = new GUIContent(
            "Event Name",
            "Name of the custom event script"
        );

        private static readonly GUIContent EventMenuNameLabel = new GUIContent(
            "Event Menu Name",
            "Menu name of the custom event asset"
        );

        private static readonly GUIContent EventMenuOrderLabel = new GUIContent(
            "Event Menu Order",
            "Menu order of the custom event asset"
        );

        private static readonly GUIContent IsCreateListenerLabel = new GUIContent(
            "Is Create Listener",
            "Should a custom event listener script be generated?"
        );

        private static readonly GUIContent ListenerNamespaceLabel = new GUIContent(
            "Listener Namespace",
            "Namespace used for the custom event listener script. Note that this namespace will " +
            "also be used to generate directories for the event listener script (e.g., namespace " +
            "MyScriptableEvents.Listeners will result in MyScriptableEvents/Listeners " +
            "directory)"
        );

        private static readonly GUIContent ListenerNameLabel = new GUIContent(
            "Listener Name",
            "Name of the custom event listener script"
        );

        private static readonly GUIContent ListenerMenuNameLabel = new GUIContent(
            "Listener Menu Name",
            "Menu name of the custom event listener component"
        );

        private static readonly GUIContent ListenerMenuOrderLabel = new GUIContent(
            "Listener Menu Order",
            "Menu order of the custom event listener component"
        );

        private static readonly GUIContent IsCreateEditorLabel = new GUIContent(
            "Is Create Editor",
            "Should a custom event editor script be generated?"
        );

        private static readonly GUIContent EditorNamespaceLabel = new GUIContent(
            "Editor Namespace",
            "Namespace used for the custom event editor script. Note that this namespace will " +
            "also be used to generate directories for the event editor script (e.g., " +
            "namespace MyScriptableEvents.Editor will result in MyScriptableEvents/Editor " +
            "directory)"
        );

        private static readonly GUIContent EditorNameLabel = new GUIContent(
            "Editor Name",
            "Name of the custom event editor script"
        );

        private static readonly GUIContent ScriptDirectoryLabel = new GUIContent(
            "Output Directory",
            "Directory where to generate the scripts"
        );

        #endregion

        #region Regex Constants

        private static readonly Regex NamespaceRegex = new Regex("[^a-zA-Z0-9\\.]");
        private static readonly Regex TypeNameRegex = new Regex("[^a-zA-Z0-9]");
        private static readonly Regex MenuNameRegex = new Regex("[^a-zA-Z0-9 ]");

        #endregion

        #region Window Constants

        private const string WindowTitle = "Create Custom Scriptable Event";
        private const string MenuTitle = "Custom Scriptable Event";

        private static readonly Vector2 MinWindowSize = new Vector2(350f, 500f);
        private static readonly Vector2 MaxWindowSize = new Vector2(600f, 600f);

        #endregion

        #region Fields

        private bool isUseMonoScript = true;
        private MonoScript eventArgScript;
        private string eventArgNamespace;
        private string eventArgName;

        private string eventNamespace;
        private string eventName;
        private string eventMenuName;
        private int eventMenuOrder;

        private bool isCreateListener = true;
        private string listenerNamespace;
        private string listenerName;
        private string listenerMenuName;
        private int listenerMenuOrder;

        private bool isCreateEditor;
        private string editorNamespace;
        private string editorName;

        private string scriptDirectory = "Assets/Scripts";

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
            var window = GetWindow<EventCreatorEditorWindow>(true, WindowTitle);
            window.minSize = MinWindowSize;
            window.maxSize = MaxWindowSize;
        }

        private void OnGUI()
        {
            DrawFields();

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
            EditorGUILayout.LabelField("Event Argument", EditorStyles.boldLabel);
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

            GUILayout.FlexibleSpace();
            DrawDirectoryFields();
        }

        private void DrawArgMonoScriptFields()
        {
            eventArgScript = (MonoScript) EditorGUILayout.ObjectField(
                EventArgScriptLabel,
                eventArgScript,
                typeof(MonoScript),
                false
            );

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
            Draw(EventArgNamespaceLabel, NamespaceRegex, ref eventArgNamespace);

            var oldEventArgName = eventArgName;
            Draw(EventArgNameLabel, TypeNameRegex, ref eventArgName);
            var newEventArgName = eventArgName;

            if (oldEventArgName == newEventArgName)
            {
                return;
            }

            SetupFields(oldEventArgName, newEventArgName);
        }

        private void DrawEventFields()
        {
            Draw(EventNamespaceLabel, NamespaceRegex, ref eventNamespace);
            Draw(EventNameLabel, TypeNameRegex, ref eventName);

            EditorGUILayout.Space();

            Draw(EventMenuNameLabel, MenuNameRegex, ref eventMenuName);
            Draw(EventMenuOrderLabel, ref eventMenuOrder);
        }

        private void DrawListenerFields()
        {
            Draw(ListenerNamespaceLabel, NamespaceRegex, ref listenerNamespace);
            Draw(ListenerNameLabel, TypeNameRegex, ref listenerName);

            EditorGUILayout.Space();

            Draw(ListenerMenuNameLabel, MenuNameRegex, ref listenerMenuName);
            Draw(ListenerMenuOrderLabel, ref listenerMenuOrder);
        }

        private void DrawEditorFields()
        {
            Draw(EditorNamespaceLabel, NamespaceRegex, ref editorNamespace);
            Draw(EditorNameLabel, TypeNameRegex, ref editorName);
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
            return "ScriptableEvents.Events";
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
            return "ScriptableEvents.Listeners";
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
            return "ScriptableEvents.Editor.Events";
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

        private static void Draw(GUIContent label, Regex regex, ref string value)
        {
            var originalColor = GUI.color;
            if (GUI.enabled && string.IsNullOrWhiteSpace(value))
            {
                GUI.color = Color.red;
            }

            var newValue = EditorGUILayout.TextField(label, value);
            GUI.color = originalColor;

            if (newValue != null)
            {
                newValue = regex.Replace(newValue, string.Empty).Trim();
            }

            value = newValue;
        }

        private static void Draw(GUIContent label, ref int value)
        {
            var newValue = EditorGUILayout.IntField(label, value);
            newValue = Mathf.Max(0, newValue);

            value = newValue;
        }

        #endregion
    }
}
