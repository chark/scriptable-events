using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Vector3 Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 1
    )]
    public sealed class Vector3ScriptableEventListener : ScriptableEventListener<Vector3>
    {
    }
}
