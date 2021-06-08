using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Collider2DScriptableEvent",
        menuName = "Scriptable Events/Collider 2D Scriptable Event",
        order = 200
    )]
    public class Collider2DScriptableEvent : BaseScriptableEvent<Collider2D>
    {
    }
}
