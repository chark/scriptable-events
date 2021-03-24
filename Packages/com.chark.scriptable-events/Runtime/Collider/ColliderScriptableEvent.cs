using UnityEngine;

namespace ScriptableEvents.Collider
{
    [CreateAssetMenu(
        fileName = "ColliderScriptableEvent",
        menuName = "Scriptable Events/Collider Scriptable Event",
        order = 10
    )]
    public class ColliderScriptableEvent : BaseScriptableEvent<UnityEngine.Collider>
    {
    }
}
