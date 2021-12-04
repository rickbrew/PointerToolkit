#nullable enable

using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public unsafe readonly ref struct CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6>
    where T : unmanaged
    where TBase1 : unmanaged
    where TBase2 : unmanaged
    where TBase3 : unmanaged
    where TBase4 : unmanaged
    where TBase5 : unmanaged
    where TBase6 : unmanaged
{
    private readonly T* p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private CastPtr(T* p) => this.p = p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator T*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6> ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase1*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6> ptr) => (TBase1*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase2*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6> ptr) => (TBase2*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase3*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6> ptr) => (TBase3*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase4*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6> ptr) => (TBase4*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase5*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6> ptr) => (TBase5*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase6*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6> ptr) => (TBase6*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6> ptr) => ptr.p;
}
