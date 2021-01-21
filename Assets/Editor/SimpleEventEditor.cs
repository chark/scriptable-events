using GameEvents.Simple;
using UnityEditor;

namespace GameEvents.Editor
{
    [CustomEditor(typeof(SimpleGameEvent))]
    public class SimpleEventEditor : BaseGameEventEditor<SimpleGameEvent, SimpleArg>
    {
        protected override SimpleArg DrawArgField(SimpleArg value)
        {
            // SimpleGameEvent "doesn't take" an arg.
            return value;
        }
    }
}
