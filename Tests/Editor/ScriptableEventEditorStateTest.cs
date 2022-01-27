using System.Linq;
using NUnit.Framework;
using ScriptableEvents.Editor.States;
using UnityEditor;

namespace ScriptableEvents.Tests.Editor
{
    [TestFixture]
    internal class ScriptableEventEditorStateTest
    {
        #region Private Fields

        #endregion

        #region Public Methods

        [SetUp]
        public void SetUpEditorPrefs()
        {
            EditorPrefs.DeleteAll();
        }

        [TearDown]
        public void TearDownEditorPrefs()
        {
            EditorPrefs.DeleteAll();
        }

        [Test]
        public void ShouldAddPendingAssetPathInIconState()
        {
            const string firstPendingAssetPath = "test";
            const string secondPendingAssetPath = "test";

            var initialState = ScriptableEventEditorState.IconState;
            initialState.AddPendingAssetPaths(new[] {firstPendingAssetPath});
            initialState.AddPendingAssetPaths(new[] {secondPendingAssetPath});
            ScriptableEventEditorState.IconState = initialState;

            var finalState = ScriptableEventEditorState.IconState;
            var pendingAssetPaths = finalState.PendingAssetPaths;

            Assert.IsTrue(pendingAssetPaths.Contains(firstPendingAssetPath));
            Assert.IsTrue(pendingAssetPaths.Contains(secondPendingAssetPath));
        }

        [Test]
        public void ShouldAddAndClearPendingAssetPathInIconState()
        {
            const string testPath = "test";

            var initialState = ScriptableEventEditorState.IconState;
            initialState.AddPendingAssetPaths(new[] {testPath});
            ScriptableEventEditorState.IconState = initialState;

            var clearedState = ScriptableEventEditorState.IconState;
            clearedState.ClearPendingAssetPaths();
            ScriptableEventEditorState.IconState = clearedState;

            var finalState = ScriptableEventEditorState.IconState;
            var pendingAssetPaths = finalState.PendingAssetPaths;
            Assert.IsEmpty(pendingAssetPaths);
        }

        [Test]
        public void ShouldGetScriptCreatorState()
        {
            var state = ScriptableEventEditorState.ScriptCreatorState;
            AssetIsDefaultValues(state);
        }

        [Test]
        public void ShouldSetScriptCreatorState()
        {
            var initialState = ScriptableEventEditorState.ScriptCreatorState;
            SetTestValues(initialState);
            ScriptableEventEditorState.ScriptCreatorState = initialState;

            var finalState = ScriptableEventEditorState.ScriptCreatorState;
            AssetIsTestValues(finalState);
        }

        [Test]
        public void ShouldResetScriptCreatorState()
        {
            var initialState = ScriptableEventEditorState.ScriptCreatorState;
            SetTestValues(initialState);
            ScriptableEventEditorState.ScriptCreatorState = initialState;

            var resetState = ScriptableEventEditorState.ScriptCreatorState;
            resetState.ResetDefaults();
            ScriptableEventEditorState.ScriptCreatorState = resetState;

            var finalState = ScriptableEventEditorState.ScriptCreatorState;
            AssetIsDefaultValues(finalState);
        }

        #endregion

        #region Private Methods

        private static void SetTestValues(ScriptCreatorState state)
        {
            // These values use inverted default values (booleans at least).
            state.IsUseMonoScript = false;

            state.IsCreateEventNamespaceDirectories = false;
            state.EventNamespace = "ScriptableEvents.Events (test)";

            state.IsCreateListener = false;
            state.IsCreateListenerNamespaceDirectories = false;
            state.ListenerNamespace = "ScriptableEvents.Listeners (test)";

            state.IsCreateEditor = true;
            state.IsCreateEditorNamespaceDirectories = false;
            state.EditorNamespace = "ScriptableEvents.Editor.Events (test)";

            state.ScriptDirectory = "Assets/Scripts (test)";
        }

        private static void AssetIsTestValues(ScriptCreatorState state)
        {
            Assert.IsFalse(state.IsUseMonoScript);

            Assert.IsFalse(state.IsCreateEventNamespaceDirectories);
            Assert.AreEqual(state.EventNamespace, "ScriptableEvents.Events (test)");

            Assert.IsFalse(state.IsCreateListener);
            Assert.IsFalse(state.IsCreateListenerNamespaceDirectories);
            Assert.AreEqual(state.ListenerNamespace, "ScriptableEvents.Listeners (test)");

            Assert.IsTrue(state.IsCreateEditor);
            Assert.IsFalse(state.IsCreateEditorNamespaceDirectories);
            Assert.AreEqual(state.EditorNamespace, "ScriptableEvents.Editor.Events (test)");

            Assert.AreEqual(state.ScriptDirectory, "Assets/Scripts (test)");
        }

        private static void AssetIsDefaultValues(ScriptCreatorState state)
        {
            Assert.IsTrue(state.IsUseMonoScript);

            Assert.IsTrue(state.IsCreateEventNamespaceDirectories);
            Assert.AreEqual(state.EventNamespace, "ScriptableEvents.Events");

            Assert.IsTrue(state.IsCreateListener);
            Assert.IsTrue(state.IsCreateListenerNamespaceDirectories);
            Assert.AreEqual(state.ListenerNamespace, "ScriptableEvents.Listeners");

            Assert.IsFalse(state.IsCreateEditor);
            Assert.IsTrue(state.IsCreateEditorNamespaceDirectories);
            Assert.AreEqual(state.EditorNamespace, "ScriptableEvents.Editor.Events");

            Assert.AreEqual(state.ScriptDirectory, "Assets/Scripts");
        }

        #endregion
    }
}
