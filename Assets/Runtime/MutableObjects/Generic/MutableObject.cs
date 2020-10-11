using UnityEngine;

namespace MutableObjects.Generic
{
    public abstract class MutableObject : ScriptableObject, IMutableObject
    {
        [SerializeField]
        [Tooltip("When reset should be called for this object")]
        private ResetType resetType = ResetType.ActiveSceneChange;

        public ResetType ResetType => resetType;

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
