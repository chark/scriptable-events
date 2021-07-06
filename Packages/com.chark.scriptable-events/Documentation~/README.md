[Unity Event]: https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html
[Samples~]: ../Samples%7E

# Documentation

## Samples
The documented features can be imported as samples via _Unity Package Manager_ from the [Samples~] directory:
<p align="center">
  <img src="samples.png"/>
</p>

## Getting Started
The simplest use case of _Scriptable Events_ is when you want to notify a system that something happened without providing any context. To do so, you need two elements: a _Simple Scriptable Event_ and a _Simple Scriptable Event Listener_.

First, create a _Simple Scriptable Event_ asset by right-clicking in the project window and selecting _Scriptable Events/Simple Scriptable Event_. You can name the event as you'd like and place it anywhere in your project:
<p align="center">
  <img src="simple-scriptable-event.png"/>
</p>

Next, select a _GameObject_ of your liking in the scene and add a _Simple Scriptable Event listener_:
<p align="center">
  <img src="simple-scriptable-event-listener.png"/>
</p>

Once you've added a listener, insert your event asset into the _Scriptable Event_ field (1). In the _On Raised_ [Unity Event] field (2), insert the methods you'd like to be triggered by the event.

For example, if you wanted to change a color of an object, your setup might look like the following (as seen in the _Simple Events_ sample):
<p align="center">
  <img src="simple-scriptable-event-sample.png"/>
</p>

Now that you have your listener ready, you need to trigger the event. This can be done from a [Unity Event] or by selecting the event asset and clicking the _Raise_ when the game is running:
<p align="center">
  <img hspace="2%" src="simple-scriptable-event-raise-unity-event.png"/>
  <img hspace="2%" src="simple-scriptable-event-raise.png"/>
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
