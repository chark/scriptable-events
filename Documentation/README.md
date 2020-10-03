# Documentation

## Game Events
The library provides two types of game events:
- `GameEvent` without arguments.
- `ArgumentGameEvent` which accepts arguments.

### Game event assets
The core of events is game event `ScriptableObject` assets. They store game event listeners and notify them when an event is raised. To use game events, create an appropriate game event type asset (where _"Argument Name"_ is type of the argument that you are going to be passing to your events):
- `GameEvent` - _Right Click -> Create -> Game Events -> Game Event_
- `ArgumentGameEvent` - _Right Click -> Create -> Game Events -> "Argument Name" Game Event_

Event assets can be referenced and raised in scripts directly or used in `UnityEvent` fields:
```cs
public class SceneManager : MonoBehaviour
{
    // Reference GameEvent directly.
    [SerializedField]
    private GameEvent startSceneGameEvent = default;

    // Or inside UnityEvent.
    [SerializedField]
    private UnityEvent onStartScene = default;

    private void Start()
    {
        if (startSceneGameEvent != null)
        {
            startSceneGameEvent.RaiseGameEvent();
        }

        onStartScene.Invoke();
    }
}
```

### Custom game events
If you need to define a game event which accepts custom arguments, extend `GameEvents.Generic.ArgumentGameEvent` class:
```cs
[CreateAssetMenu(fileName = "CustomGameEvent", menuName = "Game Events/Custom Game Event")]
public class CustomGameEvent : ArgumentGameEvent<Custom>
{
}
```

In order to enable raising of custom game events from the inspector, create a `CustomEditor` script where the argument fields are going to be drawn. Extend `GameEvents.Generic.ArgumentGameEventEditor` and override `DrawArgumentField(Custom)`. Make sure to place this script under the `Editor` folder:
```cs
[CustomEditor(typeof(CustomGameEvent))]
public class CustomGameEventEditor : ArgumentGameEventEditor<CustomGameEvent, Custom>
{
    protected override Custom DrawArgumentField(Custom value)
    {
        // Draw Custom value input fields here.
    }
}
```

### Game event listeners
Game events can be listened to by listener components. To use pre-made listeners, add an appropriate listener component:
- `GameEvent` - _Add Component -> Game Events -> Game Event Listener_
- `ArgumentGameEvent` - _Add Component -> Game Events -> "Argument Name" Game Event Listener_

Once the component is added, slot in the appropriate `GameEvent` you want the listener to listen to and add your response methods to `onGameEvent` callback via the inspector.

### Custom game event listeners
Custom game event listeners which accept different arguments can also be created. Create a `UnityEvent` which would accept your `Custom` type:
```cs
[Serializable]
public class CustomEvent : UnityEvent<Custom>
{
}
```

Then, create a custom game event listener by extending `GameEvents.Generic.ArgumentGameEventListener`.
```cs
[AddComponentMenu("Game Events/Custom Game Event Listener")]
public class CustomGameEventListener : ArgumentGameEventListener<CustomGameEvent, CustomEvent, Custom>
{
}
```

### Examples
Import the `GameEvents` samples which show how to use game events in various situations.
