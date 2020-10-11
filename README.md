# Unity Scriptable Objects
[![Unity 2019.4+](https://img.shields.io/badge/unity-2019.4%2B-blue.svg)](https://unity3d.com/get-unity/download)

This package provides utilities for implementing game architecture which is oriented around `ScriptableObject` assets and game events. Most of these ideas are based on [Unite2017](https://github.com/roboryantron/Unite2017).

## Features
- Game events - allows transferring of data between scripts using `ScriptableObject` event assets.
- Game event listeners - listener components which allow subscribing to various events.
- Mutable objects - eases up sharing of mutable data via `ScriptableObject` assets.

## Installation
This package can be installed by using the [Unity Package Manager]. To install this package, add the following to `manifest.json`:
```json
{
  "dependencies": {
    "com.chark.unity-scriptable-objects": "https://github.com/chark/unity-scriptable-objects.git#upm"
  }
}
```

## Samples
Example usage of game events and mutable objects can be found in [Assets/Samples](Assets/Samples) directory. These samples can also be imported via [Unity Package Manager].

## Documentation

### Game events
<p align="middle">
  <img
    src="/Assets/Documentation~/game-events.png"
    width="49.5%" alt="Example usage of Game Event assets"
  />
  <img
    src="/Assets/Documentation~/listeners.png" width="49.5%"
    alt="Example of a setup Game Event Listener component"
  />
</p>

Game events are scriptable objects (_Right Click -> Create -> Game Events -> ..._) which can be subscribed to via listener components (_Add Component -> Game Events -> ..._). Events allow to decouple scripts and instead rely on intermediate `ScriptableObject` assets for communication.

Available game events:
- `GameEvent` - simple event which doesn't accept any arguments.
- `BoolGameEvent` - event with a `bool` argument.
- `IntGameEvent` - event with a `int` argument.
- `FloatGameEvent` - event with a `float` argument.
- `StringGameEvent` - event with a `string` argument.
- `Vector2GameEvent` - event with a `Vector2` argument.
- `Vector3GameEvent` - event with a `Vector3` argument.
- `TransformGameEvent` - event with a `Transform` argument.
- `GameObjectGameEvent` - event with a `GameObject` argument.

### Mutable objects
<img
  src="/Assets/Documentation~/mutable-objects.png"
  width="100%" alt="Example usage of Mutable Objects"
/>

Mutable objects are used for storing and editing data on `ScriptableObject` assets at runtime. This data can be referenced, observed and used as a bridge by various scripts. Mutable objects are useful in situations where `ScriptableObject` data needs to be reset when the [active scene changes](https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-activeSceneChanged.html).

Available mutable objects:
- `MutableBool` - encapsulates a `bool` value.
- `MutableInt` - encapsulates a `int` value.
- `MutableFloat` - encapsulates a `float` value.
- `MutableString` - encapsulates a `string` value.
- `MutableVector2` - encapsulates a `Vector2` value.
- `MutableVector3` - encapsulates a `Vector3` value.

Each mutable object has a `ResetType` property. This allows specifying when data in the mutable object should be reset. The following modes are available:
- `None` - do not reset.
- `ActiveSceneChange` - when the active (focused) scene changes.
- `SceneUnloaded` - when the current scene gets unloaded.
- `SceneLoaded` - when the scene is loaded.

### Custom game events
In some situations, built-in game events might not suffice. For example if a custom type needs to be passed as an argument to the event. In this case, custom game event can be created which would carry all the necessary data.

To create a custom game event, first create a regular `UnityEvent`:
```cs
[Serializable]
public class CustomEvent : UnityEvent<Custom>
{
}
```

After that is ready, create a game event by extending `GameEvents.Generic.ArgumentGameEvent`:
```cs
[CreateAssetMenu(fileName = "CustomEvent", menuName = "Game Events/Custom Event")]
public class CustomGameEvent : ArgumentGameEvent<Custom>
{
}
```

Finally, create a game event listener by extending `GameEvents.Generic.ArgumentGameEventListener`:
```cs
[AddComponentMenu("Game Events/Custom Game Event Listener")]
public class CustomGameEventListener : ArgumentGameEventListener<CustomGameEvent, CustomEvent, Custom>
{
}
```

Optionally add a custom editor so that the event could be raised, and the listeners which reference the event get displayed in the inspector.
```cs
[CustomEditor(typeof(CustomGameEvent))]
public class GameObjectGameEventEditor : ArgumentGameEventEditor<CustomGameEvent, Custom>
{
    protected override Custom DrawArgumentField(Custom value)
    {
        var fieldValue = EditorGUILayout
            .ObjectField(value, typeof(Custom), true);

        return fieldValue as Custom;
    }
}
```

### Custom mutable objects
In some cases, littering the script code with loads of `MutableObject` references can be inconvenient. To avoid this, a single object can be used which encompasses multiple fields.

To create a custom mutable object, extend `MutableObjects.Generic.MutableObject` and override `ResetValues()` method, e.g:
```cs
[CreateAssetMenu(fileName = "MutableCustom", menuName = "Mutable Objects/Mutable Custom")]
public class MutableCustom : MutableObject
{
    [SerializeField]
    private int health = default;

    [SerializeField]
    private int armor = default;

    [SerializeField]
    private int xp = default;

    public int Health { get; set; }

    public int Armor { get; set; }

    public int Xp { get; set; }

    // This will set property values when mutable object is enabled or if the values change in the
    // inspector.
    public override void ResetValues()
    {
        Health = health;
        Armor = armor;
        Xp = xp;
    }
}
```

[Unity Package Manager]: https://docs.unity3d.com/Packages/com.unity.package-manager-ui@2.0/manual/index.html
