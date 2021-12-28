using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Quaternion Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 4
    )]
    public class QuaternionScriptableEventListener : BaseScriptableEventListener<Quaternion>
    {
    }
}
