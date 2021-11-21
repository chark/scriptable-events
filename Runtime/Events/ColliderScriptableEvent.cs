using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ColliderScriptableEvent",
        menuName = "Scriptable Events/Collider Scriptable Event",
        order = ScriptableEventConstants.UnityObjectScriptableEventOrder + 1
    )]
    public class ColliderScriptableEvent : BaseScriptableEvent<Collider>
    {
    }
}
