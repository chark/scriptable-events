# Contributing
If you found a bug or want to add a feature, you are more than welcome to make a Pull Request!

When doing so, make sure to:
- Follow similar code style which is used in other scripts.
- Add test cases under [ScriptableEventAttributeTestSource](../Packages/com.chark.scriptable-events/Tests/Editor/ScriptableEventAttributeTestSource.cs) and [ScriptableEventTestSource](../Packages/com.chark.scriptable-events/Tests/Runtime/ScriptableEventTestSource.cs) when adding new event types.
- Add tests for additional features, for example how [SimpleScriptableEventTest](../Packages/com.chark.scriptable-events/Tests/Runtime/SimpleScriptableEventTest.cs) does it for an additional method that is not covered in [ScriptableEventTest](../Packages/com.chark.scriptable-events/Tests/Runtime/ScriptableEventTest.cs).
