﻿using ScriptableEvents.Events;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(ColliderScriptableEvent))]
    public class ColliderScriptableEventEditor : BaseScriptableEventEditor<Collider>
    {
        protected override Collider DrawArgField(Collider value)
        {
            return ScriptableEventGUI.ObjectField(value, isAllowSceneObjects: true);
        }
    }
}
