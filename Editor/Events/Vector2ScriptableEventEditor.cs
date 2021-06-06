using ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(Vector2ScriptableEvent))]
    public class Vector2ScriptableEventEditor : TypedScriptableEventEditor<Vector2>
    {
        protected override Vector2 DrawArgField(Vector2 value)
        {
            return EditorGUILayout.Vector2Field(GUIContent.none, value);
        }
    }
}
