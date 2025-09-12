using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "GameObjectScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Game Object Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityObjectEvent
    )]
    public sealed class GameObjectScriptableEvent : ScriptableEvent<GameObject>
    {
    }
}
