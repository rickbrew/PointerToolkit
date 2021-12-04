using System;

namespace PointerToolkit;

public unsafe struct Ptr<T>
    : IEquatable<Ptr<T>>
      where T : unmanaged
{
    private T* p;

    private Ptr(T* p) => this.p = p;

    public override readonly bool Equals(object? other) => (other is Ptr<T> p) && (this.p == p.p);

    public readonly bool Equals(Ptr<T> other) => this.p == other.p;

    public static bool operator ==(Ptr<T> ptr1, Ptr<T> ptr2) => ptr1.p == ptr2.p;
    public static bool operator !=(Ptr<T> ptr1, Ptr<T> ptr2) => ptr1.p != ptr2.p;

    public override int GetHashCode()
    {
        return UnsafePtr.As<T, IntPtr>(ref this.p).GetHashCode();
    }

    public static implicit operator Ptr<T>(T* p) => UnsafePtr.As<T, Ptr<T>>(ref p);
    public static implicit operator Ptr(Ptr<T> ptr) => ptr.p;

    public static implicit operator T*(Ptr<T> ptr) => ptr.p;
    public static implicit operator void*(Ptr<T> ptr) => ptr.p;
}
