using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Collider 2D Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityObjectEvent + 0
    )]
    public class Collider2DScriptableEventListener : BaseScriptableEventListener<Collider2D>
    {
    }
}
