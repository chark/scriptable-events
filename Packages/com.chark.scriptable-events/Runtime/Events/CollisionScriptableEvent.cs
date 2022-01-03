using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "CollisionScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Collision Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 3
    )]
    public class CollisionScriptableEvent : BaseScriptableEvent<Collision>
    {
    }
}
