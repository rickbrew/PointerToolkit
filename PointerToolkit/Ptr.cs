using System;

namespace UnsafeRuntime;

public unsafe struct Ptr
    : IEquatable<Ptr>
{
    private void* p;

    private Ptr(void* p) => this.p = p;

    public override readonly bool Equals(object? other) => (other is Ptr p) && (this.p == p.p);

    public readonly bool Equals(Ptr other) => this.p == other.p;

    public static bool operator ==(Ptr ptr1, Ptr ptr2) => ptr1.p == ptr2.p;
    public static bool operator !=(Ptr ptr1, Ptr ptr2) => ptr1.p != ptr2.p;

    public override int GetHashCode()
    {
        return UnsafePtr.As<IntPtr>(ref this.p).GetHashCode();
    }

    public static implicit operator Ptr(void* p) => UnsafePtr.As<Ptr>(ref p);

    public static implicit operator void*(Ptr ptr) => ptr.p;
}
