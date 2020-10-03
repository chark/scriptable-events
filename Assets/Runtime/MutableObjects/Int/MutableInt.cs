using MutableObjects.Generic;
using UnityEngine;

namespace MutableObjects.Int
{
    [CreateAssetMenu(fileName = "MutableInt", menuName = "Mutable Objects/Mutable Int")]
    public class MutableInt : MutableObject
    {
        [SerializeField]
        private int value = default;

        public int Value { get; set; }

        public override void ResetValues()
        {
            Value = value;
        }
    }
}
