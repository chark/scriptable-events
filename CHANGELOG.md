﻿# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0] - 2021-06-08
This release contains major breaking changes and migrates from 2019 (LTS) to 2020 (LTS) in order to utilise generics.

### Added
- `Add(Action<T>)` and `Remove(Action<T>)` methods under `IScriptableEvent`.
- `BaseScriptableEventEditor` which by default applies to all `BaseScriptableEvent<T>` assets. `BaseScriptableEventEditor<T>` (with a generic type) should be used only if `Raise` button functionality is required.
- Additional listener info including listener counts (see below "Added Listeners" label on `IScriptableEvent` assets).
- Events, listeners and editors (except editors for `Collision*` types) for `long`, `double`, `Quaternion`, `Collider`, `Collider2D`, `Collision`, `Collision2D` types.

### Changed
- Each event now exposes a generic `BaseScriptableEvent<T>` instead of a concrete implementation in the inspector. The additional argument for the event type as well as the `UnityEvent` type is no longer required.
- All events have been moved to `ScriptableEvents.Events` namespace to avoid clashing with Unity namespaces.
- All listeners have been moved to `ScriptableEvents.Listeners` namespace to avoid clashing with Unity namespaces.
- `trace` logging will provide listener method info, however it will impact the performance.
- Order of components and scriptable events in menus.

### Removed
- `Listeners` property from `IScriptableEvent`.
- All `UnityEvent` implementations.
- Removed duplicate listener check.

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