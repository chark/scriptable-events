using ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(TransformScriptableEvent))]
    public class TransformScriptableEventEditor : BaseScriptableEventEditor<Transform>
    {
        protected override Transform DrawArgField(Transform value)
        {
            return ScriptableEventGUI.ObjectField(value, isAllowSceneObjects: true);
        }
    }
}
