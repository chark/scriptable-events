using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(BaseScriptableEvent), true, isFallback = true)]
    internal class FallbackScriptableEventEditor : BaseScriptableEventEditor
    {
    }
}
