using UnityEngine;

namespace ScriptableEvents.Collision
{
    [AddComponentMenu("Scriptable Events/Adapters/On Collision Exit Adapter", 4)]
    public class OnCollisionExitAdapter
        : BaseScriptableEventAdapter<CollisionScriptableEvent, UnityEngine.Collision>
    {
        #region Methods

        private void OnCollisionExit(UnityEngine.Collision other)
        {
            Raise(other);
        }

        #endregion
    }
}
