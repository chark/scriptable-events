using ScriptableEvents.Component;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(ComponentScriptableEvent))]
    public class ComponentScriptableEventEditor
        : BaseObjectScriptableEventEditor<UnityEngine.Component>
    {
    }
}
