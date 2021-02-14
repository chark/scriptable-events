using UnityEngine;

namespace ScriptableEvents.Editor.Tools
{
    public class Field
    {
        #region Properties

        public GUIContent Label { get; }

        public bool Required { get; }

        public string Value { get; set; }

        #endregion

        #region Methods

        public Field(string label, string tooltip, bool required)
        {
            Label = new GUIContent(label, tooltip);
            Required = required;
        }

        #endregion
    }
}
