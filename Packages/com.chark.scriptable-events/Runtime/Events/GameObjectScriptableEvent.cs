using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "GameObjectScriptableEvent",
        menuName = "Scriptable Events/Game Object Scriptable Event",
        order = 202
    )]
    public class GameObjectScriptableEvent : BaseScriptableEvent<GameObject>
    {
    }
}
