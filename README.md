# PointerToolkit
Provides structs that wrap pointers, as well as `Unsafe`, `Interlocked`, and `Volatile` operations on ref pointers.

Even using the built-in `System.Runtime.CompilerServices.Unsafe` class, you cannot reinterpret `ref`s to raw pointers for use in calls to methods such as `Interlocked.Exchange()` or `Volatile.Read()`. 

Pointers up to 3 levels of indirection are supported, e.g. `void***` and `T***`. The helper classes `UnsafePtr`, `InterlockedPtr`, and `VolatilePtr` are provided.

We may get this in .NET itself someday, if https://github.com/dotnet/runtime/issues/62342 is approved and landed. Until then, you can use this.

`CastPtr<...>` is also provided, which can be used to generate static `__cast()` "method operators." This solves the problem where you have (e.g.) an `ID2D1SolidColorBrush*` that you need to pass to a method that takes a pointer to a base interface, such as `ID2D1Brush*`. Instead of forcing a pointer cast with `(ID2D1Brush*)`, which denies the compiler a chance to verify that the cast is appropriate, you can use `__cast(p)`. A temporary `CastPtr<ID2D1SolidColorBrush, ID2D1Brush, ID2D1Resource, IUnknown>` will be created which will implicitly cast to pointers of all the base interface pointer types. (Note that "interface" in the sense refers to a COM interface, not a managed interface.)

```cs
namespace PointerToolkit;

public static unsafe class UnsafePtr
{
    public static ref T As<T>(ref void* source)
        where T : unmanaged;

    public static ref U As<T, U>(ref T* source)
        where T : unmanaged
        where U : unmanaged;

    // etc.
}

public static unsafe class InterlockedPtr
{
    public static void* Exchange(ref void* location1, void* value);

    public static T* Exchange<T>(ref T* location1, T* value)
        where T : unmanaged;

    // etc.
}

public static unsafe class VolatilePtr
{
    public static void* Read(ref void* location);

    public static T* Read<T>(ref T* location)
        where T : unmanaged;

    public static void Write(ref void* location, void* value);

    public static void Write<T>(ref T* location, T* value)
        where T : unmanaged;

    // etc.
}
```
