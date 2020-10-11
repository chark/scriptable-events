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

            Assert.AreEqual(true, mutable.Value);

            mutable.ResetValues();

            Assert.AreEqual(false, mutable.Value);
        }

        [Test]
        public void ShouldSetAndResetMutableFloat()
        {
            var mutable = ScriptableObject.CreateInstance<MutableFloat>();
            mutable.Value = 10f;

            Assert.AreEqual(10f, mutable.Value);

            mutable.ResetValues();

            Assert.AreEqual(0f, mutable.Value);
        }

        [Test]
        public void ShouldSetAndResetMutableString()
        {
            var mutable = ScriptableObject.CreateInstance<MutableString>();
            mutable.Value = "foo";

            Assert.AreEqual("foo", mutable.Value);

            mutable.ResetValues();

            Assert.AreEqual(null, mutable.Value);
        }

        [Test]
        public void ShouldSetAndResetMutableVector2()
        {
            var mutable = ScriptableObject.CreateInstance<MutableVector2>();
            mutable.Value = UnityEngine.Vector2.one;

            Assert.AreEqual(UnityEngine.Vector2.one, mutable.Value);

            mutable.ResetValues();

            Assert.AreEqual(UnityEngine.Vector2.zero, mutable.Value);
        }

        [Test]
        public void ShouldSetAndResetMutableVector3()
        {
            var mutable = ScriptableObject.CreateInstance<MutableVector3>();
            mutable.Value = UnityEngine.Vector3.one;

            Assert.AreEqual(UnityEngine.Vector3.one, mutable.Value);

            mutable.ResetValues();

            Assert.AreEqual(UnityEngine.Vector3.zero, mutable.Value);
        }
    }
}
