using UnityEngine;

namespace ScriptableEvents.Transform
{
    [CreateAssetMenu(
        fileName = "TransformScriptableEvent",
        menuName = "Scriptable Events/Transform Scriptable Event",
        order = 6
    )]
    public class TransformScriptableEvent : BaseScriptableEvent<UnityEngine.Transform>
    {
    }
}
