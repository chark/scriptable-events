using System.Collections;
using System.Collections.Generic;
using MutableObjects.Generic;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

namespace MutableObjects
{
    public class MutableObjectHandlerTest
    {
        [UnityTest]
        public IEnumerable ShouldResetAppropriateObjects()
        {
            // The resetting tests must be in one test cases, otherwise problems with race
            // conditions arise (while testing).
            var probeNone = CreateObjectProbe(ResetType.None);
            var probeActiveSceneChange = CreateObjectProbe(ResetType.ActiveSceneChange);
            var probeSceneSceneLoaded = CreateObjectProbe(ResetType.SceneLoaded);
            var probeSceneUnloaded = CreateObjectProbe(ResetType.SceneUnloaded);

            var handler = new MutableObjectHandler(new List<IMutableObject>
            {
                probeNone,
                probeActiveSceneChange,
                probeSceneSceneLoaded,
                probeSceneUnloaded
            });

            RegisterSceneListeners(handler);

            yield return ReloadScene();

            Assert.AreEqual(0, probeNone.ResetCount);
            Assert.AreEqual(1, probeActiveSceneChange.ResetCount);
            Assert.AreEqual(1, probeSceneSceneLoaded.ResetCount);
            Assert.AreEqual(1, probeSceneUnloaded.ResetCount);
        }

        [Test]
        public void ShouldSetInitialValues()
        {
            var objectProbe = CreateObjectProbe(ResetType.None);
            var handler = new MutableObjectHandler(
                new List<IMutableObject> {objectProbe}
            );

            handler.SetInitialMutableObjectValues();

            Assert.AreEqual(1, objectProbe.ResetCount);
        }

        private static MutableObjectProbe CreateObjectProbe(ResetType resetType)
        {
            return new MutableObjectProbe
            {
                ResetType = resetType
            };
        }

        private static void RegisterSceneListeners(MutableObjectHandler handler)
        {
            SceneManager.activeSceneChanged += (curr, next) => handler.ResetActiveSceneChange();
            SceneManager.sceneUnloaded += scene => handler.ResetSceneUnloaded();
            SceneManager.sceneLoaded += (scene, mode) => handler.ResetSceneLoaded();
        }

        private static IEnumerator ReloadScene()
        {
            var active = SceneManager.GetActiveScene();
            var loaded = SceneManager.LoadSceneAsync(active.name);

            loaded.allowSceneActivation = true;

            while (!loaded.isDone)
            {
                yield return null;
            }
        }
    }
}
