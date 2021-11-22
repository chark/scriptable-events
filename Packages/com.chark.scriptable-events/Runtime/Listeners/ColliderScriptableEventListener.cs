using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNamePrefix + "/Collider Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityObjectEvent + 1
    )]
    public class ColliderScriptableEventListener : BaseScriptableEventListener<Collider>
    {
    }
}
