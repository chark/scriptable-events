using UnityEngine;

namespace MutableObjects.Generic
{
    public abstract class MutableObject : ScriptableObject, IMutableObject
    {
        [SerializeField]
        [Tooltip("Should this mutable object be persisted throughout scene loads")]
        private bool persisting = false;

        public bool Persisting => persisting;

        public abstract void ResetValues();

        private void OnValidate()
        {
            ResetValues();
        }

        private void OnEnable()
        {
            ResetValues();
        }
    }
}
