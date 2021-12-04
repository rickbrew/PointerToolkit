using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace PointerToolkit
{
    public static unsafe class VolatilePtr
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void* Read(ref void* location)
        {
            return (void*)Volatile.Read(ref UnsafePtr.As<IntPtr>(ref location));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void** Read(ref void** location)
        {
            return (void**)Volatile.Read(ref UnsafePtr.As<IntPtr>(ref location));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void*** Read(ref void*** location)
        {
            return (void***)Volatile.Read(ref UnsafePtr.As<IntPtr>(ref location));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T* Read<T>(ref T* location)
            where T : unmanaged
        {
            return (T*)Volatile.Read(ref UnsafePtr.As<T, IntPtr>(ref location));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T** Read<T>(ref T** location)
        where T : unmanaged
        {
            return (T**)Volatile.Read(ref UnsafePtr.As<T, IntPtr>(ref location));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T*** Read<T>(ref T*** location)
            where T : unmanaged
        {
            return (T***)Volatile.Read(ref UnsafePtr.As<T, IntPtr>(ref location));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(ref void* location, void* value)
        {
            Volatile.Write(ref UnsafePtr.As<IntPtr>(ref location), (IntPtr)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(ref void** location, void** value)
        {
            Volatile.Write(ref UnsafePtr.As<IntPtr>(ref location), (IntPtr)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(ref void*** location, void*** value)
        {
            Volatile.Write(ref UnsafePtr.As<IntPtr>(ref location), (IntPtr)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<T>(ref T* location, T* value)
            where T : unmanaged
        {
            Volatile.Write(ref UnsafePtr.As<T, IntPtr>(ref location), (IntPtr)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<T>(ref T** location, T** value)
        where T : unmanaged
        {
            Volatile.Write(ref UnsafePtr.As<T, IntPtr>(ref location), (IntPtr)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<T>(ref T*** location, T*** value)
            where T : unmanaged
        {
            Volatile.Write(ref UnsafePtr.As<T, IntPtr>(ref location), (IntPtr)value);
        }
    }
}
