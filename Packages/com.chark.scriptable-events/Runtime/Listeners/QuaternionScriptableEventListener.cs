using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        "Scriptable Events/Quaternion Scriptable Event Listener",
        ScriptableEventConstants.UnityPrimitiveScriptableEventOrder + 4
    )]
    public class QuaternionScriptableEventListener : BaseScriptableEventListener<Quaternion>
    {
    }
}
