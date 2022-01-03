using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents.CustomEvents
{
    public class MaterialOptionsHandler : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent<MaterialData> onMaterialChanged;

        private float metallic;
        private Color color = Color.white;

        public void OnChangeMetallic(float newMetallic)
        {
            metallic = newMetallic;
            InvokeEvent();
        }

        public void OnChangeColor(int colorIndex)
        {
            switch (colorIndex)
            {
                case 0:
                    color = Color.white;
                    break;
                case 1:
                    color = Color.red;
                    break;
                case 2:
                    color = Color.green;
                    break;
                case 3:
                    color = Color.blue;
                    break;
                default:
                    color = Color.black;
                    break;
            }

            InvokeEvent();
        }

        private void InvokeEvent()
        {
            onMaterialChanged.Invoke(new MaterialData(metallic, color));
        }
    }
}
