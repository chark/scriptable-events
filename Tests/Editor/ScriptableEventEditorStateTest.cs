using System.Linq;
using CHARK.ScriptableEvents.Editor.States;
using NUnit.Framework;
using UnityEditor;

namespace CHARK.ScriptableEvents.Tests.Editor
{
    [TestFixture]
    internal class ScriptableEventEditorStateTest
    {
        #region Private Fields

        #endregion

        #region Public Methods

        [SetUp]
        public void SetUp()
        {
            CleanupEditorPrefs();
        }

        [TearDown]
        public void TearDown()
        {
            CleanupEditorPrefs();
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
            AssetIsBuiltInDefaults(state);
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
        public void ShouldRevertScriptCreatorState()
        {
            var initialState = ScriptableEventEditorState.ScriptCreatorState;
            SetTestValues(initialState);
            ScriptableEventEditorState.ScriptCreatorState = initialState;

            var resetState = ScriptableEventEditorState.ScriptCreatorState;
            resetState.RevertDefaults();
            ScriptableEventEditorState.ScriptCreatorState = resetState;

            var finalState = ScriptableEventEditorState.ScriptCreatorState;
            AssetIsBuiltInDefaults(finalState);
        }

        #endregion

        #region Private Methods

        private static void CleanupEditorPrefs()
        {
            EditorPrefs.DeleteKey(ScriptCreatorState.Key);
            EditorPrefs.DeleteKey(IconState.Key);
        }

        private static void SetTestValues(ScriptCreatorState state)
        {
            // These values use inverted default values (booleans at least).
            state.IsUseMonoScript = false;

            state.EventNamespace = "ScriptableEvents.Events (test)";
            state.IsCreateEventNamespaceDirs = false;

            state.IsCreateListener = false;
            state.ListenerNamespace = "ScriptableEvents.Listeners (test)";
            state.IsCreateListenerNamespaceDirs = false;

            state.IsCreateEditor = true;
            state.EditorNamespace = "ScriptableEvents.Editor.Events (test)";
            state.IsCreateEditorNamespaceDirs = false;

            state.ScriptDirectory = "Assets/Scripts (test)";
        }

        private static void AssetIsTestValues(ScriptCreatorState state)
        {
            Assert.IsFalse(state.IsUseMonoScript);

            Assert.AreEqual(state.EventNamespace, "ScriptableEvents.Events (test)");
            Assert.IsFalse(state.IsCreateEventNamespaceDirs);

            Assert.IsFalse(state.IsCreateListener);
            Assert.AreEqual(state.ListenerNamespace, "ScriptableEvents.Listeners (test)");
            Assert.IsFalse(state.IsCreateListenerNamespaceDirs);

            Assert.IsTrue(state.IsCreateEditor);
            Assert.AreEqual(state.EditorNamespace, "ScriptableEvents.Editor.Events (test)");
            Assert.IsFalse(state.IsCreateEditorNamespaceDirs);

            Assert.AreEqual(state.ScriptDirectory, "Assets/Scripts (test)");
        }

        private static void AssetIsBuiltInDefaults(ScriptCreatorState state)
        {
            Assert.IsTrue(state.IsUseMonoScript);

            Assert.AreEqual(state.EventNamespace, "ScriptableEvents.Events");
            Assert.IsTrue(state.IsCreateEventNamespaceDirs);

            Assert.IsTrue(state.IsCreateListener);
            Assert.AreEqual(state.ListenerNamespace, "ScriptableEvents.Listeners");
            Assert.IsTrue(state.IsCreateListenerNamespaceDirs);

            Assert.IsFalse(state.IsCreateEditor);
            Assert.AreEqual(state.EditorNamespace, "ScriptableEvents.Editor.Events");
            Assert.IsTrue(state.IsCreateEditorNamespaceDirs);

            Assert.AreEqual(state.ScriptDirectory, "Assets/Scripts");

            Assert.IsTrue(state.IsBuiltInDefaults);
        }

        #endregion
    }
}
