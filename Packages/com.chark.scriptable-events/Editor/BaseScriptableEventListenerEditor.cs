using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Default editor for Scriptable Event Listeners which don't an explicit editor.
    /// </summary>
    [CanEditMultipleObjects]
    [CustomEditor(typeof(BaseScriptableEventListener), true)]
    internal class BaseScriptableEventListenerEditor
#if ODIN_INSPECTOR
        : Sirenix.OdinInspector.Editor.OdinEditor
#else
        : UnityEditor.Editor
#endif
    {
        #region Private Fields

        // Target scriptable event listener fields.
        private BaseScriptableEventListener baseScriptableEventListener;
        private MonoScript monoScript;

        // Serialized properties.
#if ODIN_INSPECTOR
        private Sirenix.OdinInspector.Editor.InspectorProperty scriptableEventProperty;
        private Sirenix.OdinInspector.Editor.InspectorProperty onRaisedProperty;
#else
        private SerializedProperty scriptableEventProperty;
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

            EditorGUILayout.BeginHorizontal();
            DrawScriptableEvent();

            // d_Search Icon
            var icon = EditorGUIUtility.IconContent("Search Icon");
            if (GUILayout.Button(new GUIContent(icon), EditorStyles.miniButton, GUILayout.Width(30f)))
            {
                ShowSearchWindow();
            }

            EditorGUILayout.EndHorizontal();

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
            SetupBaseScriptableEventListener();
            SetupMonoScript();
            SetupSerializedProperties();
        }

        private void SetupBaseScriptableEventListener()
        {
            baseScriptableEventListener = target as BaseScriptableEventListener;
        }

        private void SetupMonoScript()
        {
            monoScript = MonoScript.FromMonoBehaviour(baseScriptableEventListener);
        }

        private void SetupSerializedProperties()
        {
#if ODIN_INSPECTOR
            scriptableEventProperty = Tree.GetPropertyAtPath("scriptableEvent");
            onRaisedProperty = Tree.GetPropertyAtPath("onRaised");
#else
            scriptableEventProperty = serializedObject.FindProperty("scriptableEvent");
            onRaisedProperty = serializedObject.FindProperty("onRaised");
#endif
        }

        #endregion

        #region Private Draw Methods

        private void DrawMonoScript()
        {
            ScriptableEventGUI.MonoScriptField(monoScript);
        }

        private void DrawScriptableEvent()
        {
#if ODIN_INSPECTOR
            scriptableEventProperty.Draw();
#else
            EditorGUILayout.PropertyField(scriptableEventProperty);
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

        #region Private Methods

        private void ShowSearchWindow()
        {
            ScriptableEventSearchWindowProvider.SearchListenerEvent(
                target.GetType(),
                eventAsset =>
                {
                    scriptableEventProperty.objectReferenceValue = eventAsset;
                    serializedObject.ApplyModifiedProperties();
                }
            );
        }

        #endregion
    }
}
