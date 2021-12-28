using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Collision 2D Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 2
    )]
    public class Collision2DScriptableEventListener : BaseScriptableEventListener<Collision2D>
    {
    }
}
