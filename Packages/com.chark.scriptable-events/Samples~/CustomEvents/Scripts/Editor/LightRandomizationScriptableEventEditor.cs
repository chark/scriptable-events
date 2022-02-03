using ScriptableEvents.Editor;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Samples.CustomEvents.Editor
{
    [CustomEditor(typeof(LightRandomizationScriptableEvent))]
    public class LightRandomizationScriptableEventEditor : BaseScriptableEventEditor<LightRandomizationEventArgs>
    {
        protected override LightRandomizationEventArgs DrawArgField(
            LightRandomizationEventArgs value
        )
        {
            if (value == null)
            {
                value = new LightRandomizationEventArgs();
            }

            EditorGUILayout.BeginVertical();
            value.Intensity = EditorGUILayout.FloatField("Intensity", value.Intensity);
            value.Intensity = Mathf.Max(0, value.Intensity);

            value.Color = EditorGUILayout.ColorField("Color", value.Color);
            EditorGUILayout.EndVertical();

            return value;
        }
    }
}
