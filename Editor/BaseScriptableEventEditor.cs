using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Base editor for Scriptable Events with an argument. This is used when explicitly defining
    /// an editor for an event.
    /// </summary>
    /// <typeparam name="TArg"></typeparam>
    public abstract class BaseScriptableEventEditor<TArg> : BaseScriptableEventEditor
    {
        #region Private Fields

        private BaseScriptableEvent<TArg> scriptableEvent;
        private TArg argValue;

        #endregion

        #region Unity Lifecycle

        internal override void SetupEditor()
        {
            base.SetupEditor();

            scriptableEvent = target as BaseScriptableEvent<TArg>;
        }

        #endregion

        #region Protected Methods

        protected abstract TArg DrawArgField(TArg value);

        #endregion

        #region Internal Methods

        internal override void OnDrawProperties()
        {
            base.OnDrawProperties();

            EditorGUILayout.Space();
            DrawEventRaise();
        }

        internal override void OnDrawListeners()
        {
            EditorGUILayout.BeginHorizontal();
            base.OnDrawListeners();
            EditorGUILayout.EndHorizontal();
        }

        internal override void OnDrawListener(object listener, int listenerIndex)
        {
            base.OnDrawListener(listener, listenerIndex);
            DrawListenerRaise(listenerIndex);
        }

        #endregion

        #region Private Methods

        private void DrawListenerRaise(int listenerIndex)
        {
            if (GUILayout.Button("Raise"))
            {
                scriptableEvent.Raise(argValue, listenerIndex);
            }
        }

        private void DrawEventRaise()
        {
            EditorGUILayout.LabelField(ScriptableEventGUI.RaiseEventLabel);
            GUI.enabled = scriptableEvent.ListenerCount > 0;

            GUILayout.BeginHorizontal();

            argValue = DrawArgField(argValue);
            if (GUILayout.Button("Raise"))
            {
                scriptableEvent.Raise(argValue);
            }

            GUILayout.EndHorizontal();
            GUI.enabled = true;
        }

        #endregion
    }

    /// <summary>
    /// Base editor for all Scriptable Events.
    /// </summary>
    [CanEditMultipleObjects]
    public abstract class BaseScriptableEventEditor
#if ODIN_INSPECTOR
        : Sirenix.OdinInspector.Editor.OdinEditor
#else
        : UnityEditor.Editor
