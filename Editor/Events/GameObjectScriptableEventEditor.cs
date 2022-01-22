using ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Events
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
