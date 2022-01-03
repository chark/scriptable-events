using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "LongScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Long Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 2
    )]
    public class LongScriptableEvent : BaseScriptableEvent<long>
    {
    }
}
