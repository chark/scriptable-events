﻿using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "Collider2DScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Collider 2D Scriptable Event",
        order = ScriptableEventConstants.MenuOrderUnityObjectEvent + 0
    )]
    public sealed class Collider2DScriptableEvent : ScriptableEvent<Collider2D>
    {
    }
}
