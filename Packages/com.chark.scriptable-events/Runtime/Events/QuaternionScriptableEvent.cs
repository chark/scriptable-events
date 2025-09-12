using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "QuaternionScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Quaternion Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent
    )]
    public sealed class QuaternionScriptableEvent : ScriptableEvent<Quaternion>
    {
    }
}
