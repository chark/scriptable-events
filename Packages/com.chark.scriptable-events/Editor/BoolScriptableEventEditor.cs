using ScriptableEvents.Bool;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(BoolScriptableEvent))]
    public class BoolScriptableEventEditor : BaseScriptableEventEditor<bool>
    {
        protected override bool DrawArgField(bool value)
        {
            return EditorGUILayout.Toggle(value);
        }
    }
}
