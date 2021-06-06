using ScriptableEvents.Vector3;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(Vector3ScriptableEvent))]
    public class Vector3ScriptableEventEditor : TypedScriptableEventEditor<UnityEngine.Vector3>
    {
        protected override UnityEngine.Vector3 DrawArgField(UnityEngine.Vector3 value)
        {
            return EditorGUILayout.Vector3Field(GUIContent.none, value);
        }
    }
}
