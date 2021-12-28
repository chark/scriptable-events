using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Game Object Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityObjectEvent + 2
    )]
    public class GameObjectScriptableEventListener
        : BaseScriptableEventListener<GameObject>
    {
    }
}
