using MutableObjects.Generic;
using UnityEngine;

namespace MutableObjects.Vector2
{
    [CreateAssetMenu(fileName = "MutableVector2", menuName = "Mutable Objects/Mutable Vector2")]
    public class MutableVector2 : MutableObject
    {
        [SerializeField]
        private UnityEngine.Vector2 value = default;

        public UnityEngine.Vector2 Value { get; set; }

        public override void ResetValues()
        {
            Value = value;
        }
    }
}
