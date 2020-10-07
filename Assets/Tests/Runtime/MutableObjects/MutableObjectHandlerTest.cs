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
        [SetUp]
        public void SetUp()
        {
            MutableObjectHandler.OnReset = MutableObjectHandler.DefaultOnReset;
        }

        [UnityTest]
        public IEnumerator ShouldResetOnSceneChange()
        {
            var resetOnChange = new[] {false};

            MutableObjectHandler.OnReset = objects =>
                resetOnChange[0] = true;

            var active = SceneManager.GetActiveScene();
            yield return SceneManager.LoadSceneAsync(active.name);

            Assert.IsTrue(resetOnChange[0]);
        }

        [Test]
        public void ShouldResetMutableObject()
        {
            var probe = new MutableObjectProbe();

            MutableObjectHandler.ResetMutableObjectValues(
                new List<IMutableObject> {probe}
            );

            Assert.AreEqual(probe.ResetCount, 1);
            Assert.IsFalse(probe.Persisting);
        }

        [Test]
        public void ShouldNotResetPersistingMutableObject()
        {
            var probe = new MutableObjectProbe
            {
                Persisting = true
            };

            MutableObjectHandler.ResetMutableObjectValues(
                new List<IMutableObject> {probe},
                true
            );

            Assert.AreEqual(probe.ResetCount, 0);
            Assert.IsTrue(probe.Persisting);
        }
    }
}
