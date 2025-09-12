using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Quaternion Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent
    )]
    public sealed class QuaternionScriptableEventListener : ScriptableEventListener<Quaternion>
    {
    }
}
