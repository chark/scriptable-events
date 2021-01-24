using System;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

namespace ScriptableEvents.Editor.Tests
{
    [TestFixtureSource(typeof(ScriptableEventAttributeTestSource))]
    public class ScriptableEventAttributeTest
    {
        private readonly Type eventType;
        private readonly Type listenerType;

        private readonly string eventFileName;
        private readonly string eventMenuName;
        private readonly string listenerMenuName;

        private readonly int order;

        public ScriptableEventAttributeTest(
            Type eventType,
            Type listenerType,
            string eventFileName,
            string eventMenuName,
            string listenerMenuName,
            int order
        )
        {
            this.eventType = eventType;
            this.listenerType = listenerType;
            this.eventFileName = eventFileName;
            this.eventMenuName = eventMenuName;
            this.listenerMenuName = listenerMenuName;
            this.order = order;
        }

        [Test]
        public void ShouldMatchEventAttributeValues()
        {
            var eventMenuAttribute = GetAttribute<CreateAssetMenuAttribute>(eventType);
            Assert.AreEqual(eventFileName, eventMenuAttribute.fileName);
            Assert.AreEqual(eventMenuName, eventMenuAttribute.menuName);
            Assert.AreEqual(order, eventMenuAttribute.order);
        }

        [Test]
        public void ShouldMatchListenerAttributeValues()
        {
            var listenerMenuAttribute = GetAttribute<AddComponentMenu>(listenerType);
            Assert.AreEqual(listenerMenuName, listenerMenuAttribute.componentMenu);
            Assert.AreEqual(order, listenerMenuAttribute.componentOrder);
        }

        private static TAttribute GetAttribute<TAttribute>(MemberInfo type)
            where TAttribute : Attribute
        {
            return (TAttribute) type.GetCustomAttribute(typeof(TAttribute));
        }
    }
}
