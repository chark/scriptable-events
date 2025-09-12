using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Vector2 Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent
    )]
    public sealed class Vector2ScriptableEventListener : ScriptableEventListener<Vector2>
    {
    }
}
