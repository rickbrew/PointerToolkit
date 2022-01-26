using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public unsafe readonly struct PtrPtr<T>
    : IEquatable<PtrPtr<T>>,
      IComparable<PtrPtr<T>>
      where T : unmanaged
{
    private readonly T** p;

    private PtrPtr(T** p) => this.p = p;

    public ref Ptr<T> Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<T, Ptr<T>>(ref *this.p);
    }

    public ref Ptr<T> this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<T, Ptr<T>>(ref *(this.p + index));
    }

    public ref Ptr<T> this[long index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<T, Ptr<T>>(ref *(this.p + index));
    }

    public ref Ptr<T> this[nint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<T, Ptr<T>>(ref *(this.p + index));
    }

    public ref Ptr<T> this[uint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<T, Ptr<T>>(ref *(this.p + index));
    }

    public ref Ptr<T> this[ulong index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<T, Ptr<T>>(ref *(this.p + index));
    }

    public ref Ptr<T> this[nuint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<T, Ptr<T>>(ref *(this.p + index));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(PtrPtr<T> other) => ((IntPtr)this.p).CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? other) => (other is PtrPtr<T> p) && (this.p == p.p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(PtrPtr<T> other) => this.p == other.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T** Get() => this.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => ((IntPtr)this.p).GetHashCode();

    public override string ToString()
    {
        return ((UIntPtr)this.p).ToString((sizeof(IntPtr)) == 4 ? "X8" : "X16");
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return ((UIntPtr)this.p).ToString(format, formatProvider);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr<T>(T* p) => UnsafePtr.As<T, PtrPtr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator PtrPtr<T>(T** p) => UnsafePtr.As<T, PtrPtr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr<T>(T*** p) => UnsafePtr.As<T, PtrPtr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr<T>(void* p) => UnsafePtr.As<PtrPtr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr<T>(void** p) => UnsafePtr.As<PtrPtr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr<T>(void*** p) => UnsafePtr.As<PtrPtr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr<T>(Ptr<T> ptr) => Unsafe.As<Ptr<T>, PtrPtr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr<T>(PtrPtrPtr<T> ptr) => Unsafe.As<PtrPtrPtr<T>, PtrPtr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr<T>(Ptr ptr) => Unsafe.As<Ptr, PtrPtr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr<T>(PtrPtr ptr) => Unsafe.As<PtrPtr, PtrPtr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr<T>(PtrPtrPtr ptr) => Unsafe.As<PtrPtrPtr, PtrPtr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Ptr(PtrPtr<T> ptr) => Unsafe.As<PtrPtr<T>, Ptr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr(PtrPtr<T> ptr) => Unsafe.As<PtrPtr<T>, PtrPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr(PtrPtr<T> ptr) => Unsafe.As<PtrPtr<T>, PtrPtrPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr<T>(IntPtr intPtr) => Unsafe.As<IntPtr, PtrPtr<T>>(ref intPtr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator IntPtr(PtrPtr<T> ptr) => Unsafe.As<PtrPtr<T>, IntPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr<T>(UIntPtr intPtr) => Unsafe.As<UIntPtr, PtrPtr<T>>(ref intPtr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator UIntPtr(PtrPtr<T> ptr) => Unsafe.As<PtrPtr<T>, UIntPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator T*(PtrPtr<T> ptr) => (T*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator T**(PtrPtr<T> ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator T***(PtrPtr<T> ptr) => (T***)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void*(PtrPtr<T> ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void**(PtrPtr<T> ptr) => (void**)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void***(PtrPtr<T> ptr) => (void***)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PtrPtr<T> ptr1, PtrPtr<T> ptr2) => ptr1.p == ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PtrPtr<T> ptr1, PtrPtr<T> ptr2) => ptr1.p != ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PtrPtr<T> ptr1, PtrPtr<T> ptr2) => ptr1.p > ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PtrPtr<T> ptr1, PtrPtr<T> ptr2) => ptr1.p < ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PtrPtr<T> ptr1, PtrPtr<T> ptr2) => ptr1.p >= ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PtrPtr<T> ptr1, PtrPtr<T> ptr2) => ptr1.p <= ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator +(PtrPtr<T> ptr, int count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator +(int count, PtrPtr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator +(PtrPtr<T> ptr, long count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator +(long count, PtrPtr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator +(PtrPtr<T> ptr, nint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator +(nint count, PtrPtr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator +(PtrPtr<T> ptr, uint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator +(uint count, PtrPtr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator +(PtrPtr<T> ptr, ulong count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator +(ulong count, PtrPtr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator +(PtrPtr<T> ptr, nuint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator +(nuint count, PtrPtr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator -(PtrPtr<T> ptr, int count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator -(PtrPtr<T> ptr, long count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator -(PtrPtr<T> ptr, nint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator -(PtrPtr<T> ptr, uint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator -(PtrPtr<T> ptr, ulong count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtr<T> operator -(PtrPtr<T> ptr, nuint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long operator -(PtrPtr<T> ptr1, PtrPtr<T> ptr2) => ptr1.p - ptr2.p;
}
