using ScriptableEvents.Events;
using UnityEditor;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(SimpleScriptableEvent))]
    public class SimpleScriptableEventEditor : TypedScriptableEventEditor<SimpleArg>
    {
    }
}
