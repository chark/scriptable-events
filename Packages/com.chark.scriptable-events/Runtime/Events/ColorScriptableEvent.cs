using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ColorScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Color Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 5
    )]
    public class ColorScriptableEvent : BaseScriptableEvent<Color>
    {
    }
}
