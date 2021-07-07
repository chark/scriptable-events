using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "LongScriptableEvent",
        menuName = "Scriptable Events/Long Scriptable Event",
        order = 2
    )]
    public class LongScriptableEvent : BaseScriptableEvent<long>
    {
    }
}
