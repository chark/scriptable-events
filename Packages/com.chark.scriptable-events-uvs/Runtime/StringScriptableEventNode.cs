using Unity.VisualScripting;

namespace CHARK.ScriptableEvents.VisualScripting
{
    internal class StringComponent : ListenerComponent<string>
    {
    }

    [UnitCategory("CHARK/ScriptableEvents")]
    [UnitTitle("String Scriptable Event Listener")]
    internal class StringListener : ListenerNode<string, StringComponent>
    {
    }
}
