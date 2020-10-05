using MutableObjects.Generic;
using UnityEngine;

namespace MutableObjects.Bool
{
    [CreateAssetMenu(fileName = "MutableBool", menuName = "Mutable Objects/Mutable Bool")]
    public class MutableBool : MutableObject
    {
        [SerializeField]
        private bool value = default;

        public bool Value { get; set; }

        public override void ResetValues()
        {
            Value = value;
        }
    }
}
