using UnityEngine;

namespace ScriptableEvents.SimpleEvents
{
    [RequireComponent(typeof(MeshRenderer))]
    public class MaterialColorChanger : MonoBehaviour
    {
        private Material material;

        private void Awake()
        {
            material = GetComponent<MeshRenderer>().material;
        }

        public void ChangeColor(float value)
        {
            var color = material.color;
            color.r = value;
            color.g = value;
            color.b = value;
            material.color = color;
        }
    }
}
