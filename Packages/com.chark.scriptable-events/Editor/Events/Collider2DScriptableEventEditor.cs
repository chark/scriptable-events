using ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(Collider2DScriptableEvent))]
    public class Collider2DScriptableEventEditor : TypedScriptableEventEditor<Collider2D>
    {
        protected override Collider2D DrawArgField(Collider2D value)
        {
            return EditorGUILayout.ObjectField(value, typeof(Collider2D), true) as Collider2D;
        }
    }
}
