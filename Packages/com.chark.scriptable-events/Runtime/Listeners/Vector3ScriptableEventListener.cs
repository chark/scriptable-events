using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Vector3 Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent
    )]
    public sealed class Vector3ScriptableEventListener : ScriptableEventListener<Vector3>
    {
    }
}
