using UnityEngine;

namespace ScriptableEvents.SimpleEvents
{
    [RequireComponent(typeof(MeshRenderer))]
    public class MaterialColorToggle : MonoBehaviour
    {
        private Material material;

        private void Awake()
        {
            material = GetComponent<MeshRenderer>().material;
        }

        public void ToggleColor()
        {
            var color = material.color;
            material.color = color == Color.black
                ? Color.white
                : Color.black;
        }
    }
}
