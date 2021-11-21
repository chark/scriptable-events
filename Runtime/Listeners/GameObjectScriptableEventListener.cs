using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        "Scriptable Events/Game Object Scriptable Event Listener",
        ScriptableEventConstants.UnityObjectScriptableEventOrder + 2
    )]
    public class GameObjectScriptableEventListener
        : BaseScriptableEventListener<GameObject>
    {
    }
}
