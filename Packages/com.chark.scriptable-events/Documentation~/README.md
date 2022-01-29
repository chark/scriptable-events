[Unity Package Manager]: https://docs.unity3d.com/Manual/upm-ui.html
[Unity Event]: https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html
[Samples~]: ../Samples%7E
[Simple Events]: ../Samples%7E/SimpleEvents
[Events With Arguments]: ../Samples%7E/EventsWithArguments
[Custom Events]: ../Samples%7E/CustomEvents
[ExecuteInEditMode]: https://docs.unity3d.com/ScriptReference/ExecuteInEditMode.html

# Documentation

## Samples
The documented features can be imported as samples via [Unity Package Manager] from the [Samples~] directory. When stuck, check the corresponding sample:
<p align="center">
  <img src="samples.png"/>
</p>

## Getting Started
The simplest use case of _Scriptable Events_ is when a system needs to be notified that something happened without providing any context. To do so, the following elements are needed:
- _Simple Scriptable Event_ asset
- _Simple Scriptable Event Listener_ component

### Without Code
First, create a _Simple Scriptable Event_ asset by right-clicking in the project window and selecting _Create/Scriptable Event/Simple Scriptable Event_. The event asset can be renamed once created placed anywhere in the project:
<p align="center">
  <img src="simple-scriptable-event-create.png"/>
</p>

Next, select a _GameObject_ in the scene and add a _Simple Scriptable Event Listener_ component:
<p align="center">
  <img src="simple-scriptable-event-listener.png"/>
</p>

Once you've added a listener, do the following:
- Insert your event asset into the _Scriptable Event_ field.
- In the _On Raised_ [Unity Event] field add the methods you'd like to be triggered by the event.

For example, if you need to turn off a set of lights your setup might look like the following (as seen in [Simple Events] sample):
<p align="center">
  <img src="simple-scriptable-event-listener-sample.png"/>
</p>

Now that you have your listener ready, you need to trigger the event. This can be done in the following ways:
- Using a [Unity Event] and selecting a `SimpleScriptableEvent.Raise` method
- Selecting the event asset and clicking the _Raise_ button
- Selecting the event asset and clicking the _Raise_ button next to a specific listener

<p align="center">
  <img hspace="2%" width="40%" src="simple-scriptable-event-raise-unity-event.png"/>
  <img hspace="2%" width="40%" src="simple-scriptable-event-raise.png"/>
</p>

### With Code
In most cases you'll need to raise events from your own code. The recommended way to do so is to define a [Unity Event] field and raise the event asset there. This will give the most flexibility:
```cs
using ScriptableEvents.Events;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onTriggered;

    private void Start()
    {
        onTriggered.Invoke();
    }
}
```

Alternatively, you can directly reference the event asset in your code and call the `SimpleScriptableEvent.Raise` method. This will provide give the most traceability but won't be as flexible as the [Unity Event] approach:
```cs
using ScriptableEvents.Events;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField]
    private SimpleScriptableEvent scriptableEvent;

    private void Start()
    {
        scriptableEvent.Raise();
    }
}
```

## Passing Arguments
In most situations your systems will require some context when they're being triggered. To solve this, this package provides a set of events with commonly used types which can be used to carry information to your systems.

