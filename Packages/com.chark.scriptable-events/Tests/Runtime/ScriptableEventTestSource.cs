using System.Collections;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ScriptableEvents.Bool;
using ScriptableEvents.Float;
using ScriptableEvents.GameObject;
using ScriptableEvents.Int;
using ScriptableEvents.Simple;
using ScriptableEvents.String;
using ScriptableEvents.Transform;
using ScriptableEvents.Vector2;
using ScriptableEvents.Vector3;

namespace ScriptableEvents.Tests
{
    public class ScriptableEventTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return CreateTestCase<
                BoolScriptableEvent,
                BoolScriptableEventListener,
                BoolUnityEvent
            >(true);

            yield return CreateTestCase<
                FloatScriptableEvent,
                FloatScriptableEventListener,
                FloatUnityEvent
            >(1.0f);

            yield return CreateTestCase<
                GameObjectScriptableEvent,
                GameObjectScriptableEventListener,
                GameObjectUnityEvent
            >(new UnityEngine.GameObject());

            yield return CreateTestCase<
                IntScriptableEvent,
                IntScriptableEventListener,
                IntUnityEvent
            >(1);

            yield return CreateTestCase<
                SimpleScriptableEvent,
                SimpleScriptableEventListener,
                SimpleUnityEvent
            >(SimpleArg.Instance);

            yield return CreateTestCase<
                StringScriptableEvent,
                StringScriptableEventListener,
                StringUnityEvent
            >("hello");

            yield return CreateTestCase<
                TransformScriptableEvent,
                TransformScriptableEventListener,
                TransformUnityEvent
            >(new UnityEngine.GameObject().transform);

            yield return CreateTestCase<
                Vector2ScriptableEvent,
                Vector2ScriptableEventListener,
                Vector2UnityEvent
            >(UnityEngine.Vector2.one);

            yield return CreateTestCase<
                Vector3ScriptableEvent,
                Vector3ScriptableEventListener,
                Vector3UnityEvent
            >(UnityEngine.Vector3.one);
        }

        private static TestFixtureParameters CreateTestCase<
            TScriptableEvent,
            TScriptableEventListener,
            TUnityEvent
        >(object arg)
        {
            var attribute = new TestFixtureAttribute(arg)
            {
                TypeArgs = new[]
                {
                    typeof(TScriptableEvent),
                    typeof(TScriptableEventListener),
                    typeof(TUnityEvent),
                    arg.GetType()
                }
            };

            return new TestFixtureParameters(attribute);
        }
    }
}
