using ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(ColliderScriptableEvent))]
    public class ColliderScriptableEventEditor : TypedScriptableEventEditor<Collider>
    {
        protected override Collider DrawArgField(Collider value)
        {
            return EditorGUILayout.ObjectField(value, typeof(Collider), true) as Collider;
        }
    }
}
