using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "IntScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Int Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 1
    )]
    public class IntScriptableEvent : BaseScriptableEvent<int>
    {
    }
}
