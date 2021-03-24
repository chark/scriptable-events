using UnityEngine;

namespace ScriptableEvents.Collision
{
    [AddComponentMenu("Scriptable Events/Adapters/On Collision Enter Adapter", 3)]
    public class OnCollisionEnterAdapter
        : BaseScriptableEventAdapter<CollisionScriptableEvent, UnityEngine.Collision>
    {
        #region Methods

        private void OnCollisionEnter(UnityEngine.Collision other)
        {
            Raise(other);
        }

        #endregion
    }
}
