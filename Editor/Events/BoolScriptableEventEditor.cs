using ScriptableEvents.Events;
using UnityEditor;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(BoolScriptableEvent))]
    public class BoolScriptableEventEditor : TypedScriptableEventEditor<bool>
    {
        protected override bool DrawArgField(bool value)
        {
            return EditorGUILayout.Toggle(value);
        }
    }
}
