using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public unsafe readonly struct PtrPtr
    : IEquatable<PtrPtr>,
      IComparable<PtrPtr>
{
    private readonly void** p;

    private PtrPtr(void** p) => this.p = p;

    public ref Ptr Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<Ptr>(ref *this.p);
    }

    public ref Ptr this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<Ptr>(ref *(this.p + index));
    }

    public ref Ptr this[long index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<Ptr>(ref *(this.p + index));
    }

    public ref Ptr this[nint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<Ptr>(ref *(this.p + index));
    }

    public ref Ptr this[uint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<Ptr>(ref *(this.p + index));
    }

    public ref Ptr this[ulong index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<Ptr>(ref *(this.p + index));
    }

    public ref Ptr this[nuint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<Ptr>(ref *(this.p + index));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(PtrPtr other) => ((IntPtr)this.p).CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? other) => (other is PtrPtr p) && (this.p == p.p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(PtrPtr other) => this.p == other.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void** Get() => this.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => ((IntPtr)this.p).GetHashCode();

    public override string ToString()
    {
        return ((UIntPtr)this.p).ToString((sizeof(IntPtr)) == 4 ? "X8" : "X16");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr(void* p) => UnsafePtr.As<PtrPtr>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator PtrPtr(void** p) => UnsafePtr.As<PtrPtr>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr(void*** p) => UnsafePtr.As<PtrPtr>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr(Ptr ptr) => Unsafe.As<Ptr, PtrPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr(PtrPtrPtr ptr) => Unsafe.As<PtrPtrPtr, PtrPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr(IntPtr intPtr) => Unsafe.As<IntPtr, PtrPtr>(ref intPtr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator IntPtr(PtrPtr ptr) => Unsafe.As<PtrPtr, IntPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr(UIntPtr intPtr) => Unsafe.As<UIntPtr, PtrPtr>(ref intPtr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator UIntPtr(PtrPtr ptr) => Unsafe.As<PtrPtr, UIntPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void*(PtrPtr ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void**(PtrPtr ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void***(PtrPtr ptr) => (void***)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PtrPtr ptr1, PtrPtr ptr2) => ptr1.p == ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PtrPtr ptr1, PtrPtr ptr2) => ptr1.p != ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PtrPtr ptr1, PtrPtr ptr2) => ptr1.p > ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PtrPtr ptr1, PtrPtr ptr2) => ptr1.p < ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PtrPtr ptr1, PtrPtr ptr2) => ptr1.p >= ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PtrPtr ptr1, PtrPtr ptr2) => ptr1.p <= ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator +(PtrPtr ptr, int count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator +(int count, PtrPtr ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator +(PtrPtr ptr, long count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator +(long count, PtrPtr ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator +(PtrPtr ptr, nint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator +(nint count, PtrPtr ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator +(PtrPtr ptr, uint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator +(uint count, PtrPtr ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator +(PtrPtr ptr, ulong count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator +(ulong count, PtrPtr ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator +(PtrPtr ptr, nuint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator +(nuint count, PtrPtr ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator -(PtrPtr ptr, int count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator -(PtrPtr ptr, long count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator -(PtrPtr ptr, nint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator -(PtrPtr ptr, uint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator -(PtrPtr ptr, ulong count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr operator -(PtrPtr ptr, nuint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long operator -(PtrPtr ptr1, PtrPtr ptr2) => ptr1.p - ptr2.p;
}
