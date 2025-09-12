#if UNITY_PHYSICS_2D

using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Collider 2D Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityObjectEvent
    )]
    public sealed class Collider2DScriptableEventListener : ScriptableEventListener<Collider2D>
    {
    }
}

#endif
