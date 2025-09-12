using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ObjectScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Object Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityObjectEvent + 2
    )]
    public sealed class ObjectScriptableEvent : ScriptableEvent<Object>
    {
    }
}
