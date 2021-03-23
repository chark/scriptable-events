using UnityEngine;

namespace ScriptableEvents.String
{
    [CreateAssetMenu(
        fileName = "StringScriptableEvent",
        menuName = "Scriptable Events/String Scriptable Event",
        order = 4
    )]
    public class StringScriptableEvent : BaseScriptableEvent<string>
    {
    }
}
