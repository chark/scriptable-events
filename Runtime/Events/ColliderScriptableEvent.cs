using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ColliderScriptableEvent",
        menuName = ScriptableEventConstants.MenuNamePrefix + "/Collider Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityObjectEvent + 1
    )]
    public class ColliderScriptableEvent : BaseScriptableEvent<Collider>
    {
    }
}
