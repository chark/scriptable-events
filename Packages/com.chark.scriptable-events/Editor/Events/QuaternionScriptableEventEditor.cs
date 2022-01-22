using ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(QuaternionScriptableEvent))]
    public class QuaternionScriptableEventEditor : BaseScriptableEventEditor<Quaternion>
    {
        protected override Quaternion DrawArgField(Quaternion value)
        {
            return ScriptableEventGUI.QuaternionField(value);
        }
    }
}
