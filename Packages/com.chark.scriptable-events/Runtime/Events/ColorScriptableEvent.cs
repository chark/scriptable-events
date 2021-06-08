using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ColorScriptableEvent",
        menuName = "Scriptable Events/Color Scriptable Event",
        order = 105
    )]
    public class ColorScriptableEvent : BaseScriptableEvent<Color>
    {
    }
}
