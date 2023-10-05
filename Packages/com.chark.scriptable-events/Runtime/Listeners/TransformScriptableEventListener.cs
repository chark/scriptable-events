using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Transform Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityObjectEvent + 3
    )]
    public sealed class TransformScriptableEventListener : ScriptableEventListener<Transform>
    {
    }
}
