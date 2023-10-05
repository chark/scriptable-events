﻿using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Color Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 5
    )]
    public sealed class ColorScriptableEventListener : ScriptableEventListener<Color>
    {
    }
}
