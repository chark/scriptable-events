using System.Collections;
using CHARK.ScriptableEvents.Events;
using CHARK.ScriptableEvents.Listeners;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;

namespace CHARK.ScriptableEvents.Tests.Runtime
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
                ByteScriptableEvent,
                ByteScriptableEventListener,
                byte
            >(1);

            yield return CreateTestCase<
                ShortScriptableEvent,
                ShortScriptableEventListener,
                short
            >(1);

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
                Vector4ScriptableEvent,
                Vector4ScriptableEventListener,
                Vector4
            >(Vector4.one);

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

#if UNITY_PHYSICS_2D
            yield return CreateTestCase<
                Collision2DScriptableEvent,
                Collision2DScriptableEventListener,
                Collision2D
            >(new Collision2D());

            yield return CreateTestCase<
                Collider2DScriptableEvent,
                Collider2DScriptableEventListener,
                Collider2D
            >(new Collider2D());
#endif

#if UNITY_PHYSICS_3D
            yield return CreateTestCase<
                CollisionScriptableEvent,
                CollisionScriptableEventListener,
                Collision
            >(new Collision());

            yield return CreateTestCase<
                ColliderScriptableEvent,
                ColliderScriptableEventListener,
                Collider
            >(new Collider());
#endif

            yield return CreateTestCase<
                ObjectScriptableEvent,
                ObjectScriptableEventListener,
                Object
            >(new Object());

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
                    arg.GetType(),
                }
            };

            return new TestFixtureParameters(attribute);
        }
    }
}
