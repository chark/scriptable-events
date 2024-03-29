﻿using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Vector2 Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 0
    )]
    public sealed class Vector2ScriptableEventListener : ScriptableEventListener<Vector2>
    {
    }
}
