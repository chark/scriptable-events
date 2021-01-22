using ScriptableEvents.Float;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(FloatScriptableEvent))]
    public class FloatScriptableEventEditor : BaseScriptableEventEditor<FloatScriptableEvent, float>
    {
        protected override float DrawArgField(float value)
        {
            return EditorGUILayout.FloatField(value);
        }
    }
}
