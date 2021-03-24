using UnityEditor;

namespace ScriptableEvents.Editor
{
    public class BaseObjectScriptableEventEditor<TArg>
        : BaseScriptableEventEditor<TArg>
        where TArg : UnityEngine.Object
    {
        protected override TArg DrawArgField(TArg value)
        {
            return EditorGUILayout.ObjectField(value, typeof(TArg), true) as TArg;
        }
    }
}
