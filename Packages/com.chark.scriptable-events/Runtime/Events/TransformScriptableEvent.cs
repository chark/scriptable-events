using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "TransformScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Transform Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityObjectEvent
    )]
    public sealed class TransformScriptableEvent : ScriptableEvent<Transform>
    {
    }
}
