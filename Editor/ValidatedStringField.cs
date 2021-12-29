using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    internal class ValidatedStringField : ValidatedField<string>
    {
        #region Fields

        private readonly Regex regex;

        #endregion

        #region Public Methods

        public ValidatedStringField(string labelText, string labelTooltip, Regex regex)
            : base(labelText, labelTooltip)
        {
            this.regex = regex;
        }

        #endregion

        #region Protected Methods

        protected override string Draw(GUIContent label, string value)
        {
            var originalColor = GUI.color;
            if (GUI.enabled && string.IsNullOrWhiteSpace(value))
            {
                GUI.color = Color.red;
            }

            var newValue = EditorGUILayout.TextField(label, value);
            GUI.color = originalColor;

            if (newValue != null)
            {
                newValue = regex.Replace(newValue, string.Empty);
            }

            return newValue;
        }

        #endregion
    }
}
