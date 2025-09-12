#if UNITY_PHYSICS_3D

using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "CollisionScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Collision Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityObjectEvent
    )]
    public sealed class CollisionScriptableEvent : ScriptableEvent<Collision>
    {
    }
}

#endif
