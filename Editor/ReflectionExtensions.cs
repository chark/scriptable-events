using System;
using System.Reflection;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Extensions to fetch values via reflection.
    /// </summary>
    internal static class ReflectionExtensions
    {
        /// <returns>
        /// Tooltip text from a given field.
        /// </returns>
        internal static string GetTooltip(
            this Type type,
            string fieldName,
            BindingFlags bindingFlags = BindingFlags.Instance |
                                        BindingFlags.NonPublic |
                                        BindingFlags.DeclaredOnly
        )
        {
            var field = type.GetField(fieldName, bindingFlags);

            // ReSharper disable once AssignNullToNotNullAttribute
            var attribute = field.GetCustomAttribute<TooltipAttribute>();

            return attribute.tooltip;
        }

        /// <returns>
        /// Value of specified type and name on an object instance.
        /// </returns>
        internal static T GetFieldValue<T>(
            this object obj,
            string fieldName,
            BindingFlags bindingFlags = BindingFlags.Instance |
                                        BindingFlags.NonPublic
        )
        {
            var type = obj.GetType();

            FieldInfo info;
            do
            {
                info = type.GetField(fieldName, bindingFlags);
            } while (info == null && (type = type.BaseType) != null);

            if (info == null)
            {
                return default;
            }

            return (T) info.GetValue(obj);
        }
    }
}
