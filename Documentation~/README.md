[Unity Package Manager]: https://docs.unity3d.com/Manual/upm-ui.html
[Unity Event]: https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html
[Samples~]: ../Samples%7E
[Simple Events]: ../Samples%7E/SimpleEvents
[Events With Arguments]: ../Samples%7E/EventsWithArguments
[Custom Events]: ../Samples%7E/CustomEvents

# Documentation

## Samples
The documented features can be imported as samples via [Unity Package Manager] from the [Samples~] directory. If you get stuck, check the corresponding sample:
<p align="center">
  <img src="samples.png"/>
</p>

## Getting Started (Simple Events)
The simplest use case of _Scriptable Events_ is when you need to notify a system that something happened without providing any context. To do so, you need two elements: a _Simple Scriptable Event_ and a _Simple Scriptable Event Listener_.

First, create a _Simple Scriptable Event_ asset by right-clicking in the project window and selecting _Create/Scriptable Events/Simple Scriptable Event_. You can name the event as you prefer and place it anywhere in your project:
<p align="center">
  <img src="simple-scriptable-event.png"/>
</p>

Next, select a _GameObject_ in the scene and add a _Simple Scriptable Event Listener_ component:
<p align="center">
  <img src="simple-scriptable-event-listener.png"/>
</p>

Once you've added a listener, insert your event asset into the _Scriptable Event_ field (1). In the _On Raised_ [Unity Event] field (2) add the methods you'd like to be triggered by the event. For example, if you need to change a color of an object, your setup might look like the following as seen in the _Simple Events_ sample:
<p align="center">
  <img src="simple-scriptable-event-sample.png"/>
</p>

Now that you have your listener ready, you need to trigger the event. This can be done from a [Unity Event] by calling `SimpleScriptableEvent.Raise` method or by selecting the event asset and clicking the _Raise_ button during runtime:
<p align="center">
  <img hspace="2%" width="40%" src="simple-scriptable-event-raise-unity-event.png"/>
  <img hspace="2%" width="40%" src="simple-scriptable-event-raise.png"/>
</p>

Alternatively you can trigger the event via code:
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

## Passing Arguments (Events With Arguments)
In some situations might need to pass an argument when triggering an event. For example, if the player takes damage, you might need to notify your systems with the amount of damage taken.

For such uses cases, this package provides a set of events with commonly used argument types. To create an event asset which accepts an argument, right-click in the project window and select an event from _Create/Scriptable Events/*_ menu which has the required type:
<p align="center">
  <img src="scriptable-event-arg.png"/>
</p>

Next, you'll need to add a listener. Each corresponding _Scriptable Event_ type provides a listener component. Each typed listener works in the same fashion as _Simple Scriptable Event Listener_. The only caveat is when inserting your methods into the _On Raised_ [Unity Event] field, make sure to select a **dynamic** method:
<p align="center">
  <img hspace="2%" width="40%" src="scriptable-event-listener-components.png"/>
  <img hspace="2%" width="40%" src="scriptable-event-listener-dynamic.png"/>
</p>

To trigger the event, follow the same steps as with _Simple Scriptable Event_. However, make sure to select a **dynamic** `Raise` method:
<p align="center">
  <img src="scriptable-event-raise-dynamic.png"/>
</p>

This example shows how to trigger a _Scriptable Event_ from a built-in Unity component, however you might want to invoke these events from your classes. To do so, define a [Unity Event] with an appropriate type in the following way:
```cs
using UnityEngine;
using UnityEngine.Events;

public class ExampleUnityEventUsage : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<float> onValueChanged;

    private void Start()
    {
        // Your argument value.
        var value = 1.0f;

        onValueChanged.Invoke(value);
    }
}
```

Alternatively you can trigger the event via code if you prefer not to use [Unity Event] functionality:
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

## Creating Custom Events (Custom Events)
In some cases using the built-in argument types is not sufficient. For example, if the player takes damage, you might also need to pass a reference to the object that dealt damage to the player. In this case passing only the damage taken is not enough, you need to pass a `class` argument which contains both of those values. For this you'll need to create a custom event.

To start, create a container `class` for your event data. In this example we'll pass the values needed to change the `Metallic` and `Color` properties of a material:
```cs
public class MaterialData
{
    public float Metallic { get; }

    public Color Color { get; }

    public MaterialData(float metallic, Color color)
    {
        Metallic = metallic;
        Color = color;
    }
}
```

Next, define a _Scriptable Event_ asset which will accept your argument. Note the `CreateAssetMenu` attribute, as it defines where your event will be located in the _Create_ menu:
```cs
using ScriptableEvents;
using UnityEngine;

[CreateAssetMenu(
    fileName = "MaterialDataScriptableEvent",
    menuName = "Custom Scriptable Events/Material Data Scriptable Event"
)]
public class MaterialDataScriptableEvent : BaseScriptableEvent<MaterialData>
{
}
```

Then, define a listener component for your event. Note that in this case the `AddComponentMenu` attribute is optional, however it is recommended to add it to keep things organized:
```cs
using ScriptableEvents;
using UnityEngine;

[AddComponentMenu("Custom Scriptable Events/Material Data Event Listener")]
public class MaterialDataScriptableEventListener : BaseScriptableEventListener<MaterialData>
{
}
```

Finally, you'll need to trigger the event. As usual, this can be done via a [Unity Event] or by directly calling the `Raise` method via code:
```cs
using UnityEngine;
using UnityEngine.Events;

public class MaterialOptionsHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<MaterialData> onMaterialChanged;

    [SerializeField]
    private MaterialDataScriptableEvent scriptableEvent;

    private void Start()
    {
        // Your argument value.
        var value = new MaterialData(metallic, color);

        // Via Unity Event.
        onMaterialChanged.Invoke(value);

        // Or via code.
        scriptableEvent.Raise(value)
    }
}
```

**Optionally** you can add a custom editor. This will allow you to click the _Raise_ button on your custom event asset during runtime. To do so, create an editor class which inherits `BaseScriptableEventEditor`. Make sure to place this class in the **Editor** directory, or your project will not build:
```cs
using ScriptableEvents.Editor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MaterialDataScriptableEvent))]
public class MaterialDataScriptableEventEditor : BaseScriptableEventEditor<MaterialData>
{
    protected override MaterialData DrawArgField(MaterialData value)
    {
        if (value == null)
        {
            value = new MaterialData(0f, Color.white);
        }

        EditorGUILayout.BeginVertical();
        var metallic = EditorGUILayout.Slider("Metallic", value.Metallic, 0f, 1f);
        var color = EditorGUILayout.ColorField("Color", value.Color);
        EditorGUILayout.EndVertical();

        return new MaterialData(metallic, color);
    }
}
```
