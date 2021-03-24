using System;
using UnityEngine;

namespace ScriptableEvents.Collider
{
    [AddComponentMenu("Scriptable Events/Adapters/On Trigger Exit Adapter", 2)]
    public class OnTriggerExitAdapter
        : BaseScriptableEventAdapter<ColliderScriptableEvent, UnityEngine.Collider>
    {
        #region Methods

        private void OnTriggerExit(UnityEngine.Collider other)
        {
            Raise(other);
        }

        #endregion
    }
}
