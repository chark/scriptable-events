using System.Collections;
using ScriptableEvents.Bool;
using ScriptableEvents.Collider;
using ScriptableEvents.Collision;
using ScriptableEvents.Component;
using ScriptableEvents.Float;
using ScriptableEvents.GameObject;
using ScriptableEvents.Int;
using ScriptableEvents.Simple;
using ScriptableEvents.String;
using ScriptableEvents.Transform;
using ScriptableEvents.Vector2;
using ScriptableEvents.Vector3;

namespace ScriptableEvents.Editor.Tests
{
    public class ScriptableEventAttributeTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return CreateTestCase<
                SimpleScriptableEvent,
                SimpleScriptableEventListener
            >(
                "SimpleScriptableEvent",
                "Scriptable Events/Simple Scriptable Event",
                "Scriptable Events/Listeners/Simple Scriptable Event Listener",
                -10
            );

            yield return CreateTestCase<
                BoolScriptableEvent,
                BoolScriptableEventListener
            >(
                "BoolScriptableEvent",
                "Scriptable Events/Bool Scriptable Event",
                "Scriptable Events/Listeners/Bool Scriptable Event Listener",
                1
            );

            yield return CreateTestCase<
                IntScriptableEvent,
                IntScriptableEventListener
            >(
                "IntScriptableEvent",
                "Scriptable Events/Int Scriptable Event",
                "Scriptable Events/Listeners/Int Scriptable Event Listener",
                2
            );

            yield return CreateTestCase<
                FloatScriptableEvent,
                FloatScriptableEventListener
            >(
                "FloatScriptableEvent",
                "Scriptable Events/Float Scriptable Event",
                "Scriptable Events/Listeners/Float Scriptable Event Listener",
                3
            );

            yield return CreateTestCase<
                StringScriptableEvent,
                StringScriptableEventListener
            >(
                "StringScriptableEvent",
                "Scriptable Events/String Scriptable Event",
                "Scriptable Events/Listeners/String Scriptable Event Listener",
                4
            );

            yield return CreateTestCase<
                Vector2ScriptableEvent,
                Vector2ScriptableEventListener
            >(
                "Vector2ScriptableEvent",
                "Scriptable Events/Vector2 Scriptable Event",
                "Scriptable Events/Listeners/Vector2 Scriptable Event Listener",
                5
            );

            yield return CreateTestCase<
                Vector3ScriptableEvent,
                Vector3ScriptableEventListener
            >(
                "Vector3ScriptableEvent",
                "Scriptable Events/Vector3 Scriptable Event",
                "Scriptable Events/Listeners/Vector3 Scriptable Event Listener",
                6
            );

            yield return CreateTestCase<
                TransformScriptableEvent,
                TransformScriptableEventListener
            >(
                "TransformScriptableEvent",
                "Scriptable Events/Transform Scriptable Event",
                "Scriptable Events/Listeners/Transform Scriptable Event Listener",
                7
            );

            yield return CreateTestCase<
                GameObjectScriptableEvent,
                GameObjectScriptableEventListener
            >(
                "GameObjectScriptableEvent",
                "Scriptable Events/Game Object Scriptable Event",
                "Scriptable Events/Listeners/Game Object Scriptable Event Listener",
                8
            );

            yield return CreateTestCase<
                ComponentScriptableEvent,
                ComponentScriptableEventListener
            >(
                "ComponentScriptableEvent",
                "Scriptable Events/Component Scriptable Event",
                "Scriptable Events/Listeners/Component Scriptable Event Listener",
                9
            );

            yield return CreateTestCase<
                ColliderScriptableEvent,
                ColliderScriptableEventListener
            >(
                "ColliderScriptableEvent",
                "Scriptable Events/Collider Scriptable Event",
                "Scriptable Events/Listeners/Collider Scriptable Event Listener",
                10
            );

            yield return CreateTestCase<
                CollisionScriptableEvent,
                CollisionScriptableEventListener
            >(
                "CollisionScriptableEvent",
                "Scriptable Events/Collision Scriptable Event",
                "Scriptable Events/Listeners/Collision Scriptable Event Listener",
                11
            );
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
