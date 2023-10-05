using System;
using System.Collections.Generic;
using UnityEngine;

namespace CHARK.ScriptableEvents.Editor.States
{
    /// <summary>
    /// Holds state used in <see cref="ScriptableEvents.Editor.Icons.IconPostProcessor"/>.
    /// </summary>
    [Serializable]
    internal class IconState
    {
        #region Private Fields

        [SerializeField]
        private List<string> pendingAssetPaths = new List<string>();

        #endregion

        #region Internal Properties

        /// <summary>
        /// Key which determines where the icon state is persisted.
        /// </summary>
        internal static string Key => typeof(IconState).FullName;

        /// <summary>
        /// Collection of asset paths which need to be processed.
        /// </summary>
        internal IReadOnlyCollection<string> PendingAssetPaths => pendingAssetPaths;

        #endregion

        #region Internal Methods

        /// <summary>
        /// Add asset paths for icon processing.
        /// </summary>
        internal void AddPendingAssetPaths(IEnumerable<string> paths)
        {
            pendingAssetPaths.AddRange(paths);
        }

        /// <summary>
        /// Remove all pending asset paths for icon processing.
        /// </summary>
        internal void ClearPendingAssetPaths()
        {
            pendingAssetPaths.Clear();
        }

        #endregion
    }
}
