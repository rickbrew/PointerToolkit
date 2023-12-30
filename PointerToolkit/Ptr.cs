using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public unsafe readonly struct Ptr
    : IEquatable<Ptr>,
      IComparable<Ptr>,
      IFormattable
{
    private readonly void* p;

    private Ptr(void* p) => this.p = p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(Ptr other) => ((IntPtr)this.p).CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? other) => (other is Ptr p) && (this.p == p.p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(Ptr other) => this.p == other.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* Get() => this.p;

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
    public static implicit operator Ptr(void* p) => UnsafePtr.As<Ptr>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Ptr(void** p) => UnsafePtr.As<Ptr>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Ptr(void*** p) => UnsafePtr.As<Ptr>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Ptr(PtrPtr ptr) => Unsafe.As<PtrPtr, Ptr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Ptr(PtrPtrPtr ptr) => Unsafe.As<PtrPtrPtr, Ptr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Ptr(IntPtr intPtr) => Unsafe.As<IntPtr, Ptr>(ref intPtr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator IntPtr(Ptr ptr) => Unsafe.As<Ptr, IntPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Ptr(UIntPtr intPtr) => Unsafe.As<UIntPtr, Ptr>(ref intPtr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator UIntPtr(Ptr ptr) => Unsafe.As<Ptr, UIntPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void*(Ptr ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void**(Ptr ptr) => (void**)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void***(Ptr ptr) => (void***)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Ptr ptr1, Ptr ptr2) => ptr1.p == ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Ptr ptr1, Ptr ptr2) => ptr1.p != ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(Ptr ptr1, Ptr ptr2) => ptr1.p > ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(Ptr ptr1, Ptr ptr2) => ptr1.p < ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(Ptr ptr1, Ptr ptr2) => ptr1.p >= ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(Ptr ptr1, Ptr ptr2) => ptr1.p <= ptr2.p;
}
