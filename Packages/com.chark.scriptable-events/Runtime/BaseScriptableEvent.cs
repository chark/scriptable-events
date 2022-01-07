using System.Collections;
using UnityEngine;

namespace ScriptableEvents
{
    /// <summary>
    /// Base "marker" scriptable event class. Necessary to show inspector GUIs for events which
    /// have no explicitly defined editor scripts.
    /// </summary>
    public abstract class BaseScriptableEvent : ScriptableObject
    {
        #region Internal Properties

        /// <summary>
        /// Listeners added to this scriptable object. Used in inspector GUIs.
        /// </summary>
        internal abstract IEnumerable Listeners { get; }

        #endregion
    }
}
