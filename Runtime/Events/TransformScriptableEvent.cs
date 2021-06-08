using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "TransformScriptableEvent",
        menuName = "Scriptable Events/Transform Scriptable Event",
        order = 203
    )]
    public class TransformScriptableEvent : BaseScriptableEvent<Transform>
    {
    }
}
