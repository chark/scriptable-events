using ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(TransformScriptableEvent))]
    public class TransformScriptableEventEditor : TypedScriptableEventEditor<Transform>
    {
        protected override Transform DrawArgField(Transform value)
        {
            return EditorGUILayout.ObjectField(value, typeof(Transform), true) as Transform;
        }
    }
}
