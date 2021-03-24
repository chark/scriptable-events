using ScriptableEvents.GameObject;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(GameObjectScriptableEvent))]
    public class GameObjectScriptableEventEditor
        : BaseObjectScriptableEventEditor<UnityEngine.GameObject>
    {
    }
}
