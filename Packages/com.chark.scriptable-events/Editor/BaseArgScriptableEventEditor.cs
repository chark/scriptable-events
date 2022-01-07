using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Base editor for scriptable events with an argument. This is used when explicitly defining
    /// an editor for an event.
    /// </summary>
    /// <typeparam name="TArg"></typeparam>
    public abstract class BaseScriptableEventEditor<TArg> : BaseScriptableEventEditor
    {
        #region Fields

        private GUIContent raiseLabelContent;

        private BaseScriptableEvent<TArg> scriptableEvent;
        private TArg argValue;

        #endregion

        #region Unity Lifecycle

        internal override void OnEnable()
        {
            base.OnEnable();

            raiseLabelContent = new GUIContent(
                "Raise Event",
                "Raise event and trigger added listeners (play mode only)"
            );

            scriptableEvent = target as BaseScriptableEvent<TArg>;
        }

        #endregion

        #region Protected Methods

        protected abstract TArg DrawArgField(TArg value);

        #endregion

        #region Internal Methods

        internal override void DrawAdditionalProperties()
        {
            EditorGUILayout.Space();
            DrawRaise();
        }

        #endregion

        #region Private Methods

        private void DrawRaise()
        {
            EditorGUILayout.LabelField(raiseLabelContent);
            GUI.enabled = Application.isPlaying;

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
}
