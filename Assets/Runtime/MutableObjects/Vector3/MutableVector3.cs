using MutableObjects.Generic;
using UnityEngine;

namespace MutableObjects.Vector3
{
    [CreateAssetMenu(fileName = "MutableVector3", menuName = "Mutable Objects/Mutable Vector3")]
    public class MutableVector3 : MutableObject
    {
        [SerializeField]
        private UnityEngine.Vector3 value = default;

        public UnityEngine.Vector3 Value { get; set; }

        public override void ResetValues()
        {
            Value = value;
        }
    }
}
