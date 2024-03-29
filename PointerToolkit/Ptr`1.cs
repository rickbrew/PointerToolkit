﻿using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public unsafe readonly struct Ptr<T>
    : IEquatable<Ptr<T>>,
      IComparable<Ptr<T>>,
      IFormattable
      where T : unmanaged
{
    private readonly T* p;

    private Ptr(T* p) => this.p = p;

    public ref T Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref *this.p;
    }

    public ref T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref *(this.p + index);
    }

    public ref T this[long index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref *(this.p + index);
    }

    public ref T this[nint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref *(this.p + index);
    }

    public ref T this[uint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref *(this.p + index);
    }

    public ref T this[ulong index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref *(this.p + index);
    }

    public ref T this[nuint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref *(this.p + index);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(Ptr<T> other) => ((IntPtr)this.p).CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? other) => (other is Ptr<T> p) && (this.p == p.p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Ptr<T> other) => this.p == other.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T* Get() => this.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => ((IntPtr)this.p).GetHashCode();

    public override string ToString()
    {
        return ((UIntPtr)this.p).ToString(sizeof(IntPtr) == 4 ? "X8" : "X16");
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return ((UIntPtr)this.p).ToString(format, formatProvider);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Ptr<T>(T* p) => UnsafePtr.As<T, Ptr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Ptr<T>(T** p) => UnsafePtr.As<T, Ptr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Ptr<T>(T*** p) => UnsafePtr.As<T, Ptr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Ptr<T>(void* p) => UnsafePtr.As<Ptr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Ptr<T>(void** p) => UnsafePtr.As<Ptr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Ptr<T>(void*** p) => UnsafePtr.As<Ptr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Ptr<T>(PtrPtr<T> ptr) => Unsafe.As<PtrPtr<T>, Ptr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Ptr<T>(PtrPtrPtr<T> ptr) => Unsafe.As<PtrPtrPtr<T>, Ptr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Ptr<T>(Ptr ptr) => Unsafe.As<Ptr, Ptr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Ptr<T>(PtrPtr ptr) => Unsafe.As<PtrPtr, Ptr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Ptr<T>(PtrPtrPtr ptr) => Unsafe.As<PtrPtrPtr, Ptr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Ptr(Ptr<T> ptr) => Unsafe.As<Ptr<T>, Ptr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr(Ptr<T> ptr) => Unsafe.As<Ptr<T>, PtrPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr(Ptr<T> ptr) => Unsafe.As<Ptr<T>, PtrPtrPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Ptr<T>(IntPtr intPtr) => Unsafe.As<IntPtr, Ptr<T>>(ref intPtr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator IntPtr(Ptr<T> ptr) => Unsafe.As<Ptr<T>, IntPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Ptr<T>(UIntPtr intPtr) => Unsafe.As<UIntPtr, Ptr<T>>(ref intPtr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator UIntPtr(Ptr<T> ptr) => Unsafe.As<Ptr<T>, UIntPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator T*(Ptr<T> ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator T**(Ptr<T> ptr) => (T**)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator T***(Ptr<T> ptr) => (T***)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void*(Ptr<T> ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void**(Ptr<T> ptr) => (void**)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void***(Ptr<T> ptr) => (void***)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Ptr<T> ptr1, Ptr<T> ptr2) => ptr1.p == ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Ptr<T> ptr1, Ptr<T> ptr2) => ptr1.p != ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(Ptr<T> ptr1, Ptr<T> ptr2) => ptr1.p > ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(Ptr<T> ptr1, Ptr<T> ptr2) => ptr1.p < ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(Ptr<T> ptr1, Ptr<T> ptr2) => ptr1.p >= ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(Ptr<T> ptr1, Ptr<T> ptr2) => ptr1.p <= ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator +(Ptr<T> ptr, int count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator +(int count, Ptr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator +(Ptr<T> ptr, long count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator +(long count, Ptr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator +(Ptr<T> ptr, nint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator +(nint count, Ptr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator +(Ptr<T> ptr, uint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator +(uint count, Ptr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator +(Ptr<T> ptr, ulong count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator +(ulong count, Ptr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator +(Ptr<T> ptr, nuint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator +(nuint count, Ptr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator -(Ptr<T> ptr, int count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator -(Ptr<T> ptr, long count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator -(Ptr<T> ptr, nint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator -(Ptr<T> ptr, uint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator -(Ptr<T> ptr, ulong count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Ptr<T> operator -(Ptr<T> ptr, nuint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long operator -(Ptr<T> ptr1, Ptr<T> ptr2) => ptr1.p - ptr2.p;
}
