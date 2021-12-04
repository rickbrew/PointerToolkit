using System;

namespace UnsafeRuntime
{
    public static unsafe class UnsafePtr
    {
        public static ref U As<T, U>(ref T* source)
            where T : unmanaged
            where U : unmanaged
        {
            throw null!;
        }

        public static ref U As<T, U>(ref T** source)
            where T : unmanaged
            where U : unmanaged
        {
            throw null!;
        }

        public static ref U As<T, U>(ref T*** source)
            where T : unmanaged
            where U : unmanaged
        {
            throw null!;
        }

        public static ref T As<T>(ref void* source)
            where T : unmanaged
        {
            throw null!;
        }

        public static ref T As<T>(ref void** source)
            where T : unmanaged
        {
            throw null!;
        }

        public static ref T As<T>(ref void*** source)
            where T : unmanaged
        {
            throw null!;
        }

        public static ref U* AsPointer<T, U>(ref T source)
            where T : unmanaged
            where U : unmanaged
        {
            throw null!;
        }

        public static ref U** AsPointer2<T, U>(ref T source)
            where T : unmanaged
            where U : unmanaged
        {
            throw null!;
        }

        public static ref U*** AsPointer3<T, U>(ref T source)
            where T : unmanaged
            where U : unmanaged
        {
            throw null!;
        }
    }
}
