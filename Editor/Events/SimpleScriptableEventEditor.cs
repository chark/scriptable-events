using CHARK.ScriptableEvents.Events;
using UnityEditor;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(SimpleScriptableEvent))]
    public class SimpleScriptableEventEditor : ScriptableEventEditor<SimpleArg>
    {
        protected override SimpleArg DrawArgField(SimpleArg value)
        {
            return SimpleArg.Instance;
        }
    }
}
