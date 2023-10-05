using UnityEngine;

namespace CHARK.ScriptableEvents.Samples.CustomEvents
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameCustom + "/Light Randomization Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderCustom + 0
    )]
    public class LightRandomizationScriptableEventListener : ScriptableEventListener<LightRandomizationEventArgs>
    {
    }
}
