using GameEvents.Generic;
using UnityEditor;

namespace GameEvents.Float
{
    [CustomEditor(typeof(FloatGameEvent))]
    public class FloatGameEventEditor : ArgumentGameEventEditor<FloatGameEvent, float>
    {
        protected override float DrawArgumentField(float value)
        {
            return EditorGUILayout.FloatField(value);
        }
    }
}
