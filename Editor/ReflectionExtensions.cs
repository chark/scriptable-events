using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

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

        /// <returns>
        /// Scriptable Event icon attribute, can be null.
        /// </returns>
        internal static ScriptableEventIcon GetIconAttribute(this MonoScript monoScript)
        {
            var scriptType = monoScript.GetClass();
            if (scriptType == null)
            {
                return null;
            }

            var attribute = scriptType.GetCustomAttribute<ScriptableEventIcon>(true);

            return attribute;
        }

        /// <summary>
        /// Set editor icon for provided Object.
        /// </summary>
        internal static void SetIcon(this Object obj, Texture2D icon)
        {
            var editorUtilityType = typeof(EditorGUIUtility);
            var setIconMethod = editorUtilityType.GetMethod(
                "SetIconForObject",
                BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.NonPublic,
                null,
                new[] {typeof(Object), typeof(Texture2D)},
                null
            );

            if (setIconMethod == null)
            {
                return;
            }

            setIconMethod.Invoke(null, new object[] {obj, icon});
        }
    }
}
