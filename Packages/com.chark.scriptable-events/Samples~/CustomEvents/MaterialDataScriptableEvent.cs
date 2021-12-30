using UnityEngine;

namespace ScriptableEvents.CustomEvents
{
    [CreateAssetMenu(
        fileName = "MaterialDataScriptableEvent",
        menuName = "Custom Scriptable Events/Material Data Scriptable Event"
    )]
    public class MaterialDataScriptableEvent : BaseScriptableEvent<MaterialData>
    {
    }
}
