# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.1.0] - 2022-xx-xx
Quality of life improvements.

### Added
- Utility window to help in creation of Scriptable Events. It can be found under _Right Click > Create > Scriptable Event > Custom Scriptable Event_ (at the very bottom).
- `ScriptableEventConstants` class which can be used to order custom events more neatly.
- `BaseScriptableEvent` class which is used internally to draw inspector GUIs. Using this class also improves Odin integration.
- Support for `Action<TArg>` listeners. This means that regular methods can now be used as listeners without the need of implementing `IScriptableEventListener<TArg>`.
- Additional _Raise_ button which is shown next to each added listener. Using this button listeners can be raised individually through the inspector.

### Changed
- Renamed Scriptable Event creation menu from _Scriptable **Events**_ to _Scriptable **Event**_.
- Moved Scriptable Event creation menu under _Folder_ and _Script_ creation menus so the package is less intrusive.
- All existing events now use `ScriptableEventConstants` to define their menu order.
- `lockDescription` is no longer serialized as its only useful during edit mode.
- All `bool` properties now have an `is` prefix.
- Improved `isDebug` messages to be more consistent. Additionally, a listener `Object` will be picked as a context when possible to improve the _ping_ functionality when clicking on a log message.
- Events can now be raised in edit mode via the _Raise_ button in if any listeners are added.
- Improved how `description` is drawn.

## [2.0.0] - 2021-07-07
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

## [1.0.1] - 2021-02-07

### Changed
- Fixed naming of GameObject event listener file. Now it should appear as expected in the editor.

## [1.0.0] - 2021-02-01
Initial release, here we list changes made after moving away from [Unity Scriptable Objects](https://github.com/chark/unity-scriptable-objects).

### Changed
- Naming of events, `*GameEvent` -> `*ScriptableEvent`.
- Rewrote event, listener and inspector GUI APIs.
- Rewrote test code.
- Documentation to only focus on events.
- Actions to trigger automatically on `master` and manually on `upm` branches.
