using UnityEngine;

namespace ScriptableEvents.Collider
{
    [AddComponentMenu("Scriptable Events/Adapters/On Trigger Enter Adapter", 1)]
    public class OnTriggerEnterAdapter
        : BaseScriptableEventAdapter<ColliderScriptableEvent, UnityEngine.Collider>
    {
        #region Methods

        private void OnTriggerEnter(UnityEngine.Collider other)
        {
            Raise(other);
        }

        #endregion
    }
}
