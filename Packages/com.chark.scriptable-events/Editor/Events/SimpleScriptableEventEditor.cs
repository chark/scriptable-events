using ScriptableEvents.Events;
using UnityEditor;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(SimpleScriptableEvent))]
    public class SimpleScriptableEventEditor : BaseScriptableEventEditor<SimpleArg>
    {
        protected override SimpleArg DrawArgField(SimpleArg arg)
        {
            return SimpleArg.Instance;
        }
    }
}
