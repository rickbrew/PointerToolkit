using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public unsafe readonly struct PtrPtrPtr
    : IEquatable<PtrPtrPtr>,
      IComparable<PtrPtrPtr>,
      IFormattable
{
    private readonly void*** p;

    private PtrPtrPtr(void*** p) => this.p = p;

    public ref PtrPtr Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<PtrPtr>(ref *this.p);
    }

    public ref PtrPtr this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<PtrPtr>(ref *(this.p + index));
    }

    public ref PtrPtr this[long index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<PtrPtr>(ref *(this.p + index));
    }

    public ref PtrPtr this[nint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<PtrPtr>(ref *(this.p + index));
    }

    public ref PtrPtr this[uint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<PtrPtr>(ref *(this.p + index));
    }

    public ref PtrPtr this[ulong index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<PtrPtr>(ref *(this.p + index));
    }

    public ref PtrPtr this[nuint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<PtrPtr>(ref *(this.p + index));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(PtrPtrPtr other) => ((IntPtr)this.p).CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? other) => (other is PtrPtrPtr p) && (this.p == p.p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(PtrPtrPtr other) => this.p == other.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void*** Get() => this.p;

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
    public static explicit operator PtrPtrPtr(void* p) => UnsafePtr.As<PtrPtrPtr>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr(void** p) => UnsafePtr.As<PtrPtrPtr>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator PtrPtrPtr(void*** p) => UnsafePtr.As<PtrPtrPtr>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr(Ptr ptr) => Unsafe.As<Ptr, PtrPtrPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr(PtrPtr ptr) => Unsafe.As<PtrPtr, PtrPtrPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr(IntPtr intPtr) => Unsafe.As<IntPtr, PtrPtrPtr>(ref intPtr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator IntPtr(PtrPtrPtr ptr) => Unsafe.As<PtrPtrPtr, IntPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr(UIntPtr intPtr) => Unsafe.As<UIntPtr, PtrPtrPtr>(ref intPtr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator UIntPtr(PtrPtrPtr ptr) => Unsafe.As<PtrPtrPtr, UIntPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void*(PtrPtrPtr ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void**(PtrPtrPtr ptr) => (void**)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void***(PtrPtrPtr ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PtrPtrPtr ptr1, PtrPtrPtr ptr3) => ptr1.p == ptr3.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PtrPtrPtr ptr1, PtrPtrPtr ptr3) => ptr1.p != ptr3.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PtrPtrPtr ptr1, PtrPtrPtr ptr2) => ptr1.p > ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PtrPtrPtr ptr1, PtrPtrPtr ptr2) => ptr1.p < ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PtrPtrPtr ptr1, PtrPtrPtr ptr2) => ptr1.p >= ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PtrPtrPtr ptr1, PtrPtrPtr ptr2) => ptr1.p <= ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator +(PtrPtrPtr ptr, int count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator +(int count, PtrPtrPtr ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator +(PtrPtrPtr ptr, long count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator +(long count, PtrPtrPtr ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator +(PtrPtrPtr ptr, nint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator +(nint count, PtrPtrPtr ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator +(PtrPtrPtr ptr, uint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator +(uint count, PtrPtrPtr ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator +(PtrPtrPtr ptr, ulong count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator +(ulong count, PtrPtrPtr ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator +(PtrPtrPtr ptr, nuint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator +(nuint count, PtrPtrPtr ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator -(PtrPtrPtr ptr, int count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator -(PtrPtrPtr ptr, long count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator -(PtrPtrPtr ptr, nint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator -(PtrPtrPtr ptr, uint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator -(PtrPtrPtr ptr, ulong count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr operator -(PtrPtrPtr ptr, nuint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long operator -(PtrPtrPtr ptr1, PtrPtrPtr ptr2) => ptr1.p - ptr2.p;
}
