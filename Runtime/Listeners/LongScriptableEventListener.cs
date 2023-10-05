﻿using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Long Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 2
    )]
    public sealed class LongScriptableEventListener : ScriptableEventListener<long>
    {
    }
}
