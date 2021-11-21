using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        "Scriptable Events/Vector3 Scriptable Event Listener",
        ScriptableEventConstants.UnityPrimitiveScriptableEventOrder + 1
    )]
    public class Vector3ScriptableEventListener : BaseScriptableEventListener<Vector3>
    {
    }
}
