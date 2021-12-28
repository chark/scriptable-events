using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Vector2 Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 0
    )]
    public class Vector2ScriptableEventListener : BaseScriptableEventListener<Vector2>
    {
    }
}
