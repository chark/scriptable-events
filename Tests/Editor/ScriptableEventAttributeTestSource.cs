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
                "Scriptable Event/Simple Scriptable Event",
                "Scriptable Event/Simple Scriptable Event Listener",
                -100
            );

            #region Primitives

            yield return CreateTestCase<
                BoolScriptableEvent,
                BoolScriptableEventListener
            >(
                "BoolScriptableEvent",
                "Scriptable Event/Bool Scriptable Event",
                "Scriptable Event/Bool Scriptable Event Listener",
                0
            );

            yield return CreateTestCase<
                IntScriptableEvent,
                IntScriptableEventListener
            >(
                "IntScriptableEvent",
                "Scriptable Event/Int Scriptable Event",
                "Scriptable Event/Int Scriptable Event Listener",
                1
            );

            yield return CreateTestCase<
                LongScriptableEvent,
                LongScriptableEventListener
            >(
                "LongScriptableEvent",
                "Scriptable Event/Long Scriptable Event",
                "Scriptable Event/Long Scriptable Event Listener",
                2
            );

            yield return CreateTestCase<
                FloatScriptableEvent,
                FloatScriptableEventListener
            >(
                "FloatScriptableEvent",
                "Scriptable Event/Float Scriptable Event",
                "Scriptable Event/Float Scriptable Event Listener",
                3
            );

            yield return CreateTestCase<
                DoubleScriptableEvent,
                DoubleScriptableEventListener
            >(
                "DoubleScriptableEvent",
                "Scriptable Event/Double Scriptable Event",
                "Scriptable Event/Double Scriptable Event Listener",
                4
            );

            yield return CreateTestCase<
                StringScriptableEvent,
                StringScriptableEventListener
            >(
                "StringScriptableEvent",
                "Scriptable Event/String Scriptable Event",
                "Scriptable Event/String Scriptable Event Listener",
                5
            );

            #endregion

            #region Structs

            yield return CreateTestCase<
                Vector2ScriptableEvent,
                Vector2ScriptableEventListener
            >(
                "Vector2ScriptableEvent",
                "Scriptable Event/Vector2 Scriptable Event",
                "Scriptable Event/Vector2 Scriptable Event Listener",
                100
            );

            yield return CreateTestCase<
                Vector3ScriptableEvent,
                Vector3ScriptableEventListener
            >(
                "Vector3ScriptableEvent",
                "Scriptable Event/Vector3 Scriptable Event",
                "Scriptable Event/Vector3 Scriptable Event Listener",
                101
            );


            yield return CreateTestCase<
                Collision2DScriptableEvent,
                Collision2DScriptableEventListener
            >(
                "Collision2DScriptableEvent",
                "Scriptable Event/Collision 2D Scriptable Event",
                "Scriptable Event/Collision 2D Scriptable Event Listener",
                102
            );

            yield return CreateTestCase<
                CollisionScriptableEvent,
                CollisionScriptableEventListener
            >(
                "CollisionScriptableEvent",
                "Scriptable Event/Collision Scriptable Event",
                "Scriptable Event/Collision Scriptable Event Listener",
                103
            );

            yield return CreateTestCase<
                QuaternionScriptableEvent,
                QuaternionScriptableEventListener
            >(
                "QuaternionScriptableEvent",
                "Scriptable Event/Quaternion Scriptable Event",
                "Scriptable Event/Quaternion Scriptable Event Listener",
                104
            );

            yield return CreateTestCase<
                ColorScriptableEvent,
                ColorScriptableEventListener
            >(
                "ColorScriptableEvent",
                "Scriptable Event/Color Scriptable Event",
                "Scriptable Event/Color Scriptable Event Listener",
                105
            );

            #endregion

            #region Objects

            yield return CreateTestCase<
                Collider2DScriptableEvent,
                Collider2DScriptableEventListener
            >(
                "Collider2DScriptableEvent",
                "Scriptable Event/Collider 2D Scriptable Event",
                "Scriptable Event/Collider 2D Scriptable Event Listener",
                200
            );

            yield return CreateTestCase<
                ColliderScriptableEvent,
                ColliderScriptableEventListener
            >(
                "ColliderScriptableEvent",
                "Scriptable Event/Collider Scriptable Event",
                "Scriptable Event/Collider Scriptable Event Listener",
                201
            );

            yield return CreateTestCase<
                GameObjectScriptableEvent,
                GameObjectScriptableEventListener
            >(
                "GameObjectScriptableEvent",
                "Scriptable Event/Game Object Scriptable Event",
                "Scriptable Event/Game Object Scriptable Event Listener",
                202
            );

            yield return CreateTestCase<
                TransformScriptableEvent,
                TransformScriptableEventListener
            >(
                "TransformScriptableEvent",
                "Scriptable Event/Transform Scriptable Event",
                "Scriptable Event/Transform Scriptable Event Listener",
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
