﻿using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Vector2ScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Vector2 Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 0
    )]
    public class Vector2ScriptableEvent : BaseScriptableEvent<Vector2>
    {
    }
}
