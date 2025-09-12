using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ColorScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Color Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent
    )]
    public sealed class ColorScriptableEvent : ScriptableEvent<Color>
    {
    }
}
