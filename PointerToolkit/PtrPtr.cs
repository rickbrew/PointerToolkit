using System;

namespace PointerToolkit;

public unsafe struct PtrPtr
    : IEquatable<PtrPtr>
{
    private void** p;

    private PtrPtr(void** p) => this.p = p;

    public override readonly bool Equals(object? other) => (other is PtrPtr p) && (this.p == p.p);

    public readonly bool Equals(PtrPtr other) => this.p == other.p;

    public static bool operator ==(PtrPtr ptr1, PtrPtr ptr2) => ptr1.p == ptr2.p;
    public static bool operator !=(PtrPtr ptr1, PtrPtr ptr2) => ptr1.p != ptr2.p;

    public override int GetHashCode()
    {
        return UnsafePtr.As<IntPtr>(ref this.p).GetHashCode();
    }

    public static implicit operator PtrPtr(void** p) => UnsafePtr.As<PtrPtr>(ref p);

    public static implicit operator void**(PtrPtr ptr) => ptr.p;
}
