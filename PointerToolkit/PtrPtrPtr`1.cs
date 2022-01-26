using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public unsafe readonly struct PtrPtrPtr<T>
    : IEquatable<PtrPtrPtr<T>>,
      IComparable<PtrPtrPtr<T>>
      where T : unmanaged
{
    private readonly T*** p;

    private PtrPtrPtr(T*** p) => this.p = p;

    public ref PtrPtr<T> Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<T, PtrPtr<T>>(ref *this.p);
    }

    public ref PtrPtr<T> this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<T, PtrPtr<T>>(ref *(this.p + index));
    }

    public ref PtrPtr<T> this[long index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<T, PtrPtr<T>>(ref *(this.p + index));
    }

    public ref PtrPtr<T> this[nint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<T, PtrPtr<T>>(ref *(this.p + index));
    }

    public ref PtrPtr<T> this[uint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<T, PtrPtr<T>>(ref *(this.p + index));
    }

    public ref PtrPtr<T> this[ulong index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<T, PtrPtr<T>>(ref *(this.p + index));
    }

    public ref PtrPtr<T> this[nuint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref UnsafePtr.As<T, PtrPtr<T>>(ref *(this.p + index));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(PtrPtrPtr<T> other) => ((IntPtr)this.p).CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? other) => (other is PtrPtrPtr<T> p) && (this.p == p.p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(PtrPtrPtr<T> other) => this.p == other.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T*** Get() => this.p;

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
    public static explicit operator PtrPtrPtr<T>(T* p) => UnsafePtr.As<T, PtrPtrPtr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr<T>(T** p) => UnsafePtr.As<T, PtrPtrPtr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator PtrPtrPtr<T>(T*** p) => UnsafePtr.As<T, PtrPtrPtr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr<T>(void* p) => UnsafePtr.As<PtrPtrPtr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr<T>(void** p) => UnsafePtr.As<PtrPtrPtr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr<T>(void*** p) => UnsafePtr.As<PtrPtrPtr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr<T>(Ptr<T> ptr) => Unsafe.As<Ptr<T>, PtrPtrPtr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr<T>(PtrPtr<T> ptr) => Unsafe.As<PtrPtr<T>, PtrPtrPtr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr<T>(Ptr ptr) => Unsafe.As<Ptr, PtrPtrPtr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr<T>(PtrPtr ptr) => Unsafe.As<PtrPtr, PtrPtrPtr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr<T>(PtrPtrPtr ptr) => Unsafe.As<PtrPtrPtr, PtrPtrPtr<T>>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Ptr(PtrPtrPtr<T> ptr) => Unsafe.As<PtrPtrPtr<T>, Ptr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtr(PtrPtrPtr<T> ptr) => Unsafe.As<PtrPtrPtr<T>, PtrPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr(PtrPtrPtr<T> ptr) => Unsafe.As<PtrPtrPtr<T>, PtrPtrPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr<T>(IntPtr intPtr) => Unsafe.As<IntPtr, PtrPtrPtr<T>>(ref intPtr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator IntPtr(PtrPtrPtr<T> ptr) => Unsafe.As<PtrPtrPtr<T>, IntPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator PtrPtrPtr<T>(UIntPtr intPtr) => Unsafe.As<UIntPtr, PtrPtrPtr<T>>(ref intPtr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator UIntPtr(PtrPtrPtr<T> ptr) => Unsafe.As<PtrPtrPtr<T>, UIntPtr>(ref ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator T*(PtrPtrPtr<T> ptr) => (T*)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator T**(PtrPtrPtr<T> ptr) => (T**)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator T***(PtrPtrPtr<T> ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void*(PtrPtrPtr<T> ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void**(PtrPtrPtr<T> ptr) => (void**)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void***(PtrPtrPtr<T> ptr) => (void***)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PtrPtrPtr<T> ptr1, PtrPtrPtr<T> ptr3) => ptr1.p == ptr3.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PtrPtrPtr<T> ptr1, PtrPtrPtr<T> ptr3) => ptr1.p != ptr3.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(PtrPtrPtr<T> ptr1, PtrPtrPtr<T> ptr2) => ptr1.p > ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(PtrPtrPtr<T> ptr1, PtrPtrPtr<T> ptr2) => ptr1.p < ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(PtrPtrPtr<T> ptr1, PtrPtrPtr<T> ptr2) => ptr1.p >= ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(PtrPtrPtr<T> ptr1, PtrPtrPtr<T> ptr2) => ptr1.p <= ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator +(PtrPtrPtr<T> ptr, int count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator +(int count, PtrPtrPtr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator +(PtrPtrPtr<T> ptr, long count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator +(long count, PtrPtrPtr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator +(PtrPtrPtr<T> ptr, nint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator +(nint count, PtrPtrPtr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator +(PtrPtrPtr<T> ptr, uint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator +(uint count, PtrPtrPtr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator +(PtrPtrPtr<T> ptr, ulong count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator +(ulong count, PtrPtrPtr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator +(PtrPtrPtr<T> ptr, nuint count) => ptr.p + count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator +(nuint count, PtrPtrPtr<T> ptr) => count + ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator -(PtrPtrPtr<T> ptr, int count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator -(PtrPtrPtr<T> ptr, long count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator -(PtrPtrPtr<T> ptr, nint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator -(PtrPtrPtr<T> ptr, uint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator -(PtrPtrPtr<T> ptr, ulong count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PtrPtrPtr<T> operator -(PtrPtrPtr<T> ptr, nuint count) => ptr.p - count;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long operator -(PtrPtrPtr<T> ptr1, PtrPtrPtr<T> ptr2) => ptr1.p - ptr2.p;
}
