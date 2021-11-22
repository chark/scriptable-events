using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Vector3ScriptableEvent",
        menuName = ScriptableEventConstants.MenuNamePrefix + "/Vector3 Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 1
    )]
    public class Vector3ScriptableEvent : BaseScriptableEvent<Vector3>
    {
    }
}
