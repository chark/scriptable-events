using System;

namespace ScriptableEvents
{
    internal enum ScriptableIconType
    {
        Event,
        Listener
    }

    /// <summary>
    /// Used to tag assets (mono scripts) which must have an icon.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    internal class ScriptableIcon : Attribute
    {
        #region Internal Properties

        /// <summary>
        /// Name of the icon to use for this asset.
        /// </summary>
        internal ScriptableIconType Type { get; }

        #endregion

        #region Internal Methods

        internal ScriptableIcon(ScriptableIconType type)
        {
            Type = type;
        }

        #endregion
    }
}
