# UnsafeRuntime
Provides structs that wrap pointers, Unsafe methods for converting to and from `ref` pointers of any type, as well as `Interlocked` and `Volatile` operations on `ref` pointers.

Even using the built-in `System.Runtime.CompilerServices.Unsafe` class, you cannot reinterpret `ref`s to raw pointers for use in calls to methods such as `Interlocked.Exchange()` or `Volatile.Read()`. This package allows you to do stuff like that:

```cs
namespace PointerToolkit
{
    public static unsafe class InterlockedPtr
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void* Exchange(ref void* location1, void* value)
        {
            return (void*)Interlocked.Exchange(ref UnsafePtr.As<IntPtr>(ref location1), (IntPtr)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T* Exchange<T>(ref T* location1, T* value)
            where T : unmanaged
        {
            return (T*)Interlocked.Exchange(ref UnsafePtr.As<T, IntPtr>(ref location1), (IntPtr)value);
        }
    }
}
```

Pointers up to 3 levels of indirection are supported, e.g. `void***` and `T***`. The helper classes `UnsafePtr`, `InterlockedPtr`, and `VolatilePtr` are provided.

We may get this in .NET itself someday, if https://github.com/dotnet/runtime/issues/62342 is approved and landed. Until then, you can use this.
