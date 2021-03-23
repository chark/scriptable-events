using UnityEngine;

namespace ScriptableEvents.Transform
{
    [CreateAssetMenu(
        fileName = "TransformScriptableEvent",
        menuName = "Scriptable Events/Transform Scriptable Event",
        order = 7
    )]
    public class TransformScriptableEvent : BaseScriptableEvent<UnityEngine.Transform>
    {
    }
}
