using ScriptableEvents.Int;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(IntScriptableEvent))]
    public class IntScriptableEventEditor : BaseScriptableEventEditor<IntScriptableEvent, int>
    {
        protected override int DrawArgField(int value)
        {
            return EditorGUILayout.IntField(value);
        }
    }
}
