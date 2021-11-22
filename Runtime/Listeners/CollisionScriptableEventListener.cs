using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNamePrefix + "/Collision Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 3
    )]
    public class CollisionScriptableEventListener : BaseScriptableEventListener<Collision>
    {
    }
}
