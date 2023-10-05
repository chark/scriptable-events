using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CHARK.ScriptableEvents.Editor
{
    /// <summary>
    /// General utilities to draw inspector GUIs.
    /// </summary>
    internal static class ScriptableEventGUI
    {
        #region Private Label Labels

        private static readonly GUIContent MonoScriptLabel = new GUIContent("Script");

        #endregion

        #region Private Style Properties

        private static GUIStyle GroupStyle => groupStyle ??= GetGroupStyle();
        private static GUIStyle groupStyle;

        #endregion

        #region Internal Drawing Methods

        /// <summary>
        /// Wrap the given <see cref="onDraw"/> with a scroll bar.
        /// </summary>
        internal static Vector2 Scroll(Vector2 position, Action onDraw)
        {
            position = GUILayout.BeginScrollView(position);
            onDraw.Invoke();
            GUILayout.EndScrollView();

            return position;
        }

        /// <summary>
        /// Wrap the given <see cref="onDraw"/> action with a "group box" (pretty background).
        /// </summary>
        internal static void Group(Action onDraw)
        {
            GUILayout.BeginVertical(GroupStyle);
            onDraw.Invoke();
            GUILayout.EndVertical();
        }

        /// <summary>
        /// Draw a configurable toggle field for a <see cref="bool"/> type.
        /// </summary>
        internal static bool Toggle(
            bool value,
            GUIContent label = null,
            bool isBold = false,
            bool isLeft = false
        )
        {
            if (isBold)
            {
                var originalFontStyle = EditorStyles.label.fontStyle;
                EditorStyles.label.fontStyle = FontStyle.Bold;

                var isToggled = DoToggle(value, label, isLeft);

                EditorStyles.label.fontStyle = originalFontStyle;

                return isToggled;
            }

            return DoToggle(value, label, isLeft);
        }

        /// <summary>
        /// Draw an <see cref="int"/> field.
        /// </summary>
        internal static int IntField(int value, GUIContent label = null)
        {
            var safeLabel = label ?? GUIContent.none;

#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields.IntField(safeLabel, value);
#else
            return EditorGUILayout.IntField(safeLabel, value);
#endif
        }

        /// <summary>
        /// Draw a regular <see cref="string"/> field.
        /// </summary>
        internal static string TextField(
            string value,
            GUIContent label = null,
            GUIStyle style = null
        )
        {
            var safeLabel = label ?? GUIContent.none;
            var safeStyle = style ?? EditorStyles.textField;

#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields
                .TextField(safeLabel, value, safeStyle);
#else
            return EditorGUILayout.TextField(safeLabel, value, safeStyle);
#endif
        }

        /// <summary>
        /// Draw a large <see cref="string"/> field (multi-row).
        /// </summary>
        internal static string TextArea(string value, GUIStyle style = null)
        {
            var safeStyle = style ?? EditorStyles.textArea;
            return EditorGUILayout.TextArea(value, safeStyle);
        }

        /// <summary>
        /// Draw a <see cref="float"/> field.
        /// </summary>
        internal static float FloatField(float value)
        {
#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields.FloatField(value);
#else
            return EditorGUILayout.FloatField(value);
#endif
        }

        /// <summary>
        /// Draw a <see cref="double"/> field.
        /// </summary>
        internal static double DoubleField(double value)
        {
#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields.DoubleField(value);
#else
            return EditorGUILayout.DoubleField(value);
#endif
        }

        /// <summary>
        /// Draw a <see cref="long"/> field.
        /// </summary>
        internal static long LongField(long value)
        {
#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields.LongField(value);
#else
            return EditorGUILayout.LongField(value);
#endif
        }

        /// <summary>
        /// Draw a <see cref="Vector2"/> field (each component gets an input).
        /// </summary>
        internal static Vector2 Vector2Field(Vector2 value)
        {
#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields.Vector2Field(value);
#else
            return EditorGUILayout.Vector2Field(GUIContent.none, value);
#endif
        }

        /// <summary>
        /// Draw a <see cref="Vector3"/> field (each component gets an input).
        /// </summary>
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

        /// <summary>
        /// Draw a <see cref="Color"/> field.
        /// </summary>
        internal static Color ColorField(Color color)
        {
#if ODIN_INSPECTOR
            return Sirenix.Utilities.Editor.SirenixEditorFields.ColorField(color);
#else
            return EditorGUILayout.ColorField(color);
#endif
        }

        /// <summary>
        /// Draw a <see cref="MonoScript"/> field which is usually seen at the top of mono scripts.
        /// </summary>
        internal static void MonoScriptField(MonoScript monoScript)
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField(MonoScriptLabel, monoScript, monoScript.GetClass(), false);
            GUI.enabled = true;
        }

        /// <summary>
        /// Draw a generic <see cref="Object"/> field.
        /// </summary>
        internal static T ObjectField<T>(
            T @object,
            GUIContent label = null,
            bool isAllowSceneObjects = false
        ) where T : Object
        {
            var safeLabel = label ?? GUIContent.none;

#if ODIN_INSPECTOR
            var result = Sirenix.Utilities.Editor.SirenixEditorFields
                .UnityObjectField(safeLabel, @object, typeof(T), isAllowSceneObjects);
#else
            var result = EditorGUILayout
                .ObjectField(safeLabel, @object, typeof(T), isAllowSceneObjects);
#endif
            return (T) result;
        }

        #endregion

        #region Private Methods

        private static GUIStyle GetGroupStyle()
        {
            return GUI.skin.GetStyle("HelpBox");
        }

        private static bool DoToggle(bool value, GUIContent label, bool isLeft)
        {
            var safeLabel = label ?? GUIContent.none;

            if (isLeft)
            {
                return EditorGUILayout.ToggleLeft(safeLabel, value);
            }

            return EditorGUILayout.Toggle(safeLabel, value);
        }

        #endregion
    }
}
