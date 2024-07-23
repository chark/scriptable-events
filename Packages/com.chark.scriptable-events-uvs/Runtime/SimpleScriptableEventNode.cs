using CHARK.ScriptableEvents.Events;
using Unity.VisualScripting;

namespace CHARK.ScriptableEvents.VisualScripting
{
    internal class SimpleComponent : ListenerComponent<SimpleArg>
    {
    }

    [UnitCategory("CHARK/ScriptableEvents")]
    [UnitTitle("Simple Scriptable Event Listener")]
    internal class SimpleListener : ListenerNode<SimpleArg, SimpleComponent>
    {
    }
}
