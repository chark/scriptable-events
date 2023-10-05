using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Collider 2D Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityObjectEvent + 0
    )]
    public sealed class Collider2DScriptableEventListener : ScriptableEventListener<Collider2D>
    {
    }
}
