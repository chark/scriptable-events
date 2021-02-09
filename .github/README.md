# Scriptable Events
[![Unity 2019.4+](https://img.shields.io/badge/unity-2019.4%2B-blue.svg)](https://unity3d.com/get-unity/download)
[![Actions Status](https://github.com/chark/scriptable-events/workflows/CI/badge.svg)](https://github.com/chark/scriptable-events/actions)
[![openupm](https://img.shields.io/npm/v/com.chark.scriptable-events?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.chark.scriptable-events/)

Simple and extensible event system implemented via `ScriptableObject`, based on [Unite2017](https://github.com/roboryantron/Unite2017).

<p align="center">
  <img hspace="2%" src="event.png"/>
  <img hspace="2%" src="event-listener.png"/>
</p>

## Features
- Can be used with minimal or no code at all.
- Default event and listener implementations for commonly used types.
- Strongly typed.
- Ability to easily add custom events and inspector GUIs.

## Installation
This package can be installed via [OpenUPM](https://openupm.com/packages/com.chark.scriptable-events/):
```text
openupm add com.chark.scriptable-events
```

Or via the Unity Package Manager by [Installing from a Git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html):
```text
https://github.com/chark/scriptable-events.git#upm
```

Alternatively, you can also install it by adding the following dependency to `Packages/manifest.json`:
```text
"com.chark.scriptable-events": "https://github.com/chark/scriptable-events.git#upm"
```

## Documentation
- [Usage documentation](../Packages/com.chark.scriptable-events/Documentation~/README.md)
- [Contributing](CONTRIBUTING.md)
- [Changelog](../Packages/com.chark.scriptable-events/CHANGELOG.md)
