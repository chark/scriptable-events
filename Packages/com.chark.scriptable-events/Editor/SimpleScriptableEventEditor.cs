using ScriptableEvents.Simple;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(SimpleScriptableEvent))]
    public class SimpleScriptableEventEditor : BaseScriptableEventEditor<SimpleArg>
    {
        protected override SimpleArg DrawArgField(SimpleArg value)
        {
            // SimpleScriptableEvent "doesn't take" an arg.
            return value;
        }
    }
}
