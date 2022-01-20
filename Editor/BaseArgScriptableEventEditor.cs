using UnityEditor;
using UnityEngine;

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
                "Raise event and trigger added listeners"
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
            base.DrawAdditionalProperties();

            EditorGUILayout.Space();
            DrawRaise();
        }

        internal override void DrawListener(object listener, int listenerIndex)
        {
            base.DrawListener(listener, listenerIndex);

            if (GUILayout.Button("Raise"))
            {
                scriptableEvent.Raise(argValue, listenerIndex);
            }
        }

        #endregion

        #region Private Methods

        private void DrawRaise()
        {
            EditorGUILayout.LabelField(raiseLabelContent);
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
}
