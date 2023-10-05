using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "CollisionScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Collision Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 3
    )]
    public sealed class CollisionScriptableEvent : ScriptableEvent<Collision>
    {
    }
}
