using System;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableEvents.Editor.ScriptCreation
{
    /// <summary>
    /// Utilities to draw editor window GUI in <see cref="ScriptCreatorEditorWindow"/>.
    /// </summary>
    internal static class ScriptCreatorEditorWindowGUI
    {
        #region Private Regex Fields

        private static readonly Regex NamespaceRegex = new Regex("[^a-zA-Z0-9\\.]");
        private static readonly Regex TypeNameRegex = new Regex("[^a-zA-Z0-9]");
        private static readonly Regex MenuNameRegex = new Regex("[^a-zA-Z0-9 ]");

        #endregion

        #region Private Label Fields

        private static readonly GUIContent EventArgumentHeaderLabel = new GUIContent(
            "Event Argument"
        );

        private static readonly GUIContent EventArgumentIsMonoScriptLabel = new GUIContent(
            "Is Mono Script",
            "Should a MonoScript be used for gathering event argument type information?"
        );

        private static readonly GUIContent EventArgumentScriptLabel = new GUIContent(
            "Script",
            "Script which will be used as an argument for the custom event"
        );

        private static readonly GUIContent EventArgumentScriptNameLabel = new GUIContent(
            "Script Name",
            "Name of the event argument type"
        );

        private static readonly GUIContent EventArgumentNamespaceLabel = new GUIContent(
            "Script Namespace",
            "Namespace of the event argument type"
        );

        private static readonly GUIContent EventHeaderLabel = new GUIContent(
            "Event"
        );

        private static readonly GUIContent EventNameLabel = new GUIContent(
            "Script Name",
            "Name of the custom event script"
        );

        private static readonly GUIContent EventNamespaceLabel = new GUIContent(
            "Script Namespace",
            "Namespace used for the custom event script. Note that this namespace will also be " +
            "used to generate directories for the event asset script (e.g., namespace " +
            "MyScriptableEvents.Events will result in MyScriptableEvents/Events directory)"
        );

        private static readonly GUIContent EventNamespaceDirToggleLabel = new GUIContent(
            "Is Create Directories",
            "Should directories be created for each nested part in event namespace?"
        );

        private static readonly GUIContent EventMenuNameLabel = new GUIContent(
            "Menu Name",
            "Menu name of the custom event asset"
        );

        private static readonly GUIContent EventMenuOrderLabel = new GUIContent(
            "Menu Order",
            "Menu order of the custom event asset"
        );

        private static readonly GUIContent EventListenerToggleLabel = new GUIContent(
            "Listener",
            "Should a custom event listener script be generated?"
        );

        private static readonly GUIContent ListenerNameLabel = new GUIContent(
            "Script Name",
            "Name of the custom event listener script"
        );

        private static readonly GUIContent ListenerNamespaceLabel = new GUIContent(
            "Script Namespace",
            "Namespace used for the custom event listener script. Note that this namespace will " +
            "also be used to generate directories for the event listener script (e.g., namespace " +
            "MyScriptableEvents.Listeners will result in MyScriptableEvents/Listeners " +
            "directory)"
        );


        private static readonly GUIContent ListenerNamespaceDirToggleLabel = new GUIContent(
            "Is Create Directories",
            "Should directories be created for each nested part in listener namespace?"
        );

        private static readonly GUIContent ListenerMenuNameLabel = new GUIContent(
            "Menu Name",
            "Menu name of the custom event listener component"
        );

        private static readonly GUIContent ListenerMenuOrderLabel = new GUIContent(
            "Menu Order",
            "Menu order of the custom event listener component"
        );

        private static readonly GUIContent EditorToggleLabel = new GUIContent(
            "Editor",
            "Should a custom event editor script be generated?"
        );

        private static readonly GUIContent EditorNameLabel = new GUIContent(
            "Script Name",
            "Name of the custom event editor script"
        );

        private static readonly GUIContent EditorNamespaceLabel = new GUIContent(
            "Script Namespace",
            "Namespace used for the custom event editor script. Note that this namespace will " +
            "also be used to generate directories for the event editor script (e.g., " +
            "namespace MyScriptableEvents.Editor will result in MyScriptableEvents/Editor " +
            "directory)"
        );

        private static readonly GUIContent EditorNamespaceDirToggleLabel = new GUIContent(
            "Is Create Directories",
            "Should directories be created for each nested part in editor namespace?"
        );

        private static readonly GUIContent ScriptDirectoryLabel = new GUIContent(
            "Output Directory",
            "Directory where to generate the scripts"
        );

        private static readonly GUIContent MenuApplyDefaultsLabel = new GUIContent(
            "Apply Defaults"
        );

        private static readonly GUIContent MenuRevertDefaultsLabel = new GUIContent(
            "Revert Defaults"
        );

        private static readonly GUIContent MenuOverrideDefaultsLabel = new GUIContent(
            "Override Defaults"
        );

        #endregion

        #region Private Style Properties

        private static GUIStyle OptionsButtonStyle =>
            optionsButtonStyle ??= GetOptionsButtonStyle();

        private static GUIStyle optionsButtonStyle;

        private static GUIContent OptionsButtonIcon =>
            optionsButtonIcon ??= GetOptionsButtonIcon();

        private static GUIContent optionsButtonIcon;

        #endregion

        #region Internal Event Argument Drawing Methods

        /// <summary>
        /// Draw a header label for event argument fields.
        /// </summary>
        internal static void DrawEventArgumentHeader()
        {
            EditorGUILayout.LabelField(EventArgumentHeaderLabel, EditorStyles.boldLabel);
        }

        /// <summary>
        /// Draw a toggle to decide if a mono script should be used when choosing event argument.
        /// </summary>
        internal static bool DrawMonoScriptToggle(this Object obj, bool isEnabled)
        {
            return obj.ToggleWithUndo(isEnabled, EventArgumentIsMonoScriptLabel, true);
        }

        /// <summary>
        /// Draw event argument script selection field.
        /// </summary>
        internal static MonoScript DrawEventArgumentMonoField(this Object obj, MonoScript script)
        {
            return obj.ObjectFieldWithUndo(script, EventArgumentScriptLabel);
        }

        /// <summary>
        /// Draw a help box for an invalid event argument script.
        /// </summary>
        internal static void DrawEventArgumentHelpBox(MonoScript script)
        {
            EditorGUILayout.HelpBox(
                $"Provided script is invalid, make sure that a class exists in " +
                $"{script.name} file with a matching name. Alternatively, uncheck " +
                $"{EventArgumentIsMonoScriptLabel.text} and enter details manually",
                MessageType.Error
            );
        }

        /// <summary>
        /// Draw existing event argument script namespace.
        /// </summary>
        internal static string DrawEventArgumentNamespaceField(this Object obj, string @namespace)
        {
            return obj.TextFieldWithUndo(@namespace, EventArgumentNamespaceLabel, NamespaceRegex);
        }

        /// <summary>
        /// Draw existing event argument script and type name.
        /// </summary>
        internal static string DrawEventArgumentNameField(this Object obj, string name)
        {
            return obj.TextFieldWithUndo(name, EventArgumentScriptNameLabel, TypeNameRegex);
        }

        #endregion

        #region Internal Event Drawing Methods

        /// <summary>
        /// Draw a header label for event fields.
        /// </summary>
        internal static void DrawEventHeader()
        {
            EditorGUILayout.LabelField(EventHeaderLabel, EditorStyles.boldLabel);
        }

        /// <summary>
        /// Draw event script name.
        /// </summary>
        internal static string DrawEventNameField(this Object obj, string name)
        {
            return obj.TextFieldWithUndo(name, EventNameLabel, TypeNameRegex);
        }

        /// <summary>
        /// Draw event script namespace.
        /// </summary>
        internal static string DrawEventNamespaceField(this Object obj, string @namespace)
        {
            return obj.TextFieldWithUndo(@namespace, EventNamespaceLabel, NamespaceRegex);
        }

        /// <summary>
        /// Draw event namespace directory toggle.
        /// </summary>
        internal static bool DrawEventNamespaceDirToggle(this Object obj, bool isEnabled)
        {
            return obj.ToggleWithUndo(isEnabled, EventNamespaceDirToggleLabel);
        }

        /// <summary>
        /// Draw event asset menu name.
        /// </summary>
        internal static string DrawEventMenuNameField(this Object obj, string name)
        {
            return obj.TextFieldWithUndo(name, EventMenuNameLabel, MenuNameRegex);
        }

        /// <summary>
        /// Draw event asset menu order.
        /// </summary>
        internal static int DrawEventMenuOrderField(this Object obj, int order)
        {
            return obj.IntFieldWithUndo(order, EventMenuOrderLabel);
        }

        #endregion

        #region Internal Listener Drawing Methods

        /// <summary>
        /// Draw a header toggle which controls if listener script should be created.
        /// </summary>
        internal static bool DrawListenerToggle(this Object obj, bool isEnabled)
        {
            return obj.ToggleWithUndo(isEnabled, EventListenerToggleLabel, true, true);
        }

        /// <summary>
        /// Draw listener script name.
        /// </summary>
        internal static string DrawListenerNameField(this Object obj, string name)
        {
            return obj.TextFieldWithUndo(name, ListenerNameLabel, TypeNameRegex);
        }

        /// <summary>
        /// Draw listener script namespace.
        /// </summary>
        internal static string DrawListenerNamespaceField(this Object obj, string @namespace)
        {
            return obj.TextFieldWithUndo(@namespace, ListenerNamespaceLabel, NamespaceRegex);
        }

        /// <summary>
        /// Draw listener script namespace directory toggle.
        /// </summary>
        internal static bool DrawListenerNamespaceDirToggle(this Object obj, bool isEnabled)
        {
            return obj.ToggleWithUndo(isEnabled, ListenerNamespaceDirToggleLabel);
        }

        /// <summary>
        /// Draw listener component menu name.
        /// </summary>
        internal static string DrawListenerMenuNameField(this Object obj, string name)
        {
            return obj.TextFieldWithUndo(name, ListenerMenuNameLabel, MenuNameRegex);
        }

        /// <summary>
        /// Draw listener component menu order.
        /// </summary>
        internal static int DrawListenerMenuOrderField(this Object obj, int order)
        {
            return obj.IntFieldWithUndo(order, ListenerMenuOrderLabel);
        }

        #endregion

        #region Internal Editor Drawing Methods

        /// <summary>
        /// Draw a header toggle which controls if editor script should be created.
        /// </summary>
        internal static bool DrawEditorToggle(this Object obj, bool isEnabled)
        {
            return obj.ToggleWithUndo(isEnabled, EditorToggleLabel, true, true);
        }

        /// <summary>
        /// Draw editor script name.
        /// </summary>
        internal static string DrawEditorNameField(this Object obj, string name)
        {
            return obj.TextFieldWithUndo(name, EditorNameLabel, TypeNameRegex);
        }

        /// <summary>
        /// Draw editor script namespace.
        /// </summary>
        internal static string DrawEditorNamespaceField(this Object obj, string @namespace)
        {
            return obj.TextFieldWithUndo(@namespace, EditorNamespaceLabel, NamespaceRegex);
        }

        /// <summary>
        /// Draw editor script namespace directory toggle.
        /// </summary>
        internal static bool DrawEditorNamespaceDirToggle(this Object obj, bool isEnabled)
        {
            return obj.ToggleWithUndo(isEnabled, EditorNamespaceDirToggleLabel);
        }

        #endregion

        #region Internal Utility Drawing Methods

        /// <summary>
        /// Draw header (toolbar) of the script creation window.
        /// </summary>
        internal static Rect DrawWindowHeader(
            Rect position,
            bool isBuiltInDefaults,
            Action onApplyDefaults,
            Action onRevertDefaults,
            Action onOverrideDefaults
        )
        {
            GUILayout.BeginHorizontal();

            GUILayout.FlexibleSpace();

            if (GUILayout.Button(OptionsButtonIcon, OptionsButtonStyle))
            {
                var menu = new GenericMenu();
                if (isBuiltInDefaults)
                {
                    menu.AddItem(MenuApplyDefaultsLabel, false, onApplyDefaults.Invoke);
                    menu.AddDisabledItem(MenuRevertDefaultsLabel);
                    menu.AddItem(MenuOverrideDefaultsLabel, false, onOverrideDefaults.Invoke);
                }
                else
                {
                    menu.AddItem(MenuApplyDefaultsLabel, false, onApplyDefaults.Invoke);
                    menu.AddItem(MenuRevertDefaultsLabel, false, onRevertDefaults.Invoke);
                    menu.AddItem(MenuOverrideDefaultsLabel, false, onOverrideDefaults.Invoke);
                }

                menu.DropDown(position);
            }

            if (Event.current.type == EventType.Repaint)
            {
                position = GUILayoutUtility.GetLastRect();
            }

            GUILayout.EndHorizontal();

            return position;
        }

        /// <summary>
        /// Draw a field and a button to change script output directory.
        /// </summary>
        internal static string DrawScriptDirectory(this Object obj, string directory)
        {
            EditorGUILayout.BeginHorizontal();

            var newDirectory = obj.TextFieldWithUndo(directory, ScriptDirectoryLabel);
            if (GUILayout.Button("Browse"))
            {
                var selectedDirectory = EditorUtility
                    .OpenFolderPanel("Choose script directory", "", "");

                if (!string.IsNullOrWhiteSpace(selectedDirectory))
                {
                    obj.RecordUndo(ScriptDirectoryLabel);
                    newDirectory = selectedDirectory;
                }
            }

            EditorGUILayout.EndHorizontal();

            return newDirectory;
        }

        /// <summary>
        /// Draw a button to create event scripts.
        /// </summary>
        internal static void DrawCreateEventButton(bool isEnabled, Action onClick)
        {
            GUI.enabled = isEnabled;
            if (GUILayout.Button("Create"))
            {
                onClick.Invoke();
            }

            GUI.enabled = true;
        }

        #endregion

        #region Private Methods

        private static GUIStyle GetOptionsButtonStyle()
        {
            return GUI.skin.GetStyle("IconButton");
        }

        private static GUIContent GetOptionsButtonIcon()
        {
            return EditorGUIUtility.IconContent("_Popup");
        }

        private static T ObjectFieldWithUndo<T>(
            this Object obj,
            T value,
            GUIContent label
        ) where T : Object
        {
            EditorGUI.BeginChangeCheck();

            var newValue = ScriptableEventGUI.ObjectField(value, label);

            if (EditorGUI.EndChangeCheck())
            {
                RecordUndo(obj, label);
            }

            return newValue;
        }

        private static string TextFieldWithUndo(
            this Object obj,
            string value,
            GUIContent label,
            Regex regex = null
        )
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
                RecordUndo(obj, label);
            }

            return newValue;
        }

        private static bool ToggleWithUndo(
            this Object obj,
            bool value,
            GUIContent label,
            bool isBold = false,
            bool isLeft = false
        )
        {
            EditorGUI.BeginChangeCheck();

            var newValue = ScriptableEventGUI.Toggle(value, label, isBold, isLeft);

            if (EditorGUI.EndChangeCheck())
            {
                RecordUndo(obj, label);
            }

            return newValue;
        }

        private static int IntFieldWithUndo(this Object obj, int value, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();

            var newValue = ScriptableEventGUI.IntField(value, label);

            if (EditorGUI.EndChangeCheck())
            {
                RecordUndo(obj, label);
            }

            return newValue;
        }

        private static void RecordUndo(this Object obj, GUIContent targetLabel)
        {
            Undo.RecordObject(obj, $"Modify {targetLabel.text}");
        }

        #endregion
    }
}
