﻿using UnityEngine;

namespace ScriptableEvents.CustomEvents
{
    public class MaterialData
    {
        public float Metallic { get; }

        public Color Color { get; }

        public MaterialData(float metallic, Color color)
        {
            Metallic = metallic;
            Color = color;
        }
    }
}
