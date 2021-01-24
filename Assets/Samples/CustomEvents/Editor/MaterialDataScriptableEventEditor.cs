using ScriptableEvents.Editor;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.CustomEvents.Editor
{
    [CustomEditor(typeof(MaterialDataScriptableEvent))]
    public class MaterialDataScriptableEventEditor : BaseScriptableEventEditor<MaterialData>
    {
        protected override MaterialData DrawArgField(MaterialData value)
        {
            if (value == null)
            {
                return new MaterialData(0f, Color.white);
            }

            EditorGUILayout.BeginVertical();
            var metallic = EditorGUILayout.Slider("Metallic", value.Metallic, 0f, 1f);
            var color = EditorGUILayout.ColorField("Color", value.Color);
            EditorGUILayout.EndVertical();

            return new MaterialData(metallic, color);
        }
    }
}
