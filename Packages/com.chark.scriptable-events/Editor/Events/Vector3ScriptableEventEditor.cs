using ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(Vector3ScriptableEvent))]
    public class Vector3ScriptableEventEditor : BaseScriptableEventEditor<Vector3>
    {
        protected override Vector3 DrawArgField(Vector3 value)
        {
            return ScriptableEventGUI.Vector3Field(value);
        }
    }
}
