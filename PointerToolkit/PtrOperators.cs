using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

/// <summary>
/// These methods are meant to be used in conjunction with a global `global using static PointerToolkit.PtrOperators;`.
/// They make it easy to pass a pointer into places where you can't normally use them, such as in generics and delegate,
/// without having to specify the Ptr type itself.
/// </summary>
public static unsafe class PtrOperators
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr __ptr(void* p) => (Ptr)p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr __ptr(void** p) => (PtrPtr)p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr __ptr(void*** p) => (PtrPtrPtr)p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> __ptr<T>(T* p) where T : unmanaged => (Ptr<T>)p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> __ptr<T>(T** p) where T : unmanaged => (PtrPtr<T>)p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> __ptr<T>(T*** p) where T : unmanaged => (PtrPtrPtr<T>)p;
}