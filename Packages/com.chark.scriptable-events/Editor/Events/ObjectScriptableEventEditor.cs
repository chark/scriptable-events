using CHARK.ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(ObjectScriptableEvent))]
    public class ObjectScriptableEventEditor : ScriptableEventEditor<Object>
    {
        protected override Object DrawArgField(Object value)
        {
            return ScriptableEventGUI.ObjectField(value, isAllowSceneObjects: true);
        }
    }
}
