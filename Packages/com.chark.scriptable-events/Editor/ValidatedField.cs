using System.Collections.Generic;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Utility for drawing editor window fields which are validated and have default values.
    /// </summary>
    internal abstract class ValidatedField<T>
    {
        #region Fields

        private readonly GUIContent label;
        private T defaultValue;

        #endregion

        #region Public Properties

        public T CurrentValue { get; set; }

        public T DefaultValue
        {
            set
            {
                var comparer = EqualityComparer<T>.Default;
                if (comparer.Equals(CurrentValue, default) ||
                    comparer.Equals(CurrentValue, defaultValue))
                {
                    CurrentValue = value;
                }

                defaultValue = value;
            }
        }

        #endregion

        #region Protected Methods

        protected ValidatedField(string labelText, string labelTooltip)
        {
            label = new GUIContent {text = labelText, tooltip = labelTooltip};
        }

        protected abstract T Draw(GUIContent label, T value);

        #endregion

        #region Public Methods

        public void Draw()
        {
            CurrentValue = Draw(label, CurrentValue);
        }

        public static implicit operator T(ValidatedField<T> field)
        {
            return field.CurrentValue;
        }

        #endregion
    }
}
