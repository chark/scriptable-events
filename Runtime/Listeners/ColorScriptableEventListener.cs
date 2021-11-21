using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        "Scriptable Events/Color Scriptable Event Listener",
        ScriptableEventConstants.UnityPrimitiveScriptableEventOrder + 5
    )]
    public class ColorScriptableEventListener : BaseScriptableEventListener<Color>
    {
    }
}
