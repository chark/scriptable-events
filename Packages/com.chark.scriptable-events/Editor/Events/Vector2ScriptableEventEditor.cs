using CHARK.ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(Vector2ScriptableEvent))]
    public class Vector2ScriptableEventEditor : BaseScriptableEventEditor<Vector2>
    {
        protected override Vector2 DrawArgField(Vector2 value)
        {
            return ScriptableEventGUI.Vector2Field(value);
        }
    }
}
