using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Vector4 Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 2
    )]
    public sealed class Vector4ScriptableEventListener : ScriptableEventListener<Vector4>
    {
    }
}
