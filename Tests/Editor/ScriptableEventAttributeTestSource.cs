using System.Collections;
using ScriptableEvents.Bool;
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
                BoolScriptableEvent,
                BoolScriptableEventListener
            >(
                "BoolScriptableEvent",
                "Scriptable Events/Bool Scriptable Event",
                "Scriptable Events/Bool Scriptable Event Listener",
                1
            );

            yield return CreateTestCase<
                FloatScriptableEvent,
                FloatScriptableEventListener
            >(
                "FloatScriptableEvent",
                "Scriptable Events/Float Scriptable Event",
                "Scriptable Events/Float Scriptable Event Listener",
                2
            );

            yield return CreateTestCase<
                GameObjectScriptableEvent,
                GameObjectScriptableEventListener
            >(
                "GameObjectScriptableEvent",
                "Scriptable Events/Game Object Scriptable Event",
                "Scriptable Events/Game Object Scriptable Event Listener",
                3
            );

            yield return CreateTestCase<
                IntScriptableEvent,
                IntScriptableEventListener
            >(
                "IntScriptableEvent",
                "Scriptable Events/Int Scriptable Event",
                "Scriptable Events/Int Scriptable Event Listener",
                4
            );

            yield return CreateTestCase<
                SimpleScriptableEvent,
                SimpleScriptableEventListener
            >(
                "SimpleScriptableEvent",
                "Scriptable Events/Simple Scriptable Event",
                "Scriptable Events/Simple Scriptable Event Listener",
                -10
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

            yield return CreateTestCase<
                TransformScriptableEvent,
                TransformScriptableEventListener
            >(
                "TransformScriptableEvent",
                "Scriptable Events/Transform Scriptable Event",
                "Scriptable Events/Transform Scriptable Event Listener",
                6
            );

            yield return CreateTestCase<
                Vector2ScriptableEvent,
                Vector2ScriptableEventListener
            >(
                "Vector2ScriptableEvent",
                "Scriptable Events/Vector2 Scriptable Event",
                "Scriptable Events/Vector2 Scriptable Event Listener",
                7
            );

            yield return CreateTestCase<
                Vector3ScriptableEvent,
                Vector3ScriptableEventListener
            >(
                "Vector3ScriptableEvent",
                "Scriptable Events/Vector3 Scriptable Event",
                "Scriptable Events/Vector3 Scriptable Event Listener",
                8
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
