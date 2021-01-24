using UnityEngine;

namespace ScriptableEvents.CustomEvents
{
    public class MaterialChanger : MonoBehaviour
    {
        private static readonly int Metallic = Shader.PropertyToID("_Metallic");
        private Material material;

        private void Awake()
        {
            material = GetComponent<MeshRenderer>().material;
        }

        public void ChangeMaterial(MaterialData data)
        {
            material.color = data.Color;
            material.SetFloat(Metallic, data.Metallic);
        }
    }
}
