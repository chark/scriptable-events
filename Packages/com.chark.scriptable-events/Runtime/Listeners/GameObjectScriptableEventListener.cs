using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Game Object Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityObjectEvent + 1
    )]
    public sealed class GameObjectScriptableEventListener : ScriptableEventListener<GameObject>
    {
    }
}
