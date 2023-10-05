using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace CHARK.ScriptableEvents.Samples.CustomEvents
{
    public class LightRandomizationTrigger : MonoBehaviour
    {
        [Min(0f)]
        [SerializeField]
        [Tooltip("Lower bound of intensity randomization range")]
        private float minIntensity;

        [Min(0f)]
        [SerializeField]
        [Tooltip("Upper bound of intensity randomization range")]
        private float maxIntensity = 1f;

        [SerializeField]
        [Tooltip("Color randomization range")]
        private Gradient colors = new Gradient
        {
            colorKeys = new[]
            {
                new GradientColorKey(Color.cyan, 0.0f),
                new GradientColorKey(Color.green, 0.25f),
                new GradientColorKey(Color.red, 0.5f),
                new GradientColorKey(Color.yellow, 0.75f),
                new GradientColorKey(Color.blue, 1.0f)
            }
        };

        [Space]
        [SerializeField]
        private UnityEvent<LightRandomizationEventArgs> onRandomizeLights;

        public void RandomizeLights()
        {
            var randomIntensity = Random.Range(minIntensity, maxIntensity);
            var randomColor = colors.Evaluate(Random.Range(0f, 1f));

            var args = new LightRandomizationEventArgs
            {
                Intensity = randomIntensity,
                Color = randomColor
            };

            onRandomizeLights.Invoke(args);
        }
    }
}
