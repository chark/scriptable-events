using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.States
{
    /// <summary>
    /// Retrieves and persists state used in editor tools.
    /// </summary>
    internal static class ScriptableEventEditorState
    {
        #region Internal Properties

        /// <summary>
        /// Persisted script creator state.
        /// </summary>
        internal static ScriptCreatorState ScriptCreatorState
        {
            get => GetState<ScriptCreatorState>(ScriptCreatorState.Key) ?? new ScriptCreatorState();
            set => SetState(ScriptCreatorState.Key, value);
        }

        /// <summary>
        /// Persisted icon state.
        /// </summary>
        internal static IconState IconState
        {
            get => GetState<IconState>(IconState.Key) ?? new IconState();
            set => SetState(IconState.Key, value);
        }

        #endregion

        #region Private Methods

        private static T GetState<T>(string key)
        {
            var json = EditorPrefs.GetString(key);
            if (string.IsNullOrWhiteSpace(json))
            {
                return default;
            }

            return JsonUtility.FromJson<T>(json);
        }

        private static void SetState<T>(string key, T state)
        {
            var json = JsonUtility.ToJson(state);
            EditorPrefs.SetString(key, json);
        }

        #endregion
    }
}
