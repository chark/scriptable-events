using GameEvents.Float;
using UnityEditor;

namespace GameEvents.Editor
{
    [CustomEditor(typeof(FloatGameEvent))]
    public class FloatGameEventEditor : BaseGameEventEditor<FloatGameEvent, float>
    {
        protected override float DrawArgField(float value)
        {
            return EditorGUILayout.FloatField(value);
        }
    }
}
