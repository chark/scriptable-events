using UnityEngine;

namespace ScriptableEvents.EventsWithArguments
{
    [RequireComponent(typeof(MeshRenderer))]
    public class MaterialColorChanger : MonoBehaviour
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
