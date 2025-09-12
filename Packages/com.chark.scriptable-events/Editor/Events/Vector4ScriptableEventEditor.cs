using CHARK.ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(Vector4ScriptableEvent))]
    public class Vector4ScriptableEventEditor : ScriptableEventEditor<Vector4>
    {
        protected override Vector4 DrawArgField(Vector4 value)
        {
            return ScriptableEventGUI.Vector4Field(value);
        }
    }
}
