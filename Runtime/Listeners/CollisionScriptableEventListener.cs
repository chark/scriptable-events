using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        "Scriptable Events/Collision Scriptable Event Listener",
        ScriptableEventConstants.UnityPrimitiveScriptableEventOrder + 3
    )]
    public class CollisionScriptableEventListener : BaseScriptableEventListener<Collision>
    {
    }
}
