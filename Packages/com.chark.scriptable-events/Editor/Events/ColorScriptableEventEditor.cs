using ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(ColorScriptableEvent))]
    public class ColorScriptableEventEditor : BaseScriptableEventEditor<Color>
    {
        protected override Color DrawArgField(Color value)
        {
            return ScriptableEventGUI.ColorField(value);
        }
    }
}
