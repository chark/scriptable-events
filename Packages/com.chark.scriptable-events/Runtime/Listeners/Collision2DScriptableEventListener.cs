using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Collision 2D Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 2
    )]
    public sealed class Collision2DScriptableEventListener : ScriptableEventListener<Collision2D>
    {
    }
}
