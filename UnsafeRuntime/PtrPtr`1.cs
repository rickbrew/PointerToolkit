using System;

namespace UnsafeRuntime;

public unsafe struct PtrPtr<T>
    : IEquatable<PtrPtr<T>>
      where T : unmanaged
{
    private T** p;

    private PtrPtr(T** p) => this.p = p;

    public override readonly bool Equals(object? other) => (other is PtrPtr<T> p) && (this.p == p.p);

    public readonly bool Equals(PtrPtr<T> other) => this.p == other.p;

    public static bool operator ==(PtrPtr<T> ptr1, PtrPtr<T> ptr2) => ptr1.p == ptr2.p;
    public static bool operator !=(PtrPtr<T> ptr1, PtrPtr<T> ptr2) => ptr1.p != ptr2.p;

    public override int GetHashCode()
    {
        return UnsafePtr.As<T, IntPtr>(ref this.p).GetHashCode();
    }

    public static implicit operator PtrPtr<T>(T** p) => UnsafePtr.As<T, PtrPtr<T>>(ref p);
    public static implicit operator PtrPtr(PtrPtr<T> ptr) => (void**)ptr.p;

    public static implicit operator T**(PtrPtr<T> ptr) => ptr.p;
    public static implicit operator void**(PtrPtr<T> ptr) => (void**)ptr.p;
}
