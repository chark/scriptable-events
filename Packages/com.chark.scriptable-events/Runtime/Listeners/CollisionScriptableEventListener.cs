#if UNITY_PHYSICS_3D

using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Collision Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 3
    )]
    public sealed class CollisionScriptableEventListener : ScriptableEventListener<Collision>
    {
    }
}

#endif
