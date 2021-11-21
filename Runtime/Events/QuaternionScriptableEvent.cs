using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "QuaternionScriptableEvent",
        menuName = "Scriptable Events/Quaternion Scriptable Event",
        order = ScriptableEventConstants.UnityPrimitiveScriptableEventOrder + 4
    )]
    public class QuaternionScriptableEvent : BaseScriptableEvent<Quaternion>
    {
    }
}
