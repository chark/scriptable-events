using ScriptableEvents.Vector2;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(Vector2ScriptableEvent))]
    public class Vector2ScriptableEventEditor
        : BaseScriptableEventEditor<Vector2ScriptableEvent, UnityEngine.Vector2>
    {
        protected override UnityEngine.Vector2 DrawArgField(UnityEngine.Vector2 value)
        {
            return EditorGUILayout.Vector2Field(GUIContent.none, value);
        }
    }
}
