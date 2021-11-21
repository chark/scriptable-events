using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        "Scriptable Events/Collision 2D Scriptable Event Listener",
        ScriptableEventConstants.UnityPrimitiveScriptableEventOrder + 2
    )]
    public class Collision2DScriptableEventListener : BaseScriptableEventListener<Collision2D>
    {
    }
}
