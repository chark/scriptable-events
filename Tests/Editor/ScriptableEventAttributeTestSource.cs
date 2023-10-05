using System.Collections;
using CHARK.ScriptableEvents.Events;
using CHARK.ScriptableEvents.Listeners;

namespace CHARK.ScriptableEvents.Tests.Editor
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
                "/Simple Scriptable Event",
                "/Simple Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderSimpleEvent
            );

            #region Primitives

            yield return CreateTestCase<
                BoolScriptableEvent,
                BoolScriptableEventListener
            >(
                "BoolScriptableEvent",
                "/Bool Scriptable Event",
                "/Bool Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderPrimitiveEvent + 0
            );

            yield return CreateTestCase<
                IntScriptableEvent,
                IntScriptableEventListener
            >(
                "IntScriptableEvent",
                "/Int Scriptable Event",
                "/Int Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderPrimitiveEvent + 1
            );

            yield return CreateTestCase<
                LongScriptableEvent,
                LongScriptableEventListener
            >(
                "LongScriptableEvent",
                "/Long Scriptable Event",
                "/Long Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderPrimitiveEvent + 2
            );

            yield return CreateTestCase<
                FloatScriptableEvent,
                FloatScriptableEventListener
            >(
                "FloatScriptableEvent",
                "/Float Scriptable Event",
                "/Float Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderPrimitiveEvent + 3
            );

            yield return CreateTestCase<
                DoubleScriptableEvent,
                DoubleScriptableEventListener
            >(
                "DoubleScriptableEvent",
                "/Double Scriptable Event",
                "/Double Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderPrimitiveEvent + 4
            );

            yield return CreateTestCase<
                StringScriptableEvent,
                StringScriptableEventListener
            >(
                "StringScriptableEvent",
                "/String Scriptable Event",
                "/String Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderPrimitiveEvent + 5
            );

            #endregion

            #region Structs

            yield return CreateTestCase<
                Vector2ScriptableEvent,
                Vector2ScriptableEventListener
            >(
                "Vector2ScriptableEvent",
                "/Vector2 Scriptable Event",
                "/Vector2 Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 0
            );

            yield return CreateTestCase<
                Vector3ScriptableEvent,
                Vector3ScriptableEventListener
            >(
                "Vector3ScriptableEvent",
                "/Vector3 Scriptable Event",
                "/Vector3 Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 1
            );


            yield return CreateTestCase<
                Collision2DScriptableEvent,
                Collision2DScriptableEventListener
            >(
                "Collision2DScriptableEvent",
                "/Collision 2D Scriptable Event",
                "/Collision 2D Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 2
            );

            yield return CreateTestCase<
                CollisionScriptableEvent,
                CollisionScriptableEventListener
            >(
                "CollisionScriptableEvent",
                "/Collision Scriptable Event",
                "/Collision Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 3
            );

            yield return CreateTestCase<
                QuaternionScriptableEvent,
                QuaternionScriptableEventListener
            >(
                "QuaternionScriptableEvent",
                "/Quaternion Scriptable Event",
                "/Quaternion Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 4
            );

            yield return CreateTestCase<
                ColorScriptableEvent,
                ColorScriptableEventListener
            >(
                "ColorScriptableEvent",
                "/Color Scriptable Event",
                "/Color Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 5
            );

            #endregion

            #region Objects

            yield return CreateTestCase<
                Collider2DScriptableEvent,
                Collider2DScriptableEventListener
            >(
                "Collider2DScriptableEvent",
                "/Collider 2D Scriptable Event",
                "/Collider 2D Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderUnityObjectEvent + 0
            );

            yield return CreateTestCase<
                ColliderScriptableEvent,
                ColliderScriptableEventListener
            >(
                "ColliderScriptableEvent",
                "/Collider Scriptable Event",
                "/Collider Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderUnityObjectEvent + 1
            );

            yield return CreateTestCase<
                GameObjectScriptableEvent,
                GameObjectScriptableEventListener
            >(
                "GameObjectScriptableEvent",
                "/Game Object Scriptable Event",
                "/Game Object Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderUnityObjectEvent + 2
            );

            yield return CreateTestCase<
                TransformScriptableEvent,
                TransformScriptableEventListener
            >(
                "TransformScriptableEvent",
                "/Transform Scriptable Event",
                "/Transform Scriptable Event Listener",
                ScriptableEventConstants.MenuOrderUnityObjectEvent + 3
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
                ScriptableEventConstants.MenuNameBase + eventMenuName,
                ScriptableEventConstants.MenuNameBase + listenerMenuName,
                order
            };
        }
    }
}
