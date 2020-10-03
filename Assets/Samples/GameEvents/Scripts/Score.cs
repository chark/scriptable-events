using UnityEngine;
using UnityEngine.UI;

namespace GameEvents
{
    [RequireComponent(typeof(Text))]
    public class Score : MonoBehaviour
    {
        [Min(0)]
        [SerializeField]
        private int scoreIncrease = 100;

        [SerializeField]
        private float scoreEffectYOffset = 10f;

        [SerializeField]
        private FloatFadeOutText scoreEffectPrefab = default;

        private int currentScore;
        private Text text;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        public void IncreaseScore()
        {
            currentScore += scoreIncrease;
            text.text = currentScore.ToString();

            InstantiateEffect($"+{scoreIncrease.ToString()}");
        }

        private void InstantiateEffect(string effectText)
        {
            var scoreTransform = transform;
            var scorePosition = scoreTransform.position;

            scorePosition.y += scoreEffectYOffset;

            var floatEffect = Instantiate(
                scoreEffectPrefab,
                scorePosition,
                Quaternion.identity,
                scoreTransform
            );

            var floatText = floatEffect.GetComponent<Text>();
            if (floatText != null)
            {
                floatText.text = effectText;
            }
        }
    }
}
