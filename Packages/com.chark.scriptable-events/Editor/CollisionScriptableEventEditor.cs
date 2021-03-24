using ScriptableEvents.Collision;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(CollisionScriptableEvent))]
    public class CollisionScriptableEventEditor : BaseScriptableEventEditor<UnityEngine.Collision>
    {
        protected override bool IsDrawRaise()
        {
            return false;
        }
    }
}
