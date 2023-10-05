using CHARK.ScriptableEvents.Events;
using UnityEditor;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(FloatScriptableEvent))]
    public class FloatScriptableEventEditor : BaseScriptableEventEditor<float>
    {
        protected override float DrawArgField(float value)
        {
            return ScriptableEventGUI.FloatField(value);
        }
    }
}
