using UnityEngine;

namespace MutableObjects.Generic
{
    public abstract class MutableObject : ScriptableObject, IMutableObject
    {
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
