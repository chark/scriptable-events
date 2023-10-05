using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Collision Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 3
    )]
    public sealed class CollisionScriptableEventListener : ScriptableEventListener<Collision>
    {
    }
}
