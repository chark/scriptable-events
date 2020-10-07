using MutableObjects.Bool;
using MutableObjects.Float;
using MutableObjects.String;
using MutableObjects.Vector2;
using MutableObjects.Vector3;
using NUnit.Framework;
using UnityEngine;
using Assert = UnityEngine.Assertions.Assert;

namespace MutableObjects
{
    public class MutableObjectTest
    {
        [Test]
        public void ShouldSetAndResetMutableBool()
        {
            var mutable = ScriptableObject.CreateInstance<MutableBool>();
            mutable.Value = true;

            Assert.AreEqual(mutable.Value, true);

            mutable.ResetValues();

            Assert.AreEqual(mutable.Value, false);
        }

        [Test]
        public void ShouldSetAndResetMutableFloat()
        {
            var mutable = ScriptableObject.CreateInstance<MutableFloat>();
            mutable.Value = 10f;

            Assert.AreEqual(mutable.Value, 10f);

            mutable.ResetValues();

            Assert.AreEqual(mutable.Value, 0f);
        }

        [Test]
        public void ShouldSetAndResetMutableString()
        {
            var mutable = ScriptableObject.CreateInstance<MutableString>();
            mutable.Value = "foo";

            Assert.AreEqual(mutable.Value, "foo");

            mutable.ResetValues();

            Assert.AreEqual(mutable.Value, null);
        }

        [Test]
        public void ShouldSetAndResetMutableVector2()
        {
            var mutable = ScriptableObject.CreateInstance<MutableVector2>();
            mutable.Value = UnityEngine.Vector2.one;

            Assert.AreEqual(mutable.Value, UnityEngine.Vector2.one);

            mutable.ResetValues();

            Assert.AreEqual(mutable.Value, UnityEngine.Vector2.zero);
        }

        [Test]
        public void ShouldSetAndResetMutableVector3()
        {
            var mutable = ScriptableObject.CreateInstance<MutableVector3>();
            mutable.Value = UnityEngine.Vector3.one;

            Assert.AreEqual(mutable.Value, UnityEngine.Vector3.one);

            mutable.ResetValues();

            Assert.AreEqual(mutable.Value, UnityEngine.Vector3.zero);
        }
    }
}
