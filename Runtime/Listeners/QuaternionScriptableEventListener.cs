using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNamePrefix + "/Quaternion Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 4
    )]
    public class QuaternionScriptableEventListener : BaseScriptableEventListener<Quaternion>
    {
    }
}
