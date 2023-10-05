using CHARK.ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(Vector3ScriptableEvent))]
    public class Vector3ScriptableEventEditor : ScriptableEventEditor<Vector3>
    {
        protected override Vector3 DrawArgField(Vector3 value)
        {
            return ScriptableEventGUI.Vector3Field(value);
        }
    }
}
