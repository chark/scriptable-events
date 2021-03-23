using UnityEngine;

namespace ScriptableEvents.Int
{
    [CreateAssetMenu(
        fileName = "IntScriptableEvent",
        menuName = "Scriptable Events/Int Scriptable Event",
        order = 2
    )]
    public class IntScriptableEvent : BaseScriptableEvent<int>
    {
    }
}
