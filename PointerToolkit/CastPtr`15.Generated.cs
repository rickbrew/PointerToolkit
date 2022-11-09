#nullable enable

using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public unsafe readonly ref struct CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14>
    where T : unmanaged
    where TBase1 : unmanaged
    where TBase2 : unmanaged
    where TBase3 : unmanaged
    where TBase4 : unmanaged
    where TBase5 : unmanaged
    where TBase6 : unmanaged
    where TBase7 : unmanaged
    where TBase8 : unmanaged
    where TBase9 : unmanaged
    where TBase10 : unmanaged
    where TBase11 : unmanaged
    where TBase12 : unmanaged
    where TBase13 : unmanaged
    where TBase14 : unmanaged
{
    private readonly T* p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private CastPtr(T* p) => this.p = p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator T*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase1*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => (TBase1*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase2*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => (TBase2*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase3*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => (TBase3*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase4*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => (TBase4*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase5*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => (TBase5*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase6*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => (TBase6*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase7*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => (TBase7*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase8*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => (TBase8*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase9*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => (TBase9*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase10*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => (TBase10*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase11*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => (TBase11*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase12*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => (TBase12*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase13*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => (TBase13*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator TBase14*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => (TBase14*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void*(CastPtr<T, TBase1, TBase2, TBase3, TBase4, TBase5, TBase6, TBase7, TBase8, TBase9, TBase10, TBase11, TBase12, TBase13, TBase14> ptr) => ptr.p;
}
