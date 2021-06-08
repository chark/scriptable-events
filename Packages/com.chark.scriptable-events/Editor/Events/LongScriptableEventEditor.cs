using ScriptableEvents.Events;
using UnityEditor;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(LongScriptableEvent))]
    public class LongScriptableEventEditor : TypedScriptableEventEditor<long>
    {
        protected override long DrawArgField(long value)
        {
            return EditorGUILayout.LongField(value);
        }
    }
}
