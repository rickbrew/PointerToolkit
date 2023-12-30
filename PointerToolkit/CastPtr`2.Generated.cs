#nullable enable

using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public unsafe readonly ref struct CastPtr<T, TBase1>
    where T : unmanaged
    where TBase1 : unmanaged
{
    private readonly T* p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private CastPtr(T* p) => this.p = p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator CastPtr<T, TBase1>(T* p) => *(CastPtr<T, TBase1>*)&p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator T*(CastPtr<T, TBase1> ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase1*(CastPtr<T, TBase1> ptr) => (TBase1*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void*(CastPtr<T, TBase1> ptr) => ptr.p;
}
