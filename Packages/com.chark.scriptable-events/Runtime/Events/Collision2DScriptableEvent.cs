#if UNITY_PHYSICS_2D

using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Collision2DScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Collision 2D Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityObjectEvent
    )]
    public sealed class Collision2DScriptableEvent : ScriptableEvent<Collision2D>
    {
    }
}

#endif
