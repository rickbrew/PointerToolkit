using System;

namespace PointerToolkit;

public unsafe struct PtrPtrPtr<T>
    : IEquatable<PtrPtrPtr<T>>
      where T : unmanaged
{
    private T** p;

    private PtrPtrPtr(T** p) => this.p = p;

    public override readonly bool Equals(object? other) => (other is PtrPtrPtr<T> p) && (this.p == p.p);

    public readonly bool Equals(PtrPtrPtr<T> other) => this.p == other.p;

    public static bool operator ==(PtrPtrPtr<T> ptr1, PtrPtrPtr<T> ptr3) => ptr1.p == ptr3.p;
    public static bool operator !=(PtrPtrPtr<T> ptr1, PtrPtrPtr<T> ptr3) => ptr1.p != ptr3.p;

    public override int GetHashCode()
    {
        return UnsafePtr.As<T, IntPtr>(ref this.p).GetHashCode();
    }

    public static implicit operator PtrPtrPtr<T>(T** p) => UnsafePtr.As<T, PtrPtrPtr<T>>(ref p);
    public static implicit operator PtrPtrPtr(PtrPtrPtr<T> ptr) => (void**)ptr.p;

    public static implicit operator T**(PtrPtrPtr<T> ptr) => ptr.p;
    public static implicit operator void**(PtrPtrPtr<T> ptr) => (void**)ptr.p;
}
