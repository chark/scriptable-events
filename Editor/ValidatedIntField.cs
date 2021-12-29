using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    internal class ValidatedIntField : ValidatedField<int>
    {
        #region Fields

        private readonly int min;
        private readonly int max;

        #endregion

        #region Public Methods

        public ValidatedIntField(
            string labelText,
            string labelTooltip,
            int min = int.MinValue,
            int max = int.MaxValue
        ) : base(labelText, labelTooltip)
        {
            this.min = min;
            this.max = max;
        }

        #endregion

        #region Protected Methods

        protected override int Draw(GUIContent label, int value)
        {
            var newValue = EditorGUILayout.IntField(label, value);
            newValue = Mathf.Clamp(newValue, min, max);

            return newValue;
        }

        #endregion
    }
}
