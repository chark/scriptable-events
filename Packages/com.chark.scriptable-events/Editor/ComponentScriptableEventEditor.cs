using ScriptableEvents.Component;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(ComponentScriptableEvent))]
    public class ComponentScriptableEventEditor : BaseScriptableEventEditor<UnityEngine.Component>
    {
        protected override UnityEngine.Component DrawArgField(UnityEngine.Component value)
        {
            var fieldValue = EditorGUILayout
                .ObjectField(value, typeof(UnityEngine.Component), true);

            return fieldValue as UnityEngine.Component;
        }
    }
}
