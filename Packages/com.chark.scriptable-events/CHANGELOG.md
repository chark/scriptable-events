# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [v4.0.0](https://github.com/chark/scriptable-events/compare/v3.0.0...v4.0.0) - 2025-XX-XX

### Added

- More event types for primitives and common Unity types: `byte`, `short`, `Vector4`, `Object`.

### Changed

- Events by default will suppress exceptions.
- 2D physics events will not throw compilation errors if the 2D packages are disabled.

## [v3.0.0](https://github.com/chark/scriptable-events/compare/v2.2.0...v3.0.0) - 2023-10-05

This release tidies up this package, so it is consistent with other packages published by CHARK. Additionally, this release includes a set of **breaking changes** which will affect you if you're upgrading from previous versions.

### Changes

- Renamed `BaseScriptableEvent` to `ScriptableEvent`.
- Renamed `BaseScriptableEventListener` to `ScriptableEventListener`.
- Renamed `BaseScriptableEventEditor` to `ScriptableEventEditor`.
- Renamed `BaseScriptableEventListenerEditor` to `ScriptableEventListenerEditor`.
- Updated all built-in `BaseScriptableEvent` and `ScriptableEvent` implementations to use `sealed` keyword to prevent inheriting built-in event and listener implementations.
- Updated namespaces to use `CHARK.` prefix.
- Updated menu items to use `CHARK/` prefix.
- Updated assemblies to use `CHARK.` (instead of `Chark.`) prefix in their names.
- Updated assemblies to use GUIDs instead of assembly names when referencing other assemblies.
- Updated samples as they broke after changing class names and namespaces.
- Updated script generation logic to accomodate namespace and naming changes.
- Updated Documentation to include, namespace, menu item and renaming changes. Additionally, some information regarding addressables was added as well.
- Updated Script Creator window to generate more restricted classes, with `sealed` and `internal` keywords instead of just `public`.

## [v2.2.0](https://github.com/chark/scriptable-events/compare/v2.1.0...v2.2.0) - 2022-08-04

Multi events.

### Changed

- `BaseScriptableEventListener<TArg>` now supports multiple events. This should be a non-breaking change. Migration from `scriptableEvent` to a list of `scriptableEvents` is done via `ISerializationCallbackReceiver` which is implemented in `BaseScriptableEventListener<TArg>`.

## [v2.1.0](https://github.com/chark/scriptable-events/compare/v2.0.0...v2.1.0) - 2022-02-05

Quality of life improvements.

### Added

- Utility window to help in creation of Scriptable Events. It can be found via _Right Click > Create > Scriptable Event > Custom Scriptable Event_ (at the very bottom).
- `ScriptableEventConstants` class which can be used to order custom events more neatly.
- `BaseScriptableEvent` class (without `TArg`) which is inherited by all events and is used internally to draw inspector GUIs.
- `DefaultScriptableEventEditor` which targets `BaseScriptableEvent`. This addresses some issues when Odin Inspector is present in the project.
- `BaseScriptableEventListener` (without `TArg`) which is now inherited by all listeners.
- `BaseScriptableEventListenerEditor` which targets `BaseScriptableEventListener`. This addresses some issues when Odin Inspector is present in the project and will be used to add additional functionality to listener components in the future.
- Support for `Action<TArg>` listeners. This means that regular methods can now be used as listeners without the need of implementing `IScriptableEventListener<TArg>`.
- _Raise_ button which is shown next to each added listener. Using this button listeners can be raised individually through the inspector. This is useful for debugging purposes.
- Icons for events and listeners - this will require asset re-import.
- Odin Inspector support via the use of `#if ODIN_INSPECTOR`.

### Changed

- Renamed Scriptable Event creation menu from _Scriptable **Events**_ to _Scriptable **Event**_.
- Moved Scriptable Event menus below _Folder_ and _Script_ creation menu items so the package is less intrusive.
- All existing events now use `ScriptableEventConstants` to define their menu order.
- `lockDescription` is no longer serialized as its only useful during edit mode.
- All `bool` properties now have an `is` prefix.
- Improved `isDebug` messages to be more consistent. Additionally, a listener `Object` will be used as a context when possible to improve the [ping](https://docs.unity3d.com/ScriptReference/EditorGUIUtility.PingObject.html) functionality when clicking on a debug message in the Editor.
- Events can now be raised in Edit mode via the _Raise_ button in if any listeners are present in the event.
- Improved how event `description` is being drawn.
- Reworked all samples to be more consistent.
- Updated usage documentation to follow new samples and showcase event creation.

## [v2.0.0](https://github.com/chark/scriptable-events/compare/v1.0.1...v2.0.0) - 2021-07-07

This release contains major breaking changes and migrates from 2019 (LTS) to 2020 (LTS) in order to utilise generics.

### Added

- `BaseScriptableEventEditor` by default applies to all `BaseScriptableEvent<T>` assets. `BaseScriptableEventEditor<T>` (with a generic type) should be used only if `Raise` button functionality is required.
- Additional listener info including listener counts (see below "Added Listeners" label on `IScriptableEvent` assets).
- Events, listeners and editors (except editors for `Collision*` types) for `long`, `double`, `Quaternion`, `Collider`, `Collider2D`, `Collision`, `Collision2D` types.

### Changed

- All public `BaseScriptableEvent<T>` methods apart from `Raise` were renamed to have a `*Listener` suffix.
- Each listener now uses a generic `BaseScriptableEvent<T>` field instead of a concrete implementation. The additional argument for the event type as well as the `UnityEvent` type is no longer required.
- All events have been moved to `ScriptableEvents.Events` namespace to avoid clashing with Unity namespaces.
- All listeners have been moved to `ScriptableEvents.Listeners` namespace to avoid clashing with Unity namespaces.
- `trace` logging will provide more information.
- Order of components and scriptable events in menus.

### Removed

- `IScriptableEvent` interface as it had no use and only added boilerplate.
- `Listeners` property from `BaseScriptableEvent<T>`.
- All `UnityEvent` implementations.
- Duplicate listener check under `BaseScriptableEvent<T>`.

## [v1.0.1](https://github.com/chark/scriptable-events/compare/v1.0.0...v1.0.1) - 2021-02-07

### Changed

- Fixed naming of GameObject event listener file. Now it should appear as expected in the editor.

## [v1.0.0](https://github.com/chark/scriptable-events/compare/v1.0.0) - 2021-02-01

Initial release, here we list changes made after moving away from [Unity Scriptable Objects](https://github.com/chark/unity-scriptable-objects).

### Changed

- Naming of events, `*GameEvent` -> `*ScriptableEvent`.
- Rewrote event, listener and inspector GUI APIs.
- Rewrote test code.
- Documentation to only focus on events.
- Actions to trigger automatically on `master` and manually on `upm` branches.
