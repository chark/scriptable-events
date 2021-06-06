using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "FloatScriptableEvent",
        menuName = "Scriptable Events/Float Scriptable Event",
        order = 2
    )]
    public class FloatScriptableEvent : BaseScriptableEvent<float>
    {
    }
}
