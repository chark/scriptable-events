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
