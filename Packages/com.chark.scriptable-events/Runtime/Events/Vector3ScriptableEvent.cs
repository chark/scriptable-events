using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Vector3ScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Vector3 Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent
    )]
    public sealed class Vector3ScriptableEvent : ScriptableEvent<Vector3>
    {
    }
}
