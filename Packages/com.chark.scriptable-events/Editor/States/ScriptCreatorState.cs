using System;
using UnityEngine;

namespace CHARK.ScriptableEvents.Editor.States
{
    /// <summary>
    /// Holds state used in
    /// <see cref="ScriptableEvents.Editor.ScriptCreation.ScriptCreatorEditorWindow"/>.
    /// </summary>
    [Serializable]
    internal class ScriptCreatorState
    {
        #region Private Event Argument Fields

        [SerializeField]
        private bool isUseMonoScript = IsUseMonoScriptDefault;

        private const bool IsUseMonoScriptDefault = true;

        #endregion

        #region Private Event Fields

        [SerializeField]
        private string eventNamespace = EventNamespaceDefault;

        private const string EventNamespaceDefault = "ScriptableEvents.Events";

        [SerializeField]
        private bool isCreateEventNamespaceDirs = IsCreateEventNamespaceDireDefault;

        private const bool IsCreateEventNamespaceDireDefault = true;

        #endregion

        #region Private Listener Fields

        [SerializeField]
        private bool isCreateListener = IsCreateListenerDefault;

        private const bool IsCreateListenerDefault = true;

        [SerializeField]
        private string listenerNamespace = ListenerNamespaceDefault;

        private const string ListenerNamespaceDefault = "ScriptableEvents.Listeners";

        [SerializeField]
        private bool isCreateListenerNamespaceDirs = IsCreateListenerNamespaceDirsDefault;

        private const bool IsCreateListenerNamespaceDirsDefault = true;

        #endregion

        #region Private Editor Fields

        [SerializeField]
        private bool isCreateEditor = IsCreateEditorDefault;

        private const bool IsCreateEditorDefault = false;

        [SerializeField]
        private string editorNamespace = EditorNamespaceDefault;

        private const string EditorNamespaceDefault = "ScriptableEvents.Editor.Events";


        [SerializeField]
        private bool isCreateEditorNamespaceDirs = IsCreateEditorNamespaceDirsDefault;

        private const bool IsCreateEditorNamespaceDirsDefault = true;

        #endregion

        #region Private Utility Fields

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
        /// Should editor scripts be created. For default value refer to
        /// <see cref="IsCreateListenerDefault"/>.
        /// </summary>
        internal bool IsCreateListener
        {
            get => isCreateListener;
            set => isCreateListener = value;
        }

        /// <summary>
        /// Should event scripts create directories for namespaces. For default value refer to
        /// <see cref="IsCreateEventNamespaceDireDefault"/>.
        /// </summary>
        internal bool IsCreateEventNamespaceDirs
        {
            get => isCreateEventNamespaceDirs;
            set => isCreateEventNamespaceDirs = value;
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
        /// Should listener scripts create directories for namespaces. For default value refer to
        /// <see cref="IsCreateListenerNamespaceDirsDefault"/>.
        /// </summary>
        internal bool IsCreateListenerNamespaceDirs
        {
            get => isCreateListenerNamespaceDirs;
            set => isCreateListenerNamespaceDirs = value;
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
        /// Editor script namespace. For default value refer to
        /// <see cref="EditorNamespaceDefault"/>.
        /// </summary>
        internal string EditorNamespace
        {
            get => editorNamespace;
            set => editorNamespace = value;
        }

        /// <summary>
        /// Should editor scripts create directories for namespaces. For default value refer to
        /// <see cref="IsCreateEditorNamespaceDirsDefault"/>.
        /// </summary>
        internal bool IsCreateEditorNamespaceDirs
        {
            get => isCreateEditorNamespaceDirs;
            set => isCreateEditorNamespaceDirs = value;
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

        /// <summary>
        /// Does the current state match built-in defaults.
        /// </summary>
        internal bool IsBuiltInDefaults =>
            IsUseMonoScript == IsUseMonoScriptDefault
            && IsCreateEventNamespaceDirs == IsCreateEventNamespaceDireDefault
            && EventNamespace == EventNamespaceDefault
            && IsCreateListener == IsCreateListenerDefault
            && IsCreateListenerNamespaceDirs == IsCreateListenerNamespaceDirsDefault
            && ListenerNamespace == ListenerNamespaceDefault
            && IsCreateEditor == IsCreateEditorDefault
            && IsCreateEditorNamespaceDirs == IsCreateEditorNamespaceDirsDefault
            && EditorNamespace == EditorNamespaceDefault
            && ScriptDirectory == ScriptDirectoryDefault;

        #endregion

        #region Internal Methods

        /// <summary>
        /// Revert script creator state to built-in defaults.
        /// </summary>
        internal void RevertDefaults()
        {
            IsUseMonoScript = IsUseMonoScriptDefault;

            IsCreateEventNamespaceDirs = IsCreateEventNamespaceDireDefault;
            EventNamespace = EventNamespaceDefault;

            IsCreateListener = IsCreateListenerDefault;
            IsCreateListenerNamespaceDirs = IsCreateListenerNamespaceDirsDefault;
            ListenerNamespace = ListenerNamespaceDefault;

            IsCreateEditor = IsCreateEditorDefault;
            IsCreateEditorNamespaceDirs = IsCreateEditorNamespaceDirsDefault;
            EditorNamespace = EditorNamespaceDefault;

            ScriptDirectory = ScriptDirectoryDefault;
        }

        #endregion
    }
}
