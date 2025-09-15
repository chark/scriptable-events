using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "TransformScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Transform Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityObjectEvent + 2
    )]
    public sealed class TransformScriptableEvent : ScriptableEvent<Transform>
    {
    }
}
