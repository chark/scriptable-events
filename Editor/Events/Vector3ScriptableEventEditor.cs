using ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(Vector3ScriptableEvent))]
    public class Vector3ScriptableEventEditor : TypedScriptableEventEditor<Vector3>
    {
        protected override Vector3 DrawArgField(Vector3 value)
        {
            return EditorGUILayout.Vector3Field(GUIContent.none, value);
        }
    }
}
