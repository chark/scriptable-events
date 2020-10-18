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

<!--- Documentation will be added below this point. -->
