using System.Collections;
using UnityEngine;

namespace ScriptableEvents
{
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
