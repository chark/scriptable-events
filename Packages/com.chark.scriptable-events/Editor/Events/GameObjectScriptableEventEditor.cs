using CHARK.ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(GameObjectScriptableEvent))]
    public class GameObjectScriptableEventEditor : BaseScriptableEventEditor<GameObject>
    {
        protected override GameObject DrawArgField(GameObject value)
        {
            return ScriptableEventGUI.ObjectField(value, isAllowSceneObjects: true);
        }
    }
}
