using System.Collections.Generic;
using UnityEngine;

namespace ScriptableEvents
{
    public abstract class BaseScriptableEvent : ScriptableObject
    {
        #region Internal Properties

        internal abstract IEnumerable<object> Listeners { get; }

        #endregion
    }
}
