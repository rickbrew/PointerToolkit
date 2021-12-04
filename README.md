# UnsafeRuntime
Provides structs that wrap pointers, and Unsafe methods for converting to and from `ref` pointers of any type.

Even using the built-in `Unsafe` class, you cannot reinterpret raw pointers for use in calls to methods such as `Interlocked.Exchange()` or `Volatile.Read()`. This package allows you to do stuff like that.

We may get this in .NET itself someday, if https://github.com/dotnet/runtime/issues/62342 is approved and landed. Until then, you can use this.
