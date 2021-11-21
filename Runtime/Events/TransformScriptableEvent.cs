using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "TransformScriptableEvent",
        menuName = "Scriptable Events/Transform Scriptable Event",
        order = ScriptableEventConstants.UnityObjectScriptableEventOrder + 3
    )]
    public class TransformScriptableEvent : BaseScriptableEvent<Transform>
    {
    }
}
