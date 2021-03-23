using UnityEngine;

namespace ScriptableEvents.GameObject
{
    [CreateAssetMenu(
        fileName = "GameObjectScriptableEvent",
        menuName = "Scriptable Events/Game Object Scriptable Event",
        order = 8
    )]
    public class GameObjectScriptableEvent : BaseScriptableEvent<UnityEngine.GameObject>
    {
    }
}
