using UnityEngine;

namespace ScriptableEvents.String
{
    [CreateAssetMenu(
        fileName = "StringScriptableEvent",
        menuName = "Scriptable Events/String Scriptable Event",
        order = 5
    )]
    public class StringScriptableEvent : BaseScriptableEvent<string>
    {
    }
}
