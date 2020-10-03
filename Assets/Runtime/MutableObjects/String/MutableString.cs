using MutableObjects.Generic;
using UnityEngine;

namespace MutableObjects.String
{
    [CreateAssetMenu(fileName = "MutableString", menuName = "Mutable Objects/Mutable String")]
    public class MutableString : MutableObject
    {
        [SerializeField]
        private string value = default;

        public string Value { get; set; }

        public override void ResetValues()
        {
            Value = value;
        }
    }
}
