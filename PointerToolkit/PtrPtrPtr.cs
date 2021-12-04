using System;

namespace PointerToolkit;

public unsafe struct PtrPtrPtr
    : IEquatable<PtrPtrPtr>
{
    private void** p;

    private PtrPtrPtr(void** p) => this.p = p;

    public override readonly bool Equals(object? other) => (other is PtrPtrPtr p) && (this.p == p.p);

    public readonly bool Equals(PtrPtrPtr other) => this.p == other.p;

    public static bool operator ==(PtrPtrPtr ptr1, PtrPtrPtr ptr3) => ptr1.p == ptr3.p;
    public static bool operator !=(PtrPtrPtr ptr1, PtrPtrPtr ptr3) => ptr1.p != ptr3.p;

    public override int GetHashCode()
    {
        return ((IntPtr)this.p).GetHashCode();
    }

    public static implicit operator PtrPtrPtr(void** p) => UnsafePtr.As<PtrPtrPtr>(ref p);

    public static implicit operator void**(PtrPtrPtr ptr) => ptr.p;
}
