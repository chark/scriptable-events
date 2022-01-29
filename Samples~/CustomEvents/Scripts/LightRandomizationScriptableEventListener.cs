using UnityEngine;

namespace ScriptableEvents.Samples.CustomEvents
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameCustom + "/Light Randomization Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderCustom + 0
    )]
    public class LightRandomizationScriptableEventListener : BaseScriptableEventListener<LightRandomizationEventArgs>
    {
    }
}
