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
    public override int GetHashCode() => ((IntPtr)this.p).GetHashCode();
}
