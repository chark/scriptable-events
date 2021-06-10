using ScriptableEvents.Events;
using UnityEditor;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(FloatScriptableEvent))]
    public class FloatScriptableEventEditor : BaseScriptableEventEditor<float>
    {
        protected override float DrawArgField(float value)
        {
            return EditorGUILayout.FloatField(value);
        }
    }
}
