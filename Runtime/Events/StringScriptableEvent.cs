﻿using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "StringScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/String Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 5
    )]
    public class StringScriptableEvent : BaseScriptableEvent<string>
    {
    }
}
