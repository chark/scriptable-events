using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        "Scriptable Events/Collider Scriptable Event Listener",
        ScriptableEventConstants.UnityObjectScriptableEventOrder + 1
    )]
    public class ColliderScriptableEventListener : BaseScriptableEventListener<Collider>
    {
    }
}
