using MutableObjects.Int;
using UnityEngine;
using UnityEngine.UI;

namespace MutableObjects
{
    [RequireComponent(typeof(Text))]
    public class HealthText : MonoBehaviour
    {
        [SerializeField]
        private MutableInt health = default;

        private int currentHealth;

        private Text text;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        private void Start()
        {
            currentHealth = health.Value;
            SetText();
        }

        private void Update()
        {
            if (currentHealth != health.Value)
            {
                currentHealth = health.Value;
                SetText();
            }
        }

        private void SetText()
        {
            text.text = currentHealth.ToString();
        }
    }
}
