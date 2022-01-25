using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public unsafe readonly struct Ptr<T>
    : IEquatable<Ptr<T>>,
      IComparable<Ptr<T>>
      where T : unmanaged
{
    private readonly T* p;

    private Ptr(T* p) => this.p = p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T* Get() => this.p;

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
    public static implicit operator Ptr<T>(T* p) => UnsafePtr.As<T, Ptr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Ptr(Ptr<T> ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator T*(Ptr<T> ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void*(Ptr<T> ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(Ptr<T> other) => ((IntPtr)this.p).CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals(object? other) => (other is Ptr<T> p) && (this.p == p.p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Ptr<T> other) => this.p == other.p;

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
    public override int GetHashCode() => ((IntPtr)this.p).GetHashCode();

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
