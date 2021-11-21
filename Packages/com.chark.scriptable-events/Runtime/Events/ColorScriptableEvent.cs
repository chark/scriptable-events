using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ColorScriptableEvent",
        menuName = "Scriptable Events/Color Scriptable Event",
        order = ScriptableEventConstants.UnityPrimitiveScriptableEventOrder + 5
    )]
    public class ColorScriptableEvent : BaseScriptableEvent<Color>
    {
    }
}
