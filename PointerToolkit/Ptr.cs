using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public unsafe struct Ptr
    : IEquatable<Ptr>,
      IComparable<Ptr>
{
    private void* p;

    private Ptr(void* p) => this.p = p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* Get() => this.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Ptr(void* p) => UnsafePtr.As<Ptr>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void*(Ptr ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(Ptr other) => ((IntPtr)this.p).CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals(object? other) => (other is Ptr p) && (this.p == p.p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Ptr other) => this.p == other.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Ptr ptr1, Ptr ptr2) => ptr1.p == ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Ptr ptr1, Ptr ptr2) => ptr1.p != ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => ((IntPtr)this.p).GetHashCode();
}
