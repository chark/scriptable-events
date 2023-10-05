using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Vector2ScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Vector2 Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 0
    )]
    public sealed class Vector2ScriptableEvent : ScriptableEvent<Vector2>
    {
    }
}
