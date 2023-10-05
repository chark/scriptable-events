using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CHARK.ScriptableEvents.Editor
{
    /// <summary>
    /// Utilities to draw inspector GUIs in <see cref="ScriptableEventEditor{TArg}"/> and
    /// <see cref="ScriptableEventEditor"/>.
    /// </summary>
    internal static class ScriptableEventEditorGUI
    {
        #region Private Label Fields

        private static readonly GUIContent RaiseEventLabel = new GUIContent(
            "Raise Event",
            "Raise event and trigger all added listeners"
        );

        private static readonly GUIContent DescriptionLabel = new GUIContent(
            "Description",
            "Custom description to provide additional information"
        );

        private static readonly GUIContent ListenersLabel = new GUIContent(
            "Listeners",
            "Listeners added to this event"
        );

        #endregion

        #region Private Styles

        private static GUIStyle DescriptionLockStyle =>
            descriptionLockStyle ??= GetLockButtonStyle();

        private static GUIStyle descriptionLockStyle;

        private static GUIStyle DescriptionHelpBoxStyle =>
            descriptionHelpBoxStyle ??= GetDescriptionHelpBoxStyle();

        private static GUIStyle descriptionHelpBoxStyle;

        private static GUIStyle DescriptionStyle =>
            descriptionStyle ??= GetDescriptionStyle();

        private static GUIStyle descriptionStyle;

        private static GUIStyle ListenerSubLabelStyle =>
            listenerSubLabelStyle ??= GetListenerSubLabelStyle();

        private static GUIStyle listenerSubLabelStyle;

        #endregion

        #region Internal Drawing Methods

        /// <summary>
        /// Draw a button to raise an event or a listener.
        /// </summary>
        internal static void DrawRaiseButton(Action onClick)
        {
            if (GUILayout.Button("Raise"))
            {
                onClick.Invoke();
            }
        }

        /// <summary>
        /// Draw a header label which is placed above event actions.
        /// </summary>
        internal static void DrawRaiseEventLabel()
        {
            EditorGUILayout.LabelField(RaiseEventLabel);
        }

        /// <summary>
        /// Draw a header label for the description of the event.
        /// </summary>
        internal static void DrawDescriptionLabel()
        {
            EditorGUILayout.LabelField(DescriptionLabel);
        }

        /// <summary>
        /// Draw a tiny lock button which unlocks editing of the description.
        /// </summary>
        internal static bool DrawDescriptionLockButton(bool isLock)
        {
            var descriptionWidth = EditorStyles.label.CalcSize(DescriptionLabel).x;

            var position = GUILayoutUtility.GetLastRect();
            position.width = DescriptionLockStyle.fixedWidth;
            position.x = position.xMin + descriptionWidth;

            return EditorGUI.Toggle(position, GUIContent.none, isLock, DescriptionLockStyle);
        }

        /// <summary>
        /// Draw event description help box.
        /// </summary>
        internal static void DrawDescriptionHelpBox(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                EditorGUILayout.LabelField(
                    "Click the <b>lock</b> icon to add a description to this event asset",
                    DescriptionHelpBoxStyle
                );
                return;
            }

            EditorGUILayout.LabelField(description, DescriptionHelpBoxStyle);
        }

        /// <summary>
        /// Draw a large event description text area.
        /// </summary>
        internal static string DrawDescriptionTextArea(string value)
        {
            return ScriptableEventGUI.TextArea(value, DescriptionStyle);
        }

        /// <summary>
        /// Draw a header label for all listener info.
        /// </summary>
        internal static void DrawListenersLabel()
        {
            EditorGUILayout.LabelField(ListenersLabel);
        }

        /// <summary>
        /// Draw information on the number of added listener fields.
        /// </summary>
        internal static void DrawListenerStats(
            int totalListenerCount,
            IEnumerable<object> listeners
        )
        {
            if (totalListenerCount == 0)
            {
                EditorGUILayout.HelpBox(
                    "There are no listeners added to this event",
                    MessageType.Info
                );

                return;
            }

            GetListenerCounts(listeners, out var objectCount, out var otherCount);

            EditorGUILayout.LabelField(
                $"Event contains {objectCount} {nameof(Object)} listeners and " +
                $"{otherCount} other listeners",
                ListenerSubLabelStyle
            );
        }

        /// <summary>
        /// Draw a readonly listener object field which can be selected with the cursor.
        /// </summary>
        internal static void DrawListenerObject(Object obj)
        {
            ScriptableEventGUI.ObjectField(obj);
        }

        /// <summary>
        /// Draw a readonly listener name field which can be selected with the cursor.
        /// </summary>
        internal static void DrawListenerName(string name)
        {
            var height = GUILayout.Height(EditorGUIUtility.singleLineHeight);
            EditorGUILayout.SelectableLabel(name, EditorStyles.textField, height);
        }

        #endregion

        #region Private Methods

        private static GUIStyle GetLockButtonStyle()
        {
            return GUI.skin.GetStyle("IN LockButton");
        }

        private static GUIStyle GetDescriptionHelpBoxStyle()
        {
            return new GUIStyle(EditorStyles.helpBox)
            {
                fontSize = EditorStyles.textField.fontSize,
                richText = true
            };
        }

        private static GUIStyle GetDescriptionStyle()
        {
            return new GUIStyle(EditorStyles.textArea)
            {
                richText = true,
                wordWrap = true
            };
        }

        private static GUIStyle GetListenerSubLabelStyle()
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

        private static void GetListenerCounts(
            IEnumerable<object> listeners,
            out int objectListenerCount,
            out int otherListenerCount
        )
        {
            objectListenerCount = 0;
            otherListenerCount = 0;

            foreach (var listener in listeners)
            {
                if (listener is Object)
                {
                    objectListenerCount++;
                }
                else
                {
                    otherListenerCount++;
                }
            }
        }

        #endregion
    }
}
