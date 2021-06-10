using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(BaseScriptableEvent<>), true)]
    internal class FallbackScriptableEventEditor : BaseScriptableEventEditor
    {
    }
}
