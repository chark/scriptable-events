using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Utility class for drawing inspector GUIs.
    /// </summary>
    internal static class ScriptableEventGUI
    {
        #region General Labels

        private static readonly GUIContent MonoScriptLabel = new GUIContent("Script");

        #endregion

        #region Internal Event Labels

        internal static readonly GUIContent RaiseEventLabel = new GUIContent(
            "Raise Event",
            "Raise event and trigger all added listeners"
        );

        internal static readonly GUIContent DescriptionLabelContent = new GUIContent(
            "Description",
            "Custom description to provide additional information"
        );

        internal static readonly GUIContent ListenerLabelContent = new GUIContent(
            "Listeners",
            "Listeners added to this event"
        );

        #endregion

        #region Internal Event Styles

        private static GUIStyle descriptionLockStyle;
        private static GUIStyle descriptionHelpBoxStyle;
        private static GUIStyle descriptionStyle;
        private static GUIStyle listenerSubLabelStyle;

        internal static GUIStyle DescriptionLockStyle =>
            descriptionLockStyle ??= GUI.skin.GetStyle("IN LockButton");

        internal static GUIStyle DescriptionHelpBoxStyle =>
            descriptionHelpBoxStyle ??= new GUIStyle(EditorStyles.helpBox)
            {
                fontSize = EditorStyles.textField.fontSize,
                richText = true
            };

        internal static GUIStyle DescriptionStyle =>
            descriptionStyle ??= new GUIStyle(EditorStyles.textArea)
            {
                richText = true,
                wordWrap = true
            };

        internal static GUIStyle ListenerSubLabelStyle
        {
            get
            {
                if (listenerSubLabelStyle != null)
                {
                    return listenerSubLabelStyle;
                }

                var labelSkin = GUI.skin.label;
                listenerSubLabelStyle = new GUIStyle(labelSkin)
                {
                    fontSize = (int) (labelSkin.fontSize * 0.9f),
                    wordWrap = true
                };

                return listenerSubLabelStyle;
            }
        }

        #endregion

        #region Internal Script Creator Labels

        internal static readonly GUIContent IsUseMonoScriptLabel = new GUIContent(
            "Is Use Mono Script",
            "Should a MonoScript be used for gathering event argument type information?"
        );

        internal static readonly GUIContent EventArgScriptLabel = new GUIContent(
            "Event Argument Script",
            "Script which will be used as an argument for the custom event"
        );

        internal static readonly GUIContent EventArgNamespaceLabel = new GUIContent(
            "Event Argument Namespace",
            "Namespace of the event argument type"
        );

        internal static readonly GUIContent EventArgNameLabel = new GUIContent(
            "Event Argument Name",
            "Name of the event argument type"
        );

        internal static readonly GUIContent EventNamespaceLabel = new GUIContent(
            "Event Namespace",
            "Namespace used for the custom event script. Note that this namespace will also be " +
            "used to generate directories for the event asset script (e.g., namespace " +
            "MyScriptableEvents.Events will result in MyScriptableEvents/Events directory)"
        );

        internal static readonly GUIContent EventNameLabel = new GUIContent(
            "Event Name",
            "Name of the custom event script"
        );

        internal static readonly GUIContent EventMenuNameLabel = new GUIContent(
            "Event Menu Name",
            "Menu name of the custom event asset"
        );

        internal static readonly GUIContent EventMenuOrderLabel = new GUIContent(
            "Event Menu Order",
            "Menu order of the custom event asset"
        );

        internal static readonly GUIContent IsCreateListenerLabel = new GUIContent(
            "Is Create Listener",
            "Should a custom event listener script be generated?"
        );

        internal static readonly GUIContent ListenerNamespaceLabel = new GUIContent(
            "Listener Namespace",
            "Namespace used for the custom event listener script. Note that this namespace will " +
            "also be used to generate directories for the event listener script (e.g., namespace " +
            "MyScriptableEvents.Listeners will result in MyScriptableEvents/Listeners " +
            "directory)"
        );

        internal static readonly GUIContent ListenerNameLabel = new GUIContent(
            "Listener Name",
            "Name of the custom event listener script"
        );

        internal static readonly GUIContent ListenerMenuNameLabel = new GUIContent(
            "Listener Menu Name",
            "Menu name of the custom event listener component"
        );

        internal static readonly GUIContent ListenerMenuOrderLabel = new GUIContent(
            "Listener Menu Order",
            "Menu order of the custom event listener component"
        );

        internal static readonly GUIContent IsCreateEditorLabel = new GUIContent(
            "Is Create Editor",
            "Should a custom event editor script be generated?"
        );

        internal static readonly GUIContent EditorNamespaceLabel = new GUIContent(
            "Editor Namespace",
            "Namespace used for the custom event editor script. Note that this namespace will " +
            "also be used to generate directories for the event editor script (e.g., " +
            "namespace MyScriptableEvents.Editor will result in MyScriptableEvents/Editor " +
            "directory)"
        );

        internal static readonly GUIContent EditorNameLabel = new GUIContent(
            "Editor Name",
            "Name of the custom event editor script"
        );

        internal static readonly GUIContent ScriptDirectoryLabel = new GUIContent(
            "Output Directory",
            "Directory where to generate the scripts"
        );

        #endregion

        #region Internal Methods

        internal static bool Toggle(bool value, GUIContent label = null)
        {
            var safeLabel = GetSafeLabel(label);
            return EditorGUILayout.Toggle(safeLabel, value);
        }

        internal static int IntField(int value, GUIContent label = null)
        {
            var safeLabel = GetSafeLabel(label);

#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields.IntField(safeLabel, value);
#else
            return EditorGUILayout.IntField(safeLabel, value);
#endif
        }

        internal static string TextField(
            string value,
            GUIContent label = null,
            GUIStyle style = null
        )
        {
            var safeLabel = GetSafeLabel(label);

#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields.TextField(safeLabel, value, style);
#else
            return EditorGUILayout.TextField(safeLabel, value, style);
#endif
        }

        /// <summary>
        /// Draw a large (multi-line) text field.
        /// </summary>
        internal static string TextArea(string value, GUIStyle style = null)
        {
            return EditorGUILayout.TextArea(value, style);
        }

        internal static float FloatField(float value)
        {
#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields.FloatField(value);
#else
            return EditorGUILayout.FloatField(value);
#endif
        }

        internal static double DoubleField(double value)
        {
#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields.DoubleField(value);
#else
            return EditorGUILayout.DoubleField(value);
#endif
        }

        internal static long LongField(long value)
        {
#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields.LongField(value);
#else
            return EditorGUILayout.LongField(value);
#endif
        }

        internal static Vector2 Vector2Field(Vector2 value)
        {
#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields.Vector2Field(value);
#else
            return EditorGUILayout.Vector2Field(GUIContent.none, value);
#endif
        }

        internal static Vector3 Vector3Field(Vector3 value)
        {
#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields.Vector3Field(value);
#else
            return EditorGUILayout.Vector3Field(GUIContent.none, value);
#endif
        }

        /// <summary>
        /// Draw a <see cref="Quaternion"/> by using <see cref="Quaternion.eulerAngles"/>.
        /// </summary>
        internal static Quaternion QuaternionField(Quaternion value)
        {
            var angles = value.eulerAngles;
            var result = Vector3Field(angles);

            return Quaternion.Euler(result);
        }

        internal static Color ColorField(Color color)
        {
#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields.ColorField(color);
#else
            return EditorGUILayout.ColorField(color);
#endif
        }

        /// <summary>
        /// Draw a <see cref="MonoScript"/> which is usually seen at the top of mono scripts.
        /// </summary>
        internal static void MonoScriptField(MonoScript monoScript)
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField(MonoScriptLabel, monoScript, monoScript.GetClass(), false);
            GUI.enabled = true;
        }

        internal static T ObjectField<T>(
            T @object,
            GUIContent label = null,
            bool isAllowSceneObjects = false
        ) where T : Object
        {
            var safeLabel = GetSafeLabel(label);

#if ODIN_INSPECTOR
            var result = Sirenix.Utilities.Editor.SirenixEditorFields
                .UnityObjectField(safeLabel, @object, typeof(T), isAllowSceneObjects);
#else
            var result = EditorGUILayout.ObjectField(safeLabel, @object, typeof(T), false);
#endif
            return (T) result;
        }

        #endregion

        #region Private Methods

        private static GUIContent GetSafeLabel(GUIContent label)
        {
            if (label == null)
            {
                return GUIContent.none;
            }

            return label;
        }

        #endregion
    }
}
