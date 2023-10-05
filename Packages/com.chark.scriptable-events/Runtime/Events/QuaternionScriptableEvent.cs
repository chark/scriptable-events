using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "QuaternionScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Quaternion Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 4
    )]
    public sealed class QuaternionScriptableEvent : ScriptableEvent<Quaternion>
    {
    }
}
