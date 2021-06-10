using System.Collections;
using ScriptableEvents.Events;
using ScriptableEvents.Listeners;

namespace ScriptableEvents.Editor.Tests
{
    internal class ScriptableEventAttributeTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return CreateTestCase<
                SimpleScriptableEvent,
                SimpleScriptableEventListener
            >(
                "SimpleScriptableEvent",
                "Scriptable Events/Simple Scriptable Event",
                "Scriptable Events/Simple Scriptable Event Listener",
                -100
            );

            #region Primitives

            yield return CreateTestCase<
                BoolScriptableEvent,
                BoolScriptableEventListener
            >(
                "BoolScriptableEvent",
                "Scriptable Events/Bool Scriptable Event",
                "Scriptable Events/Bool Scriptable Event Listener",
                0
            );

            yield return CreateTestCase<
                IntScriptableEvent,
                IntScriptableEventListener
            >(
                "IntScriptableEvent",
                "Scriptable Events/Int Scriptable Event",
                "Scriptable Events/Int Scriptable Event Listener",
                1
            );

            yield return CreateTestCase<
                LongScriptableEvent,
                LongScriptableEventListener
            >(
                "LongScriptableEvent",
                "Scriptable Events/Long Scriptable Event",
                "Scriptable Events/Long Scriptable Event Listener",
                2
            );

            yield return CreateTestCase<
                FloatScriptableEvent,
                FloatScriptableEventListener
            >(
                "FloatScriptableEvent",
                "Scriptable Events/Float Scriptable Event",
                "Scriptable Events/Float Scriptable Event Listener",
                3
            );

            yield return CreateTestCase<
                DoubleScriptableEvent,
                DoubleScriptableEventListener
            >(
                "DoubleScriptableEvent",
                "Scriptable Events/Double Scriptable Event",
                "Scriptable Events/Double Scriptable Event Listener",
                4
            );

            yield return CreateTestCase<
                StringScriptableEvent,
                StringScriptableEventListener
            >(
                "StringScriptableEvent",
                "Scriptable Events/String Scriptable Event",
                "Scriptable Events/String Scriptable Event Listener",
                5
            );

            #endregion

            #region Structs

            yield return CreateTestCase<
                Vector2ScriptableEvent,
                Vector2ScriptableEventListener
            >(
                "Vector2ScriptableEvent",
                "Scriptable Events/Vector2 Scriptable Event",
                "Scriptable Events/Vector2 Scriptable Event Listener",
                100
            );

            yield return CreateTestCase<
                Vector3ScriptableEvent,
                Vector3ScriptableEventListener
            >(
                "Vector3ScriptableEvent",
                "Scriptable Events/Vector3 Scriptable Event",
                "Scriptable Events/Vector3 Scriptable Event Listener",
                101
            );


            yield return CreateTestCase<
                Collision2DScriptableEvent,
                Collision2DScriptableEventListener
            >(
                "Collision2DScriptableEvent",
                "Scriptable Events/Collision 2D Scriptable Event",
                "Scriptable Events/Collision 2D Scriptable Event Listener",
                102
            );

            yield return CreateTestCase<
                CollisionScriptableEvent,
                CollisionScriptableEventListener
            >(
                "CollisionScriptableEvent",
                "Scriptable Events/Collision Scriptable Event",
                "Scriptable Events/Collision Scriptable Event Listener",
                103
            );

            yield return CreateTestCase<
                QuaternionScriptableEvent,
                QuaternionScriptableEventListener
            >(
                "QuaternionScriptableEvent",
                "Scriptable Events/Quaternion Scriptable Event",
                "Scriptable Events/Quaternion Scriptable Event Listener",
                104
            );

            yield return CreateTestCase<
                ColorScriptableEvent,
                ColorScriptableEventListener
            >(
                "ColorScriptableEvent",
                "Scriptable Events/Color Scriptable Event",
                "Scriptable Events/Color Scriptable Event Listener",
                105
            );

            #endregion

            #region Objects

            yield return CreateTestCase<
                Collider2DScriptableEvent,
                Collider2DScriptableEventListener
            >(
                "Collider2DScriptableEvent",
                "Scriptable Events/Collider 2D Scriptable Event",
                "Scriptable Events/Collider 2D Scriptable Event Listener",
                200
            );

            yield return CreateTestCase<
                ColliderScriptableEvent,
                ColliderScriptableEventListener
            >(
                "ColliderScriptableEvent",
                "Scriptable Events/Collider Scriptable Event",
                "Scriptable Events/Collider Scriptable Event Listener",
                201
            );

            yield return CreateTestCase<
                GameObjectScriptableEvent,
                GameObjectScriptableEventListener
            >(
                "GameObjectScriptableEvent",
                "Scriptable Events/Game Object Scriptable Event",
                "Scriptable Events/Game Object Scriptable Event Listener",
                202
            );

            yield return CreateTestCase<
                TransformScriptableEvent,
                TransformScriptableEventListener
            >(
                "TransformScriptableEvent",
                "Scriptable Events/Transform Scriptable Event",
                "Scriptable Events/Transform Scriptable Event Listener",
                203
            );

            #endregion
        }

        private static object[] CreateTestCase<
            TScriptableEvent,
            TScriptableEventListener
        >(
            string eventFileName,
            string eventMenuName,
            string listenerMenuName,
            int order
        )
        {
            return new object[]
            {
                typeof(TScriptableEvent),
                typeof(TScriptableEventListener),
                eventFileName,
                eventMenuName,
                listenerMenuName,
                order
            };
        }
    }
}
