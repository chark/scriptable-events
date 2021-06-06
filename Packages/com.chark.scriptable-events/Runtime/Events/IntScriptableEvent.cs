using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "IntScriptableEvent",
        menuName = "Scriptable Events/Int Scriptable Event",
        order = 4
    )]
    public class IntScriptableEvent : BaseScriptableEvent<int>
    {
    }
}
