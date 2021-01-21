using GameEvents.GameObject;
using UnityEditor;

namespace GameEvents.Editor
{
    [CustomEditor(typeof(GameObjectGameEvent))]
    public class GameObjectGameEventEditor
        : BaseGameEventEditor<GameObjectGameEvent, UnityEngine.GameObject>
    {
        protected override UnityEngine.GameObject DrawArgField(UnityEngine.GameObject value)
        {
            var fieldValue = EditorGUILayout
                .ObjectField(value, typeof(UnityEngine.GameObject), true);

            return fieldValue as UnityEngine.GameObject;
        }
    }
}