### Without Code
To create an event asset which sends information, right-click in the project window and select an event with a specific type from _Create/Scriptable Event/*_:
<p align="center">
  <img src="scriptable-event-arg-create.png"/>
</p>

Next, you'll need to add a listener for this specific event type. Each _Scriptable Event_ type contains a corresponding listener component. Typed event listeners work the same as _Simple Scriptable Event Listener_ components, the only caveat is when selecting methods in the _On Raised_ [Unity Event] field make sure to select a **dynamic** method:
<p align="center">
  <img hspace="2%" width="40%" src="scriptable-event-arg-listener-components.png"/>
  <img hspace="2%" width="40%" src="scriptable-event-arg-listener-dynamic.png"/>
</p>

To trigger the event, follow the same steps as with _Simple Scriptable Event_. Again, make sure to select a **dynamic** `Raise` method:
<p align="center">
  <img src="scriptable-event-arg-raise-dynamic.png"/>
</p>

A more concrete example of this can be seen in [Events With Arguments] sample.

### With Code
When raising events with arguments through code, it is also recommended to use [Unity Event] fields. However, in this case you'll also need to specify the argument type:
```cs
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<float> onTriggered;

    private void Start()
    {
        // Your argument value.
        var value = 1.0f;

        onTriggered.Invoke(value);
    }
}
```

Alternatively, you have can reference the event asset and then call the `SimpleScriptableEvent.Raise(TArg)` method:
```cs
using ScriptableEvents.Events;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField]
    private FloatScriptableEvent scriptableEvent;

    private void Start()
    {
        // Your argument value.
        var value = 1.0f;

        scriptableEvent.Raise(value);
    }
}
```

## Creating Custom Events
In some cases using the built-in argument types is not sufficient. This can happen when you need to send a custom data type to your systems. To integrate your custom data type into the event system you'll need to define the following scripts:
- The custom data type script
- Scriptable Event asset script
- Scriptable Event Listener script
- Scriptable Event (optional)

To simplify script creation workflow, this package provides a custom code generator tool which can be used to automate this process. However, you'll have to define the custom data type manually.

As an example, lets assume that the data type looks like the following:
```cs
public class LightRandomizationEventArgs
{
    public float Intensity { get; set; }

    public Color Color { get; set; }
}
```

Then, right-click the script which defines the data type and select _Create/Scriptable Event/Custom Scriptable Event_ (at the bottom):

<p align="center">
  <img src="scriptable-event-script-creator-open.png"/>
</p>

This will open the _Script Creator_ window:

<p align="center">
  <img hspace="2%" width="40%" src="scriptable-event-script-creator-window-1.png"/>
  <img hspace="2%" width="40%" src="scriptable-event-script-creator-window-2.png"/>
</p>

The _Script Creator_ provides the following options:
- **Event Argument** - allows customizing how the argument data type information is retrieved during script generation:
  - **Is Mono Script** - should a `MonoScript` be used to fetch the type information
  - **Script** - the script to be used as an argument type
  - **Script Name** - name of the argument type
  - **Script Namespace** - namespace of the argument type
- **Event** - allows customizing how the event asset script code wil be generated:
  - **Script Name** - event type and script name
  - **Script Namespace** - event type namespace
  - **Is Create Directories** - should event namespace create directories
  - **Menu Name** - name of the event in context menu
  - **Menu Order** - order of the event in context menu
- **Listener** - allows customizing how the listener component code wil be generated:
  - **Script Name** - listener type and script name
  - **Script Namespace** - listener type namespace
  - **Is Create Directories** - should listener namespace create directories
  - **Menu Name** - name of the listener in component context menu
  - **Menu Order** - order of the listener in component context menu-
- **Editor** - allows customizing how the listener component code wil be generated:
  - **Script Name** - editor type and script name
  - **Script Namespace** - editor type namespace
  - **Is Create Directories** - should editor namespace create directories
- **Output Directory** - where to save generated code
- **Tiny gear icon in top right** - allows saving defaults for the _Script Creator_ window, this is useful when creating scripts in bulk

Making some adjustments to the naming and clicking **Create** in this specific example will result in the following scripts (as seen in [Custom Events] sample).

First, the event script:
```cs
using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "LightRandomizationScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameCustom + "/Light Randomization Scriptable Event",
        order = ScriptableEventConstants.MenuOrderCustom + 0
    )]
    public class LightRandomizationScriptableEvent : BaseScriptableEvent<LightRandomizationEventArgs>
    {
    }
}
```

Event Listener script:
```cs
using UnityEngine;

namespace ScriptableEvents.Events
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameCustom + "/Light Randomization Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderCustom + 0
    )]
    public class LightRandomizationScriptableEventListener : BaseScriptableEventListener<LightRandomizationEventArgs>
    {
    }
}
```

The optional editor script (note that the generated editor script is a placeholder):
```cs
using ScriptableEvents.Editor;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(LightRandomizationScriptableEvent))]
    public class LightRandomizationScriptableEventEditor : BaseScriptableEventEditor<LightRandomizationEventArgs>
    {
        protected override LightRandomizationEventArgs DrawArgField(LightRandomizationEventArgs value)
        {
            // Use EditorGUILayout.TextField, etc., to draw inputs next to Raise button on your
            // LightRandomizationEventArgsScriptableEvent asset.
            return value;
        }
    }
}
```

In order to fully utilize the editor script, you'll have to manually define the input fields, for example (as seen in [Custom Events] sample):
```cs
using ScriptableEvents.Editor;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(LightRandomizationScriptableEvent))]
    public class LightRandomizationScriptableEventEditor : BaseScriptableEventEditor<LightRandomizationEventArgs>
    {
        protected override LightRandomizationEventArgs DrawArgField(LightRandomizationEventArgs value)
        {
            if (value == null)
            {
                value = new LightRandomizationEventArgs();
            }

            EditorGUILayout.BeginVertical();
            value.Intensity = EditorGUILayout.FloatField("Intensity", value.Intensity);
            value.Intensity = Mathf.Max(0, value.Intensity);

            value.Color = EditorGUILayout.ColorField("Color", value.Color);
            EditorGUILayout.EndVertical();

            return value;
        }
    }
}
```

Finally, in order to create the event asset for the newly generated script, select _Create/Scriptable Events (custom)/Custom Event Name_:

<p align="center">
  <img src="scriptable-event-script-creator-result.png"/>
</p>

## Manually Subscribing
In most cases it is recommended to use listener components to subscribe to events as that is the most flexible approach. However, when traceability is important, you can subscribe to events manually via code as well.

There are two approaches that can be used to subscribe to an event, the first one is implementing `IScriptableEventListener<TArg>` and calling `AddListener(this)` (don't forget to call `RemoveListener(this)` at some point to avoid memory leaks):
```cs
public class CustomEventListener : MonoBehaviour, IScriptableEventListener<float>
{
    [SerializeField]
    private FloatScriptableEvent floatScriptableEvent;

    private void OnEnable()
    {
        floatScriptableEvent.AddListener(this);
    }

    private void OnDisable()
    {
        floatScriptableEvent.RemoveListener(this);
    }

    public void OnRaised(float value)
    {
        // Handle event...
    }
}
```

The second approach is more flexible and allows to specify any method that matches the event type via the `AddListener(Action<TArg>)` overload (again don't forget to call the `RemoveListener(Action<TArg>)`):
```cs
public class CustomEventListener : MonoBehaviour
{
    [SerializeField]
    private FloatScriptableEvent floatScriptableEvent;

    private void OnEnable()
    {
        floatScriptableEvent.AddListener(OnRaised);
    }

    private void OnDisable()
    {
        floatScriptableEvent.RemoveListener(OnRaised);
    }

    private void OnRaised(float value)
    {
        // Handle event...
    }
}
```

Note that when using these approaches to subscribe to events you might lose some functionality in the custom inspectors that are provided in this package. For example, losing references in the listener list on event assets.
