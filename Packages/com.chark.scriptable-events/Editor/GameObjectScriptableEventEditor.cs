using ScriptableEvents.GameObject;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(GameObjectScriptableEvent))]
    public class GameObjectScriptableEventEditor
        : TypedScriptableEventEditor<UnityEngine.GameObject>
    {
        protected override UnityEngine.GameObject DrawArgField(UnityEngine.GameObject value)
        {
            var fieldValue = EditorGUILayout
                .ObjectField(value, typeof(UnityEngine.GameObject), true);

            return fieldValue as UnityEngine.GameObject;
        }
    }
}
