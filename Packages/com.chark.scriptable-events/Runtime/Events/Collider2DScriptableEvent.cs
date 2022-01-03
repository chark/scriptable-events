using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Collider2DScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Collider 2D Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityObjectEvent + 0
    )]
    public class Collider2DScriptableEvent : BaseScriptableEvent<Collider2D>
    {
    }
}
