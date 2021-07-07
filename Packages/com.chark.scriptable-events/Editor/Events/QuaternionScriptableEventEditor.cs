using ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(QuaternionScriptableEvent))]
    public class QuaternionScriptableEventEditor : BaseScriptableEventEditor<Quaternion>
    {
        protected override Quaternion DrawArgField(Quaternion value)
        {
            var angles = value.eulerAngles;
            var result = EditorGUILayout.Vector3Field(GUIContent.none, angles);

            return Quaternion.Euler(result);
        }
    }
}
