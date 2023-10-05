using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Game Object Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityObjectEvent + 2
    )]
    public sealed class GameObjectScriptableEventListener : ScriptableEventListener<GameObject>
    {
    }
}
