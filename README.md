# UnsafeRuntime
Provides structs that wrap pointers, and Unsafe methods for converting to and from `ref` pointers of any type.

Even using the built-in `System.Runtime.CompilerServices.Unsafe` class, you cannot reinterpret `ref`s to raw pointers for use in calls to methods such as `Interlocked.Exchange()` or `Volatile.Read()`. This package allows you to do stuff like that:

```cs
public static unsafe void* InterlockedExchange(ref void* p, void* newP)
{
    return (void*)Interlocked.Exchange(ref UnsafePtr.As<IntPtr>(ref p), (IntPtr)newP);
}

public static unsafe T* InterlockedExchange<T>(ref T* p, T* newP)
    where T : unmanaged
{
    return (T*)Interlocked.Exchange(ref UnsafePtr.As<T, IntPtr>(ref p), (IntPtr)newP);
}
```

We may get this in .NET itself someday, if https://github.com/dotnet/runtime/issues/62342 is approved and landed. Until then, you can use this.
