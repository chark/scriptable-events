#if UNITY_PHYSICS_3D

using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ColliderScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Collider Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityObjectEvent
    )]
    public sealed class ColliderScriptableEvent : ScriptableEvent<Collider>
    {
    }
}

#endif
