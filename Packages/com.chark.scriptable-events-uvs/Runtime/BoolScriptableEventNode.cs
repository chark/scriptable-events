using CHARK.ScriptableEvents.Events;
using Unity.VisualScripting;

namespace CHARK.ScriptableEvents.VisualScripting
{
    internal class BoolComponent : ListenerComponent<bool>
    {
    }

    [UnitCategory("CHARK/ScriptableEvents")]
    [UnitTitle("Bool Scriptable Event Listener")]
    internal class BoolListener : ListenerNode<bool, BoolComponent>
    {
    }
}
