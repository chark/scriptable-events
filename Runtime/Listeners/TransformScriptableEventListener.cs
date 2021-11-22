using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNamePrefix + "/Transform Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityObjectEvent + 3
    )]
    public class TransformScriptableEventListener : BaseScriptableEventListener<Transform>
    {
    }
}
