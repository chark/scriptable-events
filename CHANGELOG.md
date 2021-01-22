# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.0] - 2020-10-24

### Changed
- Exposed `OnValidate` and `OnEnable` methods to children of `MutableObject`.

## [1.0.0] - 2020-10-13

### Changed
- Made game event editors more user-friendly.
- Naming in asset menus for game events.
- Listeners are now exposed as an unmodifiable `ICollection`.

## [1.0.0-rc.1] - 2020-10-11

## [0.7.0] - 2020-10-11

### Added
- List of references to event listeners on game events will be drawn during play mode.
- Exposed listener enumerable.
- Editors for all built-in game event types.
- More tests!

### Changed
- `Persisting` flag was changed to `ResetType` enum which allows more customization.

### Removed
- Game event null checks on enable and disable.

## [0.6.0] - 2020-10-07

### Changed
- Updated rendering settings for samples.
- Fixed version in `package.json`.

## [0.5.0] - 2020-10-07

### Added
- Tests for game events and their listeners.
- Tests for mutable objects.

### Changed
- **Renamed** event and listener trigger functions (`OnGameEvent` -> `RaiseGameEvent`).
- **Renamed** `GameEvents.Vector2.Vector3GameEvent` to `GameEvents.Vector2.Vector2GameEvent`, fixed typo.
- Made `MutableObjectHandler` more extensible.
- Exposed `GameEvent` and `OnGameEvent` on listeners via properties.
- `MutableObject` instances are now reset using `SceneManager.activeSceneChanged`.

## [0.4.0] - 2020-10-06

### Added
- `MutableObjectHandler` which would automate the process of resetting `MutableObjects`.
- `Persisting` property on `IMutableObject` which determines how resetting should be handled.

### Changed
- Cleaned up `MutableObject` sample.
- Updated documentation.

### Removed
- `MutableObjectExtensions` as its purpose is now automated.

## [0.3.0] - 2020-10-05

### Added
- Added `MutableBool`.

### Changed
- Updated documentation.
- Cleaned up some classes to match the code style of the project.
- Updated assemblies.

## [0.2.1] - 2020-10-03

### Added
- Images to documentation.

## [0.2.0] - 2020-10-03

### Added
- Mutable objects.
- Samples for mutable objects.

### Added
- Assembly definition for samples.

## [0.1.0] - 2020-10-03

### Added
- Game events and listener components.
- Game events with arguments and listener components.
- Editors for raising game events and game events with arguments.
- Samples on how to use game events.
- Documentation.
