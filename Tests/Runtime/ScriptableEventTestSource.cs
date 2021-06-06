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
                BoolScriptableEventListener
            >(true);

            yield return CreateTestCase<
                FloatScriptableEvent,
                FloatScriptableEventListener
            >(1.0f);

            yield return CreateTestCase<
                GameObjectScriptableEvent,
                GameObjectScriptableEventListener
            >(new UnityEngine.GameObject());

            yield return CreateTestCase<
                IntScriptableEvent,
                IntScriptableEventListener
            >(1);

            yield return CreateTestCase<
                SimpleScriptableEvent,
                SimpleScriptableEventListener
            >(SimpleArg.Instance);

            yield return CreateTestCase<
                StringScriptableEvent,
                StringScriptableEventListener
            >("hello");

            yield return CreateTestCase<
                TransformScriptableEvent,
                TransformScriptableEventListener
            >(new UnityEngine.GameObject().transform);

            yield return CreateTestCase<
                Vector2ScriptableEvent,
                Vector2ScriptableEventListener
            >(UnityEngine.Vector2.one);

            yield return CreateTestCase<
                Vector3ScriptableEvent,
                Vector3ScriptableEventListener
            >(UnityEngine.Vector3.one);
        }

        private static TestFixtureParameters CreateTestCase<
            TScriptableEvent,
            TScriptableEventListener
        >(object arg)
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
