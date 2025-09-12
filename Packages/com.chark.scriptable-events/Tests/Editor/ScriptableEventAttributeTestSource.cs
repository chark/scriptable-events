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
                order: ScriptableEventConstants.MenuOrderPrimitiveEvent
            );

            yield return CreateTestCase<
                ByteScriptableEvent,
                ByteScriptableEventListener
            >(
                eventFileName: "ByteScriptableEvent",
                eventMenuName: "/Byte Scriptable Event",
                listenerMenuName: "/Byte Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderPrimitiveEvent
            );

            yield return CreateTestCase<
                ShortScriptableEvent,
                ShortScriptableEventListener
            >(
                eventFileName: "ShortScriptableEvent",
                eventMenuName: "/Short Scriptable Event",
                listenerMenuName: "/Short Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderPrimitiveEvent
            );

            yield return CreateTestCase<
                IntScriptableEvent,
                IntScriptableEventListener
            >(
                eventFileName: "IntScriptableEvent",
                eventMenuName: "/Int Scriptable Event",
                listenerMenuName: "/Int Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderPrimitiveEvent
            );

            yield return CreateTestCase<
                LongScriptableEvent,
                LongScriptableEventListener
            >(
                eventFileName: "LongScriptableEvent",
                eventMenuName: "/Long Scriptable Event",
                listenerMenuName: "/Long Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderPrimitiveEvent
            );

            yield return CreateTestCase<
                FloatScriptableEvent,
                FloatScriptableEventListener
            >(
                eventFileName: "FloatScriptableEvent",
                eventMenuName: "/Float Scriptable Event",
                listenerMenuName: "/Float Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderPrimitiveEvent
            );

            yield return CreateTestCase<
                DoubleScriptableEvent,
                DoubleScriptableEventListener
            >(
                eventFileName: "DoubleScriptableEvent",
                eventMenuName: "/Double Scriptable Event",
                listenerMenuName: "/Double Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderPrimitiveEvent
            );

            yield return CreateTestCase<
                StringScriptableEvent,
                StringScriptableEventListener
            >(
                eventFileName: "StringScriptableEvent",
                eventMenuName: "/String Scriptable Event",
                listenerMenuName: "/String Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderPrimitiveEvent
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
                order: ScriptableEventConstants.MenuOrderUnityPrimitiveEvent
            );

            yield return CreateTestCase<
                Vector3ScriptableEvent,
                Vector3ScriptableEventListener
            >(
                eventFileName: "Vector3ScriptableEvent",
                eventMenuName: "/Vector3 Scriptable Event",
                listenerMenuName: "/Vector3 Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityPrimitiveEvent
            );

            yield return CreateTestCase<
                Vector4ScriptableEvent,
                Vector4ScriptableEventListener
            >(
                eventFileName: "Vector4ScriptableEvent",
                eventMenuName: "/Vector4 Scriptable Event",
                listenerMenuName: "/Vector4 Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityPrimitiveEvent
            );

            yield return CreateTestCase<
                QuaternionScriptableEvent,
                QuaternionScriptableEventListener
            >(
                eventFileName: "QuaternionScriptableEvent",
                eventMenuName: "/Quaternion Scriptable Event",
                listenerMenuName: "/Quaternion Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityPrimitiveEvent
            );

            yield return CreateTestCase<
                ColorScriptableEvent,
                ColorScriptableEventListener
            >(
                eventFileName: "ColorScriptableEvent",
                eventMenuName: "/Color Scriptable Event",
                listenerMenuName: "/Color Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityPrimitiveEvent
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
                order: ScriptableEventConstants.MenuOrderUnityObjectEvent
            );

            yield return CreateTestCase<
                Collider2DScriptableEvent,
                Collider2DScriptableEventListener
            >(
                eventFileName: "Collider2DScriptableEvent",
                eventMenuName: "/Collider 2D Scriptable Event",
                listenerMenuName: "/Collider 2D Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityObjectEvent
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
                order: ScriptableEventConstants.MenuOrderUnityObjectEvent
            );

            yield return CreateTestCase<
                ColliderScriptableEvent,
                ColliderScriptableEventListener
            >(
                eventFileName: "ColliderScriptableEvent",
                eventMenuName: "/Collider Scriptable Event",
                listenerMenuName: "/Collider Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityObjectEvent
            );
#endif

            yield return CreateTestCase<
                ObjectScriptableEvent,
                ObjectScriptableEventListener
            >(
                eventFileName: "ObjectScriptableEvent",
                eventMenuName: "/Object Scriptable Event",
                listenerMenuName: "/Object Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityObjectEvent
            );

            yield return CreateTestCase<
                GameObjectScriptableEvent,
                GameObjectScriptableEventListener
            >(
                eventFileName: "GameObjectScriptableEvent",
                eventMenuName: "/Game Object Scriptable Event",
                listenerMenuName: "/Game Object Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityObjectEvent
            );

            yield return CreateTestCase<
                TransformScriptableEvent,
                TransformScriptableEventListener
            >(
                eventFileName: "TransformScriptableEvent",
                eventMenuName: "/Transform Scriptable Event",
                listenerMenuName: "/Transform Scriptable Event Listener",
                order: ScriptableEventConstants.MenuOrderUnityObjectEvent
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
