using MutableObjects.Generic;
using UnityEngine;

namespace MutableObjects.Float
{
    [CreateAssetMenu(fileName = "MutableFloat", menuName = "Mutable Objects/Mutable Float")]
    public class MutableFloat : MutableObject
    {
        [SerializeField]
        private float value = default;

        public float Value { get; set; }

        public override void ResetValues()
        {
            Value = value;
        }
    }
}
