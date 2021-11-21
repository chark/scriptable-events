using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        "Scriptable Events/Float Scriptable Event Listener",
        ScriptableEventConstants.PrimitiveScriptableEventOrder + 3
    )]
    public class FloatScriptableEventListener : BaseScriptableEventListener<float>
    {
    }
}
