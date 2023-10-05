using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Collision2DScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Collision 2D Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 2
    )]
    public sealed class Collision2DScriptableEvent : ScriptableEvent<Collision2D>
    {
    }
}
