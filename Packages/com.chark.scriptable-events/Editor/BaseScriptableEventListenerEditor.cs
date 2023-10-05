using UnityEditor;

namespace CHARK.ScriptableEvents.Editor
{
    /// <summary>
    /// Default editor for Scriptable Event Listeners which don't an explicit editor.
    /// </summary>
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ScriptableEventListener), true)]
    internal class BaseScriptableEventListenerEditor
#if ODIN_INSPECTOR
        : Sirenix.OdinInspector.Editor.OdinEditor
#else
        : UnityEditor.Editor
#endif
    {
        #region Private Fields

        // Target scriptable event listener fields.
        private ScriptableEventListener scriptableEventListener;
        private MonoScript monoScript;

        // Serialized properties.
#if ODIN_INSPECTOR
        private Sirenix.OdinInspector.Editor.InspectorProperty scriptableEventsProperty;
        private Sirenix.OdinInspector.Editor.InspectorProperty onRaisedProperty;
#else
        private SerializedProperty scriptableEventsProperty;
        private SerializedProperty onRaisedProperty;
#endif

        #endregion

        #region Unity Lifecycle

#if ODIN_INSPECTOR
        protected override void OnEnable()
        {
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

            DrawScriptableEvents();
            DrawOnRaised();

#if ODIN_INSPECTOR
            Tree.EndDraw();
#else
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
#endif
        }

        #endregion

        #region Private Setup Methods

        private void SetupEditor()
        {
            SetupBaseScriptableEventsListener();
            SetupMonoScript();
            SetupSerializedProperties();
        }

        private void SetupBaseScriptableEventsListener()
        {
            scriptableEventListener = target as ScriptableEventListener;
        }

        private void SetupMonoScript()
        {
            monoScript = MonoScript.FromMonoBehaviour(scriptableEventListener);
        }

        private void SetupSerializedProperties()
        {
#if ODIN_INSPECTOR
            scriptableEventsProperty = Tree.GetPropertyAtPath("scriptableEvents");
            onRaisedProperty = Tree.GetPropertyAtPath("onRaised");
#else
            scriptableEventsProperty = serializedObject.FindProperty("scriptableEvents");
            onRaisedProperty = serializedObject.FindProperty("onRaised");
#endif
        }

        #endregion

        #region Private Draw Methods

        private void DrawMonoScript()
        {
            ScriptableEventGUI.MonoScriptField(monoScript);
        }

        private void DrawScriptableEvents()
        {
#if ODIN_INSPECTOR
            scriptableEventsProperty.Draw();
#else
            EditorGUILayout.PropertyField(scriptableEventsProperty);
#endif
        }

        private void DrawOnRaised()
        {
#if ODIN_INSPECTOR
            onRaisedProperty.Draw();
#else
            EditorGUILayout.PropertyField(onRaisedProperty);
#endif
        }

        #endregion
    }
}
