using ScriptableEvents.Events;
using UnityEditor;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(IntScriptableEvent))]
    public class IntScriptableEventEditor : BaseScriptableEventEditor<int>
    {
        protected override int DrawArgField(int value)
        {
            return EditorGUILayout.IntField(value);
        }
    }
}
