using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Base editor for Scriptable Events with an argument. This is used when explicitly defining
    /// an editor for an event.
    /// </summary>
    /// <typeparam name="TArg">
    /// Event argument type
    /// </typeparam>
    public abstract class BaseScriptableEventEditor<TArg> : BaseScriptableEventEditor
    {
        #region Private Fields

        private ScriptableEvent<TArg> scriptableEvent;
        private TArg argValue;

        #endregion

        #region Unity Lifecycle

        internal override void SetupEditor()
        {
            base.SetupEditor();

            scriptableEvent = target as ScriptableEvent<TArg>;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Draw event argument inspector GUI.
        /// </summary>
        /// <param name="value">
        /// Current event argument value, can be <c>null</c>
        /// </param>
        /// <returns>
        /// Updated event argument value
        /// </returns>
        protected abstract TArg DrawArgField(TArg value);

        #endregion

        #region Internal Methods

        internal override void OnDrawProperties()
        {
            base.OnDrawProperties();

            EditorGUILayout.Space();
            DrawRaiseEvent();
        }

        internal override void OnDrawListeners()
        {
            EditorGUILayout.BeginVertical();
            base.OnDrawListeners();
            EditorGUILayout.EndVertical();
        }

        internal override void OnDrawListener(object listener, int listenerIndex)
        {
            EditorGUILayout.BeginHorizontal();
            base.OnDrawListener(listener, listenerIndex);
            DrawRaiseListener(listenerIndex);
            EditorGUILayout.EndHorizontal();
        }

        #endregion

        #region Private Methods

        private void DrawRaiseEvent()
        {
            ScriptableEventEditorGUI.DrawRaiseEventLabel();
            GUI.enabled = scriptableEvent.ListenerCount > 0;

            GUILayout.BeginHorizontal();

            argValue = DrawArgField(argValue);
            ScriptableEventEditorGUI.DrawRaiseButton(() =>
                scriptableEvent.Raise(argValue)
            );

            GUILayout.EndHorizontal();
            GUI.enabled = true;
        }

        private void DrawRaiseListener(int listenerIndex)
        {
            ScriptableEventEditorGUI.DrawRaiseButton(() =>
                scriptableEvent.Raise(argValue, listenerIndex)
            );
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
            ScriptableEventEditorGUI.DrawListenersLabel();
            ScriptableEventEditorGUI.DrawListenerStats(
                baseScriptableEvent.ListenerCount,
                baseScriptableEvent.Listeners
            );

            OnDrawListeners();

#if ODIN_INSPECTOR
            Tree.EndDraw();
#endif
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Setup inspector before rendering (called once).
        /// </summary>
        internal virtual void SetupEditor()
        {
            SetupBaseScriptableEvent();
            SetupMonoScript();
            SetupSerializedProperties();
        }

        /// <summary>
        /// Draw Scriptable Event serialized properties.
        /// </summary>
        internal virtual void OnDrawProperties()
        {
            DrawDescriptionLabel();
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
        /// Draw all listeners added to the inspected event.
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
        /// Draw a single listener field.
        /// </summary>
        internal virtual void OnDrawListener(object listener, int listenerIndex)
        {
            if (listener is Object listenerObject)
            {
                ScriptableEventEditorGUI.DrawListenerObject(listenerObject);
            }
            else
            {
                var listenerName = listener.ToString();
                ScriptableEventEditorGUI.DrawListenerName(listenerName);
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

        #region Private Drawing Methods

        private void DrawMonoScript()
        {
            ScriptableEventGUI.MonoScriptField(monoScript);
        }

        private static void DrawDescriptionLabel()
        {
            ScriptableEventEditorGUI.DrawDescriptionLabel();
        }

        private void DrawDescriptionLockButton()
        {
            isLockDescription = ScriptableEventEditorGUI
                .DrawDescriptionLockButton(isLockDescription);
        }

        private void DrawDescriptionHelpBox()
        {
#if ODIN_INSPECTOR
            var description = descriptionProperty.ValueEntry.WeakSmartValue as string;
#else
            var description = descriptionProperty.stringValue;
#endif
            ScriptableEventEditorGUI.DrawDescriptionHelpBox(description);
        }

        private void DrawDescriptionTextArea()
        {
#if ODIN_INSPECTOR
            var value = descriptionProperty.ValueEntry.WeakSmartValue as string;
            value = ScriptableEventEditorGUI.DrawDescriptionTextArea(value);
            descriptionProperty.ValueEntry.WeakSmartValue = value;
#else
            var value = descriptionProperty.stringValue;
            value = ScriptableEventEditorGUI.DrawDescriptionTextArea(value);
            descriptionProperty.stringValue = value;
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

        #endregion
    }
}