#endif
    {
        #region Private Fields

        // Target scriptable event fields.
        private BaseScriptableEvent baseScriptableEvent;
        private MonoScript monoScript;

        // Serialized properties.
#if ODIN_INSPECTOR
        private Sirenix.OdinInspector.Editor.InspectorProperty descriptionProperty;
        private Sirenix.OdinInspector.Editor.InspectorProperty isSuppressExceptionsProperty;
        private Sirenix.OdinInspector.Editor.InspectorProperty isDebugProperty;
#else
        private SerializedProperty descriptionProperty;
        private SerializedProperty isSuppressExceptionsProperty;
        private SerializedProperty isDebugProperty;
#endif

        private bool isLockDescription = true;

        #endregion

        #region Unity Lifecycle

#if ODIN_INSPECTOR
        protected override void OnEnable()
        {
            base.OnEnable();
#else
        protected void OnEnable()
        {
#endif
            SetupEditor();
        }

        public override void OnInspectorGUI()
        {
            DrawMonoScript();

#if ODIN_INSPECTOR
            Tree.BeginDraw(true);
#else
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
#endif

            OnDrawProperties();

#if !ODIN_INSPECTOR
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
#endif

            EditorGUILayout.Space();
            DrawListenerLabel();
            DrawListenerStats();
            OnDrawListeners();

#if ODIN_INSPECTOR
            Tree.EndDraw();
#endif
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Setup GUI content for the custom editor before drawing.
        /// </summary>
        internal virtual void SetupEditor()
        {
            SetupBaseScriptableEvent();
            SetupMonoScript();
            SetupSerializedProperties();
        }

        /// <summary>
        /// Draws serialized properties of the Scriptable Event.
        /// </summary>
        internal virtual void OnDrawProperties()
        {
            EditorGUILayout.LabelField(ScriptableEventGUI.DescriptionLabelContent);
            DrawDescriptionLockButton();

            if (isLockDescription)
            {
                DrawDescriptionHelpBox();
            }
            else
            {
                DrawDescriptionTextArea();
            }

            EditorGUILayout.Space();
            DrawIsSuppressExceptions();
            DrawIsDebug();
        }

        /// <summary>
        /// Draws all added to the inspected event.
        /// </summary>
        internal virtual void OnDrawListeners()
        {
            var listenerIndex = 0;
            foreach (var listener in baseScriptableEvent.Listeners)
            {
                OnDrawListener(listener, listenerIndex);
                listenerIndex++;
            }
        }

        /// <summary>
        /// Draws a single listener field.
        /// </summary>
        internal virtual void OnDrawListener(object listener, int listenerIndex)
        {
            if (listener is Object listenerObject)
            {
                DrawListenerObject(listenerObject);
            }
            else
            {
                var listenerName = listener.ToString();
                DrawListenerName(listenerName);
            }
        }

        #endregion

        #region Private Setup Methods

        private void SetupBaseScriptableEvent()
        {
            baseScriptableEvent = target as BaseScriptableEvent;
        }

        private void SetupMonoScript()
        {
            monoScript = MonoScript.FromScriptableObject(baseScriptableEvent);
        }

        private void SetupSerializedProperties()
        {
#if ODIN_INSPECTOR
            descriptionProperty = Tree.GetPropertyAtPath("description");
            isSuppressExceptionsProperty = Tree.GetPropertyAtPath("isSuppressExceptions");
            isDebugProperty = Tree.GetPropertyAtPath("isDebug");
#else
            descriptionProperty = serializedObject.FindProperty("description");
            isSuppressExceptionsProperty = serializedObject.FindProperty("isSuppressExceptions");
            isDebugProperty = serializedObject.FindProperty("isDebug");
#endif
        }

        #endregion

        #region Private Draw Methods

        private void DrawMonoScript()
        {
            ScriptableEventGUI.MonoScriptField(monoScript);
        }

        private void DrawDescriptionLockButton()
        {
            var descriptionWidth = EditorStyles.label
                .CalcSize(ScriptableEventGUI.DescriptionLabelContent).x;

            var position = GUILayoutUtility.GetLastRect();
            position.width = ScriptableEventGUI.DescriptionLockStyle.fixedWidth;
            position.x = position.xMin + descriptionWidth;

            isLockDescription = EditorGUI.Toggle(
                position,
                GUIContent.none,
                isLockDescription,
                ScriptableEventGUI.DescriptionLockStyle
            );
        }

        private void DrawDescriptionHelpBox()
        {
#if ODIN_INSPECTOR
            var description = descriptionProperty.ValueEntry.WeakSmartValue as string;
#else
            var description = descriptionProperty.stringValue;
#endif
            if (string.IsNullOrWhiteSpace(description))
            {
                EditorGUILayout.LabelField(
                    "Click the <b>lock</b> icon to add a description to this event asset",
                    ScriptableEventGUI.DescriptionHelpBoxStyle
                );
                return;
            }

            EditorGUILayout.LabelField(description, ScriptableEventGUI.DescriptionHelpBoxStyle);
        }

        private void DrawDescriptionTextArea()
        {
#if ODIN_INSPECTOR
            descriptionProperty.ValueEntry.WeakSmartValue =
                ScriptableEventGUI.TextArea(
                    descriptionProperty.ValueEntry.WeakSmartValue as string,
                    ScriptableEventGUI.DescriptionStyle
                );
#else
            descriptionProperty.stringValue = ScriptableEventGUI.TextArea(
                descriptionProperty.stringValue,
                descriptionStyle
            );
#endif
        }

        private void DrawIsSuppressExceptions()
        {
#if ODIN_INSPECTOR
            isSuppressExceptionsProperty.Draw();
#else
            EditorGUILayout.PropertyField(isSuppressExceptionsProperty);
#endif
        }

        private void DrawIsDebug()
        {
#if ODIN_INSPECTOR
            isDebugProperty.Draw();
#else
            EditorGUILayout.PropertyField(isDebugProperty);
#endif
        }

        private static void DrawListenerLabel()
        {
            EditorGUILayout.LabelField(ScriptableEventGUI.ListenerLabelContent);
        }

        private void DrawListenerStats()
        {
            if (baseScriptableEvent.ListenerCount == 0)
            {
                EditorGUILayout.HelpBox(
                    "There are no listeners added to this event",
                    MessageType.Info
                );

                return;
            }

            GetListenerCounts(out var objectListenerCount, out var otherListenerCount);

            EditorGUILayout.LabelField(
                $"Event contains {objectListenerCount} UnityEngine.Object listeners and " +
                $"{otherListenerCount} other listeners",
                ScriptableEventGUI.ListenerSubLabelStyle
            );
        }

        private static void DrawListenerObject(Object listenerObject)
        {
            ScriptableEventGUI.ObjectField(listenerObject);
        }

        private static void DrawListenerName(string listenerName)
        {
            var height = GUILayout.Height(EditorGUIUtility.singleLineHeight);
            EditorGUILayout.SelectableLabel(
                listenerName,
                EditorStyles.textField,
                height
            );
        }

        #endregion

        #region Private Utility Methods

        private void GetListenerCounts(out int objectListenerCount, out int otherListenerCount)
        {
            objectListenerCount = 0;
            otherListenerCount = 0;

            foreach (var listener in baseScriptableEvent.Listeners)
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
