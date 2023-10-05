using CHARK.ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(ColliderScriptableEvent))]
    public class ColliderScriptableEventEditor : ScriptableEventEditor<Collider>
    {
        protected override Collider DrawArgField(Collider value)
        {
            return ScriptableEventGUI.ObjectField(value, isAllowSceneObjects: true);
        }
    }
}
