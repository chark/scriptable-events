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
                eventFileName: "SimpleScriptableEvent",
                eventMenuName: "/Simple Scriptable Event",
                listenerMenuName: "/Simple Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderSimpleEvent
            );

            #region Primitives

            yield return CreateTestCase<
                BoolScriptableEvent,
                BoolScriptableEventListener
            >(
                eventFileName: "BoolScriptableEvent",
                eventMenuName: "/Bool Scriptable Event",
                listenerMenuName: "/Bool Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderPrimitiveEvent + 0
            );

            yield return CreateTestCase<
                IntScriptableEvent,
                IntScriptableEventListener
            >(
                eventFileName: "IntScriptableEvent",
                eventMenuName: "/Int Scriptable Event",
                listenerMenuName: "/Int Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderPrimitiveEvent + 1
            );

            yield return CreateTestCase<
                LongScriptableEvent,
                LongScriptableEventListener
            >(
                eventFileName: "LongScriptableEvent",
                eventMenuName: "/Long Scriptable Event",
                listenerMenuName: "/Long Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderPrimitiveEvent + 2
            );

            yield return CreateTestCase<
                FloatScriptableEvent,
                FloatScriptableEventListener
            >(
                eventFileName: "FloatScriptableEvent",
                eventMenuName: "/Float Scriptable Event",
                listenerMenuName: "/Float Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderPrimitiveEvent + 3
            );

            yield return CreateTestCase<
                DoubleScriptableEvent,
                DoubleScriptableEventListener
            >(
                eventFileName: "DoubleScriptableEvent",
                eventMenuName: "/Double Scriptable Event",
                listenerMenuName: "/Double Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderPrimitiveEvent + 4
            );

            yield return CreateTestCase<
                StringScriptableEvent,
                StringScriptableEventListener
            >(
                eventFileName: "StringScriptableEvent",
                eventMenuName: "/String Scriptable Event",
                listenerMenuName: "/String Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderPrimitiveEvent + 5
            );

            #endregion

            #region Structs

            yield return CreateTestCase<
                Vector2ScriptableEvent,
                Vector2ScriptableEventListener
            >(
                eventFileName: "Vector2ScriptableEvent",
                eventMenuName: "/Vector2 Scriptable Event",
                listenerMenuName: "/Vector2 Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 0
            );

            yield return CreateTestCase<
                Vector3ScriptableEvent,
                Vector3ScriptableEventListener
            >(
                eventFileName: "Vector3ScriptableEvent",
                eventMenuName: "/Vector3 Scriptable Event",
                listenerMenuName: "/Vector3 Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 1
            );

            yield return CreateTestCase<
                QuaternionScriptableEvent,
                QuaternionScriptableEventListener
            >(
                eventFileName: "QuaternionScriptableEvent",
                eventMenuName: "/Quaternion Scriptable Event",
                listenerMenuName: "/Quaternion Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 4
            );

            yield return CreateTestCase<
                ColorScriptableEvent,
                ColorScriptableEventListener
            >(
                eventFileName: "ColorScriptableEvent",
                eventMenuName: "/Color Scriptable Event",
                listenerMenuName: "/Color Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 5
            );

            #endregion

            #region Objects

#if UNITY_PHYSICS_2D
            yield return CreateTestCase<
                Collision2DScriptableEvent,
                Collision2DScriptableEventListener
            >(
                eventFileName: "Collision2DScriptableEvent",
                eventMenuName: "/Collision 2D Scriptable Event",
                listenerMenuName: "/Collision 2D Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 2
            );

            yield return CreateTestCase<
                Collider2DScriptableEvent,
                Collider2DScriptableEventListener
            >(
                eventFileName: "Collider2DScriptableEvent",
                eventMenuName: "/Collider 2D Scriptable Event",
                listenerMenuName: "/Collider 2D Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityObjectEvent + 0
            );
#endif

#if UNITY_PHYSICS_3D
            yield return CreateTestCase<
                CollisionScriptableEvent,
                CollisionScriptableEventListener
            >(
                eventFileName: "CollisionScriptableEvent",
                eventMenuName: "/Collision Scriptable Event",
                listenerMenuName: "/Collision Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityPrimitiveEvent + 3
            );

            yield return CreateTestCase<
                ColliderScriptableEvent,
                ColliderScriptableEventListener
            >(
                eventFileName: "ColliderScriptableEvent",
                eventMenuName: "/Collider Scriptable Event",
                listenerMenuName: "/Collider Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityObjectEvent + 1
            );
#endif

            yield return CreateTestCase<
                GameObjectScriptableEvent,
                GameObjectScriptableEventListener
            >(
                eventFileName: "GameObjectScriptableEvent",
                eventMenuName: "/Game Object Scriptable Event",
                listenerMenuName: "/Game Object Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityObjectEvent + 2
            );

            yield return CreateTestCase<
                TransformScriptableEvent,
                TransformScriptableEventListener
            >(
                eventFileName: "TransformScriptableEvent",
                eventMenuName: "/Transform Scriptable Event",
                listenerMenuName: "/Transform Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityObjectEvent + 3
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
                order,
            };
        }
    }
}
