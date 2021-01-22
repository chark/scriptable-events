using UnityEngine;
using UnityEngine.UI;

namespace ScriptableEvents.Smaples
{
    [RequireComponent(typeof(Text))]
    public class FloatFadeOutText : MonoBehaviour
    {
        [SerializeField]
        private UnityEngine.Vector3 floatDirection = UnityEngine.Vector2.up;

        [SerializeField]
        private Color fadeOutColor = Color.clear;

        [SerializeField]
        private float floatSpeed = 15f;

        [SerializeField]
        private float floatDuration = 3f;

        private float floatProgress;
        private Text floatText;
        private Color originalColor;

        private void Awake()
        {
            floatText = GetComponent<Text>();
            originalColor = floatText.color;
        }

        private void Update()
        {
            floatText.rectTransform.position = GetTextPosition();
            floatText.color = GetTextColor();

            if (floatProgress > 1f) Destroy(gameObject);

            floatProgress = GetProgress();
        }

        private UnityEngine.Vector3 GetTextPosition()
        {
            return floatText.rectTransform.position + floatDirection * (floatSpeed * Time.deltaTime);
        }

        private Color GetTextColor()
        {
            return Color.LerpUnclamped(originalColor, fadeOutColor, floatProgress);
        }

        private float GetProgress()
        {
            return floatProgress + Time.deltaTime / floatDuration;
        }
    }
}
