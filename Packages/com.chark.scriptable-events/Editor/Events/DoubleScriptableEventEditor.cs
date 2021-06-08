using ScriptableEvents.Events;
using UnityEditor;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(DoubleScriptableEvent))]
    public class DoubleScriptableEventEditor : TypedScriptableEventEditor<double>
    {
        protected override double DrawArgField(double value)
        {
            return EditorGUILayout.DoubleField(value);
        }
    }
}
