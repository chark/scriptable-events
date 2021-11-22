using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ColorScriptableEvent",
        menuName = ScriptableEventConstants.MenuNamePrefix + "/Color Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 5
    )]
    public class ColorScriptableEvent : BaseScriptableEvent<Color>
    {
    }
}
