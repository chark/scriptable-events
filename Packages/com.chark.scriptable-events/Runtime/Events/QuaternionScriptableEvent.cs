using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "QuaternionScriptableEvent",
        menuName = "Scriptable Events/Quaternion Scriptable Event",
        order = 104
    )]
    public class QuaternionScriptableEvent : BaseScriptableEvent<Quaternion>
    {
    }
}
