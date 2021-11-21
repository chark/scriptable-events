using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "GameObjectScriptableEvent",
        menuName = "Scriptable Events/Game Object Scriptable Event",
        order = ScriptableEventConstants.UnityObjectScriptableEventOrder + 2
    )]
    public class GameObjectScriptableEvent : BaseScriptableEvent<GameObject>
    {
    }
}
