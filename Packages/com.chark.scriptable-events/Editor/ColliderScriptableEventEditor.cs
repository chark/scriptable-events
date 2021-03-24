using ScriptableEvents.Collider;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(ColliderScriptableEvent))]
    public class ColliderScriptableEventEditor
        : BaseObjectScriptableEventEditor<UnityEngine.Collider>
    {
    }
}
