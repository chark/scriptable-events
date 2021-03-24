using UnityEngine;

namespace ScriptableEvents
{
    public abstract class BaseScriptableEventAdapter<TScriptableEvent, TArg> : MonoBehaviour
        where TScriptableEvent : BaseScriptableEvent<TArg>
    {
        #region Editor

        [SerializeField]
        private TScriptableEvent scriptableEvent;

        #endregion

        #region Methods

        protected void Raise(TArg arg)
        {
            if (scriptableEvent == null)
            {
                return;
            }

            scriptableEvent.Raise(arg);
        }

        #endregion
    }
}
