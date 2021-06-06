using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Vector3ScriptableEvent",
        menuName = "Scriptable Events/Vector3 Scriptable Event",
        order = 8
    )]
    public class Vector3ScriptableEvent : BaseScriptableEvent<Vector3>
    {
    }
}
