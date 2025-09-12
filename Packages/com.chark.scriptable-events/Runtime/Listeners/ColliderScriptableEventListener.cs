#if UNITY_PHYSICS_3D

using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Collider Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityObjectEvent
    )]
    public sealed class ColliderScriptableEventListener : ScriptableEventListener<Collider>
    {
    }
}

#endif
