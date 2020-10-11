using GameEvents.Generic;
using UnityEditor;

namespace GameEvents.GameObject
{
    [CustomEditor(typeof(GameObjectGameEvent))]
    public class GameObjectGameEventEditor
        : ArgumentGameEventEditor<GameObjectGameEvent, UnityEngine.GameObject>
    {
        protected override UnityEngine.GameObject DrawArgumentField(UnityEngine.GameObject value)
        {
            var fieldValue = EditorGUILayout
                .ObjectField(value, typeof(UnityEngine.GameObject), true);

            return fieldValue as UnityEngine.GameObject;
        }
    }
}
