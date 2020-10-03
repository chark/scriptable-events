# Unity Scriptable Objects
This package provides utilities for implementing game architecture which is oriented around `ScriptableObject` assets and Game Events. Most of these ideas are based on[Unite2017](https://github.com/roboryantron/Unite2017).

## Features
- Game Events - allows transferring of event messages using `ScriptableObject` assets. See
- Game Event listeners - listener components which allow subscribing to specific events.
- Mutable Objects - allows sharing and resetting of data via `ScriptableObject` assets.

## Installation
This package can be installed by using the [Unity Package Manager](https://docs.unity3d.com/Packages/com.unity.package-manager-ui@2.0/manual/index.html). To install this package, add the following to `manifest.json`:
```json
{
  "dependencies": {
    "com.chark.unity-scriptable-objects": "https://github.com/chark/unity-scriptable-objects.git#upm"
  }
}
```

## Usage
Extensive usage documentation can be found [here](Assets/Documentation/README.md).
