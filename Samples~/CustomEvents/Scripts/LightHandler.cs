using UnityEngine;

namespace ScriptableEvents.Samples.CustomEvents
{
    public class LightHandler : MonoBehaviour
    {
        private Light[] connectedLights;

        private void Awake()
        {
            connectedLights = GetComponentsInChildren<Light>();
        }

        public void HandleLightRandomization(LightRandomizationEventArgs args)
        {
            foreach (var connectedLight in connectedLights)
            {
                connectedLight.intensity = args.Intensity;
                connectedLight.color = args.Color;
            }
        }
    }
}
