using System;

namespace ScriptableEvents.Editor.States
{
    /// <summary>
    /// Holds state used in script creation.
    /// </summary>
    [Serializable]
    internal class ScriptCreatorState
    {
        #region Internal Properties

        /// <summary>
        /// Key which determines where the script creation state is persisted.
        /// </summary>
        internal static string Key => typeof(ScriptCreatorState).FullName;

        #endregion
    }
}
