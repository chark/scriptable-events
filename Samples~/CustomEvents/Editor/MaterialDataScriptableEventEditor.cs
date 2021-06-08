using ScriptableEvents.Editor;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Samples.CustomEvents.Editor
{
    [CustomEditor(typeof(MaterialDataScriptableEvent))]
    public class MaterialDataScriptableEventEditor : TypedScriptableEventEditor<MaterialData>
    {
        protected override MaterialData DrawArgField(MaterialData value)
        {
            if (value == null)
            {
                value = new MaterialData(0f, Color.white);
            }

            EditorGUILayout.BeginVertical();
            var metallic = EditorGUILayout.Slider("Metallic", value.Metallic, 0f, 1f);
            var color = EditorGUILayout.ColorField("Color", value.Color);
            EditorGUILayout.EndVertical();

            return new MaterialData(metallic, color);
        }
    }
}
