using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNamePrefix + "/Vector2 Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 0
    )]
    public class Vector2ScriptableEventListener : BaseScriptableEventListener<Vector2>
    {
    }
}
