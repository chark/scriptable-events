using CHARK.ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace CHARK.ScriptableEvents.Editor.Events
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
