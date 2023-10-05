using System.Collections;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ScriptableEvents.Events;
using ScriptableEvents.Listeners;
using UnityEngine;

namespace ScriptableEvents.Tests.Runtime
{
    internal class ScriptableEventTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            #region Primitives

            yield return CreateTestCase<
                SimpleScriptableEvent,
                SimpleScriptableEventListener,
                SimpleArg
            >(SimpleArg.Instance);

            yield return CreateTestCase<
                BoolScriptableEvent,
                BoolScriptableEventListener,
                bool
            >(true);

            yield return CreateTestCase<
                IntScriptableEvent,
                IntScriptableEventListener,
                int
            >(1);

            yield return CreateTestCase<
                LongScriptableEvent,
                LongScriptableEventListener,
                long
            >(1L);

            yield return CreateTestCase<
                FloatScriptableEvent,
                FloatScriptableEventListener,
                float
            >(1.0f);

            yield return CreateTestCase<
                DoubleScriptableEvent,
                DoubleScriptableEventListener,
                double
            >(1.0d);

            yield return CreateTestCase<
                StringScriptableEvent,
                StringScriptableEventListener,
                string
            >("hello");

            #endregion

            #region Structs

            yield return CreateTestCase<
                Vector2ScriptableEvent,
                Vector2ScriptableEventListener,
                Vector2
            >(Vector2.one);

            yield return CreateTestCase<
                Vector3ScriptableEvent,
                Vector3ScriptableEventListener,
                Vector3
            >(Vector3.one);

            yield return CreateTestCase<
                CollisionScriptableEvent,
                CollisionScriptableEventListener,
                Collision
            >(new Collision());

            yield return CreateTestCase<
                QuaternionScriptableEvent,
                QuaternionScriptableEventListener,
                Quaternion
            >(Quaternion.Euler(1f, 1f, 1f));

            yield return CreateTestCase<
                ColorScriptableEvent,
                ColorScriptableEventListener,
                Color
            >(Color.red);

            #endregion

            #region Objects

            yield return CreateTestCase<
                Collider2DScriptableEvent,
                Collider2DScriptableEventListener,
                Collider2D
            >(new Collider2D());

            yield return CreateTestCase<
                ColliderScriptableEvent,
                ColliderScriptableEventListener,
                Collider
            >(new Collider());

            yield return CreateTestCase<
                GameObjectScriptableEvent,
                GameObjectScriptableEventListener,
                GameObject
            >(new GameObject());

            yield return CreateTestCase<
                TransformScriptableEvent,
                TransformScriptableEventListener,
                Transform
            >(new GameObject().transform);

            #endregion
        }

        private static TestFixtureParameters CreateTestCase<
            TScriptableEvent,
            TScriptableEventListener,
            TArg
        >(TArg arg)
            where TScriptableEvent : ScriptableEvent<TArg>
            where TScriptableEventListener : ScriptableEventListener<TArg>
        {
            var attribute = new TestFixtureAttribute(arg)
            {
                TypeArgs = new[]
                {
                    typeof(TScriptableEvent),
                    typeof(TScriptableEventListener),
                    arg.GetType()
                }
            };

            return new TestFixtureParameters(attribute);
        }
    }
}
