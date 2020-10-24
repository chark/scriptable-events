using UnityEngine;

namespace MutableObjects.Generic
{
    public abstract class MutableObject : ScriptableObject, IMutableObject
    {
        [SerializeField]
        [Tooltip("When reset should be called for this object")]
        private ResetType resetType = ResetType.None;

        public ResetType ResetType => resetType;

        public abstract void ResetValues();

        protected virtual void OnValidate()
        {
            ResetValues();
        }

        protected virtual void OnEnable()
        {
            ResetValues();
        }
    }
}
