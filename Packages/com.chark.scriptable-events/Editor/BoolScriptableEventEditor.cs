using ScriptableEvents.Bool;
using UnityEditor;

namespace ScriptableEvents.Editor
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
