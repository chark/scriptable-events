using CHARK.ScriptableEvents.Events;
using UnityEditor;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(SimpleScriptableEvent))]
    public class SimpleScriptableEventEditor : BaseScriptableEventEditor<SimpleArg>
    {
        protected override SimpleArg DrawArgField(SimpleArg value)
        {
            return SimpleArg.Instance;
        }
    }
}
