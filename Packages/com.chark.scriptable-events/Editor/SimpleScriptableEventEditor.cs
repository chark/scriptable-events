using ScriptableEvents.Simple;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(SimpleScriptableEvent))]
    public class SimpleScriptableEventEditor : TypedScriptableEventEditor<SimpleArg>
    {
    }
}
