using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Color Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent
    )]
    public sealed class ColorScriptableEventListener : ScriptableEventListener<Color>
    {
    }
}
