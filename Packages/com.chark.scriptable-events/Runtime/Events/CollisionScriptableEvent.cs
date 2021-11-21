using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "CollisionScriptableEvent",
        menuName = "Scriptable Events/Collision Scriptable Event",
        order = ScriptableEventConstants.UnityPrimitiveScriptableEventOrder + 3
    )]
    public class CollisionScriptableEvent : BaseScriptableEvent<Collision>
    {
    }
}
