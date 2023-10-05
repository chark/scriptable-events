using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "GameObjectScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Game Object Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityObjectEvent + 2
    )]
    public sealed class GameObjectScriptableEvent : ScriptableEvent<GameObject>
    {
    }
}
