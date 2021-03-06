﻿using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ColliderScriptableEvent",
        menuName = "Scriptable Events/Collider Scriptable Event",
        order = 201
    )]
    public class ColliderScriptableEvent : BaseScriptableEvent<Collider>
    {
    }
}
