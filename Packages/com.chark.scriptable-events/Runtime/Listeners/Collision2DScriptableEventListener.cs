#if UNITY_PHYSICS_2D

using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Collision 2D Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityObjectEvent + 4
    )]
    public sealed class Collision2DScriptableEventListener : ScriptableEventListener<Collision2D>
    {
    }
}

#endif
