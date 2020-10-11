using GameEvents.Generic;
using UnityEditor;

namespace GameEvents.Transform
{
    [CustomEditor(typeof(TransformGameEvent))]
    public class TransformGameEventEditor
        : ArgumentGameEventEditor<TransformGameEvent, UnityEngine.Transform>
    {
        protected override UnityEngine.Transform DrawArgumentField(UnityEngine.Transform value)
        {
            var fieldValue = EditorGUILayout
                .ObjectField(value, typeof(UnityEngine.Transform), true);

            return fieldValue as UnityEngine.Transform;
        }
    }
}
