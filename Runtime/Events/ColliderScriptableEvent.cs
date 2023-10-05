﻿using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ColliderScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Collider Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityObjectEvent + 1
    )]
    public sealed class ColliderScriptableEvent : ScriptableEvent<Collider>
    {
    }
}
