using System.Reflection;

namespace ScriptableEvents.Tests.Runtime
{
    internal static class TestExtensions
    {
        private const BindingFlags PrivateFieldBindingFlags =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;

        /// <summary>
        /// Set private field value with give name on this object.
        /// </summary>
        internal static void SetField(this object obj, string name, object value)
        {
            var field = obj.GetField(name);
            field.SetValue(obj, value);
        }

        /// <returns>
        /// Private field from this this with given name.
        /// </returns>
        internal static FieldInfo GetField(this object obj, string name)
        {
            var type = obj.GetType();

            FieldInfo info;
            do
            {
                info = type.GetField(name, PrivateFieldBindingFlags);
            } while (info == null && (type = type.BaseType) != null);

            return info;
        }
    }
}
