using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Transform Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityObjectEvent
    )]
    public sealed class TransformScriptableEventListener : ScriptableEventListener<Transform>
    {
    }
}
