using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public unsafe readonly struct PtrPtrPtr
    : IEquatable<PtrPtrPtr>,
      IComparable<PtrPtrPtr>
{
    private readonly void*** p;

    private PtrPtrPtr(void*** p) => this.p = p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void*** Get() => this.p;

    public ref void** Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref *this.p;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator PtrPtrPtr(void*** p) => UnsafePtr.As<PtrPtrPtr>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void***(PtrPtrPtr ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals(object? other) => (other is PtrPtrPtr p) && (this.p == p.p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(PtrPtrPtr other) => ((IntPtr)this.p).CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(PtrPtrPtr other) => this.p == other.p;

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
    public override int GetHashCode() => ((IntPtr)this.p).GetHashCode();

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
