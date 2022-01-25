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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T** Get() => this.p;

    public ref T* Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref *this.p;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator PtrPtr<T>(T** p) => UnsafePtr.As<T, PtrPtr<T>>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator PtrPtr(PtrPtr<T> ptr) => (void**)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator T**(PtrPtr<T> ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void**(PtrPtr<T> ptr) => (void**)ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(PtrPtr<T> other) => ((IntPtr)this.p).CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals(object? other) => (other is PtrPtr<T> p) && (this.p == p.p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(PtrPtr<T> other) => this.p == other.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PtrPtr<T> ptr1, PtrPtr<T> ptr2) => ptr1.p == ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PtrPtr<T> ptr1, PtrPtr<T> ptr2) => ptr1.p != ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => ((IntPtr)this.p).GetHashCode();
}
