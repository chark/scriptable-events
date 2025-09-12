using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Game Object Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityObjectEvent
    )]
    public sealed class GameObjectScriptableEventListener : ScriptableEventListener<GameObject>
    {
    }
}
