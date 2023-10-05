using CHARK.ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(ColorScriptableEvent))]
    public class ColorScriptableEventEditor : ScriptableEventEditor<Color>
    {
        protected override Color DrawArgField(Color value)
        {
            return ScriptableEventGUI.ColorField(value);
        }
    }
}
