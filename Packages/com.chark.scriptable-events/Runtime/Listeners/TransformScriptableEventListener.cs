using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        "Scriptable Events/Transform Scriptable Event Listener",
        ScriptableEventConstants.UnityObjectScriptableEventOrder + 3
    )]
    public class TransformScriptableEventListener : BaseScriptableEventListener<Transform>
    {
    }
}
