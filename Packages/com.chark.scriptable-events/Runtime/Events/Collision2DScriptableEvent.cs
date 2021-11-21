using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Collision2DScriptableEvent",
        menuName = "Scriptable Events/Collision 2D Scriptable Event",
        order = ScriptableEventConstants.UnityPrimitiveScriptableEventOrder + 2
    )]
    public class Collision2DScriptableEvent : BaseScriptableEvent<Collision2D>
    {
    }
}
