using UnityEngine;

namespace ScriptableEvents.Samples.CustomEvents
{
    [CreateAssetMenu(
        fileName = "LightRandomizationScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameCustom + "/Light Randomization Scriptable Event",
        order = ScriptableEventConstants.MenuOrderCustom + 0
    )]
    public class LightRandomizationScriptableEvent
        : BaseScriptableEvent<LightRandomizationEventArgs>
    {
    }
}
