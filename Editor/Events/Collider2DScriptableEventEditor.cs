using CHARK.ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(Collider2DScriptableEvent))]
    public class Collider2DScriptableEventEditor : BaseScriptableEventEditor<Collider2D>
    {
        protected override Collider2D DrawArgField(Collider2D value)
        {
            return ScriptableEventGUI.ObjectField(value, isAllowSceneObjects: true);
        }
    }
}
