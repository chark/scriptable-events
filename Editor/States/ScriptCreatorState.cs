using System;
using UnityEngine;

namespace ScriptableEvents.Editor.States
{
    /// <summary>
    /// Holds state used in script creation.
    /// </summary>
    [Serializable]
    internal class ScriptCreatorState
    {
        #region Private Fields

        // Event arg script fields.
        [SerializeField]
        private bool isUseMonoScript = IsUseMonoScriptDefault;

        private const bool IsUseMonoScriptDefault = true;

        // Event script fields.
        [SerializeField]
        private string eventNamespace = EventNamespaceDefault;

        private const string EventNamespaceDefault = "ScriptableEvents.Events";

        [SerializeField]
        private bool isCreateEventNamespaceDirectories = IsCreateEventNamespaceDirectoriesDefault;

        private const bool IsCreateEventNamespaceDirectoriesDefault = true;

        // Listener script fields.
        [SerializeField]
        private bool isCreateListener = IsCreateListenerDefault;

        private const bool IsCreateListenerDefault = true;

        [SerializeField]
        private bool isCreateListenerNamespaceDirectories =
            IsCreateListenerNamespaceDirectoriesDefault;

        private const bool IsCreateListenerNamespaceDirectoriesDefault = true;

        [SerializeField]
        private string listenerNamespace = ListenerNamespaceDefault;

        private const string ListenerNamespaceDefault = "ScriptableEvents.Listeners";

        // Editor script fields.
        [SerializeField]
        private bool isCreateEditor = IsCreateEditorDefault;

        private const bool IsCreateEditorDefault = false;

        [SerializeField]
        private bool isCreateEditorNamespaceDirectories = IsCreateEditorNamespaceDirectoriesDefault;

        private const bool IsCreateEditorNamespaceDirectoriesDefault = true;

        [SerializeField]
        private string editorNamespace = EditorNamespaceDefault;

        private const string EditorNamespaceDefault = "ScriptableEvents.Editor.Events";

        // Script output fields.
        [SerializeField]
        private string scriptDirectory = ScriptDirectoryDefault;

        private const string ScriptDirectoryDefault = "Assets/Scripts";

        #endregion

        #region Internal Properties

        /// <summary>
        /// Key which determines where the script creation state is persisted.
        /// </summary>
        internal static string Key => typeof(ScriptCreatorState).FullName;

        /// <summary>
        /// Should mono script be used to retrieve the argument script type. For default value refer
        /// to <see cref="IsUseMonoScriptDefault"/>.
        /// </summary>
        internal bool IsUseMonoScript
        {
            get => isUseMonoScript;
            set => isUseMonoScript = value;
        }

        /// <summary>
        /// Event script namespace. For default value refer to
        /// <see cref="EventNamespaceDefault"/>.
        /// </summary>
        internal string EventNamespace
        {
            get => eventNamespace;
            set => eventNamespace = value;
        }

        /// <summary>
        /// Should event scripts create directories for namespaces. For default value refer to
        /// <see cref="IsCreateEventNamespaceDirectoriesDefault"/>.
        /// </summary>
        internal bool IsCreateEventNamespaceDirectories
        {
            get => isCreateEventNamespaceDirectories;
            set => isCreateEventNamespaceDirectories = value;
        }

        /// <summary>
        /// Should editor scripts be created. For default value refer to
        /// <see cref="IsCreateListenerDefault"/>.
        /// </summary>
        internal bool IsCreateListener
        {
            get => isCreateListener;
            set => isCreateListener = value;
        }

        /// <summary>
        /// Should listener scripts create directories for namespaces. For default value refer to
        /// <see cref="IsCreateListenerNamespaceDirectoriesDefault"/>.
        /// </summary>
        internal bool IsCreateListenerNamespaceDirectories
        {
            get => isCreateListenerNamespaceDirectories;
            set => isCreateListenerNamespaceDirectories = value;
        }

        /// <summary>
        /// Listener script namespace. For default value refer to
        /// <see cref="ListenerNamespaceDefault"/>.
        /// </summary>
        internal string ListenerNamespace
        {
            get => listenerNamespace;
            set => listenerNamespace = value;
        }

        /// <summary>
        /// Should editor scripts be created. For default value refer to
        /// <see cref="IsCreateEditorDefault"/>.
        /// </summary>
        internal bool IsCreateEditor
        {
            get => isCreateEditor;
            set => isCreateEditor = value;
        }

        /// <summary>
        /// Should editor scripts create directories for namespaces. For default value refer to
        /// <see cref="IsCreateEditorNamespaceDirectoriesDefault"/>.
        /// </summary>
        internal bool IsCreateEditorNamespaceDirectories
        {
            get => isCreateEditorNamespaceDirectories;
            set => isCreateEditorNamespaceDirectories = value;
        }

        /// <summary>
        /// Editor script namespace. For default value refer to
        /// <see cref="EditorNamespaceDefault"/>.
        /// </summary>
        internal string EditorNamespace
        {
            get => editorNamespace;
            set => editorNamespace = value;
        }

        /// <summary>
        /// Where to output the scripts. For default value refer to
        /// <see cref="ScriptDirectoryDefault"/>.
        /// </summary>
        internal string ScriptDirectory
        {
            get => scriptDirectory;
            set => scriptDirectory = value;
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Reset script creator state to defaults.
        /// </summary>
        internal void ResetDefaults()
        {
            IsUseMonoScript = IsUseMonoScriptDefault;

            IsCreateEventNamespaceDirectories = IsCreateEventNamespaceDirectoriesDefault;
            EventNamespace = EventNamespaceDefault;

            IsCreateListener = IsCreateListenerDefault;
            IsCreateListenerNamespaceDirectories = IsCreateListenerNamespaceDirectoriesDefault;
            ListenerNamespace = ListenerNamespaceDefault;

            IsCreateEditor = IsCreateEditorDefault;
            IsCreateEditorNamespaceDirectories = IsCreateEditorNamespaceDirectoriesDefault;
            EditorNamespace = EditorNamespaceDefault;

            ScriptDirectory = ScriptDirectoryDefault;
        }

        #endregion
    }
}
