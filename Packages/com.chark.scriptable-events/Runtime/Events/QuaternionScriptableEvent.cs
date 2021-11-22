using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "QuaternionScriptableEvent",
        menuName = ScriptableEventConstants.MenuNamePrefix + "/Quaternion Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 4
    )]
    public class QuaternionScriptableEvent : BaseScriptableEvent<Quaternion>
    {
    }
}
