using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Vector2ScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Vector2 Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent
    )]
    public sealed class Vector2ScriptableEvent : ScriptableEvent<Vector2>
    {
    }
}
