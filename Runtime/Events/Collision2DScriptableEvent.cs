using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Collision2DScriptableEvent",
        menuName = ScriptableEventConstants.MenuNamePrefix + "/Collision 2D Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 2
    )]
    public class Collision2DScriptableEvent : BaseScriptableEvent<Collision2D>
    {
    }
}
