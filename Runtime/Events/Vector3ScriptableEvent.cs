using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Vector3ScriptableEvent",
        menuName = "Scriptable Events/Vector3 Scriptable Event",
        order = ScriptableEventConstants.UnityPrimitiveScriptableEventOrder + 1
    )]
    public class Vector3ScriptableEvent : BaseScriptableEvent<Vector3>
    {
    }
}
