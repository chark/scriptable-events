using GameEvents.Transform;
using UnityEditor;

namespace GameEvents.Editor
{
    [CustomEditor(typeof(TransformGameEvent))]
    public class TransformGameEventEditor
        : BaseGameEventEditor<TransformGameEvent, UnityEngine.Transform>
    {
        protected override UnityEngine.Transform DrawArgField(UnityEngine.Transform value)
        {
            var fieldValue = EditorGUILayout
                .ObjectField(value, typeof(UnityEngine.Transform), true);

            return fieldValue as UnityEngine.Transform;
        }
    }
}
