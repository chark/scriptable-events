using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Object Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityObjectEvent
    )]
    public sealed class ObjectScriptableEventListener : ScriptableEventListener<Object>
    {
    }
}
