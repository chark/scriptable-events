using UnityEngine;

namespace ScriptableEvents.Bool
{
    [CreateAssetMenu(
        fileName = "BoolScriptableEvent",
        menuName = "Scriptable Events/Bool Scriptable Event",
        order = 1
    )]
    public class BoolScriptableEvent : BaseScriptableEvent<bool>
    {
    }
}
