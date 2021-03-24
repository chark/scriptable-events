using ScriptableEvents.Transform;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(TransformScriptableEvent))]
    public class TransformScriptableEventEditor
        : BaseObjectScriptableEventEditor<UnityEngine.Transform>
    {
    }
}
