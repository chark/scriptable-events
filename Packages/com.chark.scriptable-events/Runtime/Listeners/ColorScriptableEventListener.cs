using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Color Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 5
    )]
    public class ColorScriptableEventListener : BaseScriptableEventListener<Color>
    {
    }
}
