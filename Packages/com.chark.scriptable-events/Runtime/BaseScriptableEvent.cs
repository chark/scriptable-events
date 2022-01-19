using System.Collections.Generic;
using UnityEngine;

namespace ScriptableEvents
{
    /// <summary>
    /// Base Scriptable Event class. Used in internal editor scripts.
    /// </summary>
    [ScriptableIcon(ScriptableIconType.Event)]
    public abstract class BaseScriptableEvent : ScriptableObject
    {
        #region Internal Properties

        /// <summary>
        /// Listeners added to this event. Used in inspector GUIs.
        /// </summary>
        internal abstract IEnumerable<object> Listeners { get; }

        /// <summary>
        /// Count of listeners added to this event. Used in inspector GUIs.
        /// </summary>
        internal abstract int ListenerCount { get; }

        #endregion
    }
}
