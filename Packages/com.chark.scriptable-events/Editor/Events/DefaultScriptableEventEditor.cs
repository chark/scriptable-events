using UnityEditor;

namespace CHARK.ScriptableEvents.Editor.Events
{
    /// <summary>
    /// Default editor for Scriptable Events which don't have an explicit editor.
    /// </summary>
    [CustomEditor(typeof(BaseScriptableEvent), true, isFallback = true)]
    internal class DefaultScriptableEventEditor : BaseScriptableEventEditor
    {
    }
}
