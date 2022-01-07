using UnityEditor;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Default editor for Scriptable Events which don't an explicit editor.
    /// </summary>
    [CustomEditor(typeof(BaseScriptableEvent), true, isFallback = true)]
    internal class FallbackScriptableEventEditor : BaseScriptableEventEditor
    {
    }
}
