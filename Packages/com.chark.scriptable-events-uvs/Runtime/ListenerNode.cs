using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CHARK.ScriptableEvents.VisualScripting
{
    internal abstract class ListenerNode<TArg, TComponent> : Unit, IGraphElementWithData, IGraphEventListener
        where TComponent : MonoBehaviour, IListenerComponent<TArg>, IScriptableEventListener<TArg>
    {
        private static int totalCount = 0;
        private sealed class Data : IGraphElementData
        {
            public readonly string id;
            public GraphReference reference;
            public bool isListening;
            public bool isPaused;
            public TComponent component;

            public Data(string id)
            {
                this.id = id;
            }
        }

        [DoNotSerialize] // No need to serialize ports.
        public ControlInput listen { get; private set; }

        [DoNotSerialize] // No need to serialize ports
        public ControlInput pause { get; private set; }

        [DoNotSerialize] // No need to serialize ports
        public ControlInput resume { get; private set; }

        [DoNotSerialize] // No need to serialize ports
        public ControlInput remove { get; private set; }

        [DoNotSerialize] // No need to serialize ports
        public ValueInput target { get; private set; }

        [DoNotSerialize] // No need to serialize ports
        public ValueInput paused { get; private set; }

        [DoNotSerialize] // No need to serialize ports
        public ValueInput events { get; private set; }

        [DoNotSerialize] // No need to serialize ports.
        public ControlOutput then { get; private set; }

        [DoNotSerialize] // No need to serialize ports.
        public ControlOutput onRaised { get; private set; }

        [DoNotSerialize]
        public ValueOutput arg { get; private set; }

        protected override void Definition()
        {
            listen = ControlInput(nameof(listen), Setup);
            pause = ControlInput(nameof(pause), Pause);
            resume = ControlInput(nameof(resume), Resume);
            remove = ControlInput(nameof(remove), Remove);

            target = ValueInput<GameObject>(nameof(target), null);
            paused = ValueInput<bool>(nameof(paused), false);
            events = ValueInput<List<ScriptableEvent<TArg>>>(nameof(events));

            then = ControlOutput(nameof(then));
            onRaised = ControlOutput(nameof(onRaised));
            arg = ValueOutput<TArg>(nameof(arg));

            Succession(listen, then);
        }

        public IGraphElementData CreateData()
        {
            totalCount++;
            return new Data($"ListenerNode#{totalCount}");
        }

        public void StartListening(GraphStack stack)
        {
            Data data = stack.GetElementData<Data>(this);

            if (data.isListening)
            {
                return;
            }

            // Log(data.id, $"StartListening");

            data.isListening = true;
            data.isPaused = true;
            data.reference = stack.ToReference();
            data.component = null;
        }

        public void StopListening(GraphStack stack)
        {
            Data data = stack.GetElementData<Data>(this);

            if (!data.isListening)
            {
                return;
            }

            // Log(data.id, $"StopListening");

            data.isListening = false;
        }

        public bool IsListening(GraphPointer pointer)
        {
            return pointer.GetElementData<Data>(this).isListening;
        }

        private ControlOutput Pause(Flow flow)
        {
            Data data = flow.stack.GetElementData<Data>(this);

            data.isPaused = true;

            return null;
        }

        private ControlOutput Resume(Flow flow)
        {
            Data data = flow.stack.GetElementData<Data>(this);

            data.isPaused = false;

            return null;
        }

        private ControlOutput Remove(Flow flow)
        {
            Data data = flow.stack.GetElementData<Data>(this);

            Object.Destroy(data.component);

            return null;
        }

        private void TriggerOnRaised(GraphReference reference, TArg arg)
        {
            using (Flow flow = Flow.New(reference))
            {
                Update(flow, arg);
            }
        }

        protected void Update(Flow flow, TArg arg)
        {
            Data data = flow.stack.GetElementData<Data>(this);

            // Log(data.id, $"Update");

            flow.SetValue(this.arg, arg);
            flow.Invoke(onRaised);
        }

        private ControlOutput Setup(Flow flow)
        {
            Data data = flow.stack.GetElementData<Data>(this);

            // Log(data.id, $"Setup");

            GameObject go = flow.GetValue<GameObject>(target);
            bool isPaused = flow.GetValue<bool>(paused);
            List<ScriptableEvent<TArg>> list = flow.GetValue<List<ScriptableEvent<TArg>>>(events);

            data.isPaused = isPaused;

            TComponent component = go.AddComponent<TComponent>();

            data.component = component;

            component.RegisterEvents(list);
            component.RegisterOnRaised(arg =>
            {
                // Log(data.id, $"RegisterOnRaisedCallback {{ IsPaused: {data.isPaused} }}");

                if (data.isPaused) return;

                TriggerOnRaised(data.reference, arg);
            });

            return then;
        }

        private static void Log(string id, string message)
        {
            Debug.Log($"ListenerNode > {id} > {message}");
        }
    }
}
