# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0] - 2021-06-01
This release contains major breaking changes and migrates from 2019 (LTS) to 2020 (LTS) to utilise generics.

### Added
- Additional information will be shown on listener count on each `ScriptableEvent` asset, below "Added Listeners" label.
- `TypedScriptableEventEditor`, which should be used if `Raise` button is required on event assets. The `BaseScriptableEvent` should no longer be used to.

### Changed
- Each event now exposes a generic `BaseScriptableEvent<T>` instead of a concrete implementation in the inspector. This means that the additional argument for the event type as well as the `UnityEvent` type is no longer required.
- `BaseScriptableEventEditor` now by default applies to all `BaseScriptableEvent<T>` assets. This means that users no longer have to implement editors, unless the `Raise` button is required.
- All events have been moved to `ScriptableEvents.Events` namespace to avoid clashing with Unity namespaces.
- All listeners have been moved to `ScriptableEvents.Listeners` namespace to avoid clashing with Unity namespaces.

### Removed
- `Listeners` property from `IScriptableEvent` to simplify the API.
- All `UnityEvent` implementations due to the use of generics.

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
