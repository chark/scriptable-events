using ScriptableEvents.Transform;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(TransformScriptableEvent))]
    public class TransformScriptableEventEditor : TypedScriptableEventEditor<UnityEngine.Transform>
    {
        protected override UnityEngine.Transform DrawArgField(UnityEngine.Transform value)
        {
            var fieldValue = EditorGUILayout
                .ObjectField(value, typeof(UnityEngine.Transform), true);

            return fieldValue as UnityEngine.Transform;
        }
    }
}
