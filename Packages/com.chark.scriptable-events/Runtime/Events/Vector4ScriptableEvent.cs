using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Vector4ScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Vector4 Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent
    )]
    public sealed class Vector4ScriptableEvent : ScriptableEvent<Vector4>
    {
    }
}
