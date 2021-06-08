using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "CollisionScriptableEvent",
        menuName = "Scriptable Events/Collision Scriptable Event",
        order = 103
    )]
    public class CollisionScriptableEvent : BaseScriptableEvent<Collision>
    {
    }
}
