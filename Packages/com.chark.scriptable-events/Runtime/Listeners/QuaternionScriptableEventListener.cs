using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Quaternion Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 4
    )]
    public sealed class QuaternionScriptableEventListener : ScriptableEventListener<Quaternion>
    {
    }
}
