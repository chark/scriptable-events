using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "FloatScriptableEvent",
        menuName = "Scriptable Events/Float Scriptable Event",
        order = 3
    )]
    public class FloatScriptableEvent : BaseScriptableEvent<float>
    {
    }
}
