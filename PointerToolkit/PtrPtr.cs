using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public unsafe struct PtrPtr
    : IEquatable<PtrPtr>,
      IComparable<PtrPtr>
{
    private void** p;

    private PtrPtr(void** p) => this.p = p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void** Get() => this.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator PtrPtr(void** p) => UnsafePtr.As<PtrPtr>(ref p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator void**(PtrPtr ptr) => ptr.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(PtrPtr other) => ((IntPtr)this.p).CompareTo(other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals(object? other) => (other is PtrPtr p) && (this.p == p.p);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(PtrPtr other) => this.p == other.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(PtrPtr ptr1, PtrPtr ptr2) => ptr1.p == ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(PtrPtr ptr1, PtrPtr ptr2) => ptr1.p != ptr2.p;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => ((IntPtr)this.p).GetHashCode();
}
