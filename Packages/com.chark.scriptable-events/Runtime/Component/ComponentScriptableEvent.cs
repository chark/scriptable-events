using UnityEngine;

namespace ScriptableEvents.Component
{
    [CreateAssetMenu(
        fileName = "ComponentScriptableEvent",
        menuName = "Scriptable Events/Component Scriptable Event",
        order = 9
    )]
    public class ComponentScriptableEvent : BaseScriptableEvent<UnityEngine.Component>
    {
    }
}
