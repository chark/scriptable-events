using UnityEngine;

namespace ScriptableEvents.GameObject
{
    [CreateAssetMenu(
        fileName = "GameObjectScriptableEvent",
        menuName = "Scriptable Events/Game Object Scriptable Event"
    )]
    public class GameObjectScriptableEvent : BaseScriptableEvent<UnityEngine.GameObject>
    {
    }
}
