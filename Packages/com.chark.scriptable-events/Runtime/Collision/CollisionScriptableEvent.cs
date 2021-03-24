using UnityEngine;

namespace ScriptableEvents.Collision
{
    [CreateAssetMenu(
        fileName = "CollisionScriptableEvent",
        menuName = "Scriptable Events/Collision Scriptable Event",
        order = 11
    )]
    public class CollisionScriptableEvent : BaseScriptableEvent<UnityEngine.Collision>
    {
    }
}
