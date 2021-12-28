using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/String Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 5
    )]
    public class StringScriptableEventListener : BaseScriptableEventListener<string>
    {
    }
}
