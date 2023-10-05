using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "TransformScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Transform Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityObjectEvent + 3
    )]
    public sealed class TransformScriptableEvent : ScriptableEvent<Transform>
    {
    }
}
