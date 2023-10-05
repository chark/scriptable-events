using CHARK.ScriptableEvents.Events;
using UnityEditor;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(DoubleScriptableEvent))]
    public class DoubleScriptableEventEditor : ScriptableEventEditor<double>
    {
        protected override double DrawArgField(double value)
        {
            return ScriptableEventGUI.DoubleField(value);
        }
    }
}
