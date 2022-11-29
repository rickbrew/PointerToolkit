# PointerToolkit
Provides structs that wrap pointers, as well as `Unsafe`, `Interlocked`, and `Volatile` operations on ref pointers. 

All of the functionality contained within is being used for the work in my upcoming Paint.NET v5.0 release. I'm porting 50,000 lines of C++/CLI, almost all classes that wrap native COM objects, to C#. This package, along with [TerraFX.Interop.Windows](https://github.com/terrafx/terrafx.interop.windows), are the foundation for this work.

The `Ptr` and `Ptr<T>` structs are straightforward enough, they simply wrap a pointer and provide all the casting operators you will need. Pointers up to 3 levels of indirection are supported, e.g. `void***` and `T***`, via`PtrPtr` and `PtrPtrPtr` and their generic versions.

The `UnsafePtr`, `InterlockedPtr`, and `VolatilePtr` classes provided methods similar to what is available with `Unsafe`, `Interlocked`, and `Volatile`, except that they work on `ref` pointers (`ref void*`, `ref T*`, as well as `**` and `***` variants). Refs to pointers are otherwise impossible to work well with in C# without these methods. You can't break them out of their "jail"; refs to pointers just don't work with generics or other attempted tricks employing combinations of `&`, `*`, `ref`, `in`, `Unsafe`, etc.

```cs
public static unsafe class UnsafePtr
{
    public static ref T As<T>(ref void* source) where T : unmanaged;
    public static ref U As<T, U>(ref T* source) where T : unmanaged where U : unmanaged;
    // etc.
}

public static unsafe class InterlockedPtr
{
    public static void* Exchange(ref void* location1, void* value);
    public static T* Exchange<T>(ref T* location1, T* value) where T : unmanaged;
    // etc.
}

public static unsafe class VolatilePtr
{
    public static void* Read(ref void* location);
    public static T* Read<T>(ref T* location) where T : unmanaged;
    public static void Write(ref void* location, void* value);
    public static void Write<T>(ref T* location, T* value) where T : unmanaged;

    // etc.
}
```

These structs are supported by the `PtrOperators` class, which contains `__ptr()` methods meant to be used in conjunction with a `global using static PointerToolkit.PtrOperators;` statement. They make it easy to pass pointers into places where they normally can't be used, such as in generics and generic delegates. The name `__ptr()` was chosen to be similar to vendor-specific additions in various C++ compilers, such as how Microsoft has `__uuidof()` for working with COM interface identifiers.

For instance, let's say you want to call a method on a COM object inside the delegate passed to `String.Create()`. Without PointerToolkit or your own struct wrappers, you'd have to pass it in as an `IntPtr` and cast it back yourself because you can't specify a pointer type for the `T` in `SpanAction<T>` . `Ptr<IFoo>` helps with that. In addition, the `__ptr()` "operator methods" help reduce the typing and duplication of types even further:

(an example from my wrapper for Direct2D's [`ID2D1Properties`](https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1properties))
```cs
public string? TryGetPropertyName(int index)
{
    using var @lock = EnterFactoryLock();

    uint dwNameLength = this.pD2D1Properties->GetPropertyNameLength(unchecked((uint)index));
    if (dwNameLength == 0)
    {
        return null;
    }

    return string.Create(
        checked((int)dwNameLength),        
        // without __ptr(), I'd have to type (Ptr<ID2D1Properties>)
        (__ptr(this.pD2D1Properties), index), 
        static (Span<char> dst, (Ptr<ID2D1Properties> pD2D1Properties, int index) e) =>
        {
            fixed (char* pDst = dst)
            {
                HRESULT hr = e.pD2D1Properties.Get()->GetPropertyName(
                    unchecked((uint)e.index),
                    (ushort*)pDst,
                    (uint)(dst.Length + 1));

                hr.ThrowOnError();
            }
        });
}
```

`CastPtr<...>` is also provided, which can be used to generate static `__cast()` "method operators." This solves the problem where you have (e.g.) an `ID2D1SolidColorBrush*` that you need to pass to a method that takes a pointer to a base interface, such as `ID2D1Brush*` or even `IUnknown*`. C# does not have struct inheritance, so all of the COM interface structs in [TerraFX.Interop.Windows](https://github.com/terrafx/terrafx.interop.windows) are unrelated as far as it can tell.

Instead of forcing a pointer cast with `(ID2D1Brush*)`, which denies the compiler a chance to verify that the cast is safe, you can use `__cast(p)` (along with an appropriate `using static` declaration). A temporary `CastPtr<ID2D1SolidColorBrush, ID2D1Brush, ID2D1Resource, IUnknown>` will be created which will implicitly cast to pointers of all of those base interface pointer types. (Note that "interface" in this case refers to a COM interface, not a managed interface.) The generation of these `__cast()` operators is not provided by this package, but you can see the [PointerToolkit.TerraFX.Interop.Windows](https://github.com/rickbrew/PointerToolkit.TerraFX.Interop.Windows) package for a real world example.

