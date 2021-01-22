using UnityEngine;

namespace ScriptableEvents.Transform
{
    [CreateAssetMenu(
        fileName = "TransformScriptableEvent",
        menuName = "Scriptable Events/Transform Scriptable Event"
    )]
    public class TransformScriptableEvent : BaseScriptableEvent<UnityEngine.Transform>
    {
    }
}
