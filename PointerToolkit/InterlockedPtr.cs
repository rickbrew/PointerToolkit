using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace PointerToolkit
{
    public static unsafe class InterlockedPtr
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void* CompareExchange(ref void* location1, void* value, void* comparand)
        {
            return (void*)Interlocked.CompareExchange(ref UnsafePtr.As<IntPtr>(ref location1), (IntPtr)value, (IntPtr)comparand);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void** CompareExchange(ref void** location1, void** value, void** comparand)
        {
            return (void**)Interlocked.CompareExchange(ref UnsafePtr.As<IntPtr>(ref location1), (IntPtr)value, (IntPtr)comparand);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void*** CompareExchange(ref void*** location1, void*** value, void*** comparand)
        {
            return (void***)Interlocked.CompareExchange(ref UnsafePtr.As<IntPtr>(ref location1), (IntPtr)value, (IntPtr)comparand);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T* CompareExchange<T>(ref T* location1, T* value, T* comparand)
            where T : unmanaged
        {
            return (T*)Interlocked.CompareExchange(ref UnsafePtr.As<T, IntPtr>(ref location1), (IntPtr)value, (IntPtr)comparand);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T** CompareExchange<T>(ref T** location1, T** value, T** comparand)
            where T : unmanaged
        {
            return (T**)Interlocked.CompareExchange(ref UnsafePtr.As<T, IntPtr>(ref location1), (IntPtr)value, (IntPtr)comparand);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T*** CompareExchange<T>(ref T*** location1, T*** value, T*** comparand)
            where T : unmanaged
        {
            return (T***)Interlocked.CompareExchange(ref UnsafePtr.As<T, IntPtr>(ref location1), (IntPtr)value, (IntPtr)comparand);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void* Exchange(ref void* location1, void* value)
        {
            return (void*)Interlocked.Exchange(ref UnsafePtr.As<IntPtr>(ref location1), (IntPtr)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void** Exchange(ref void** location1, void** value)
        {
            return (void**)Interlocked.Exchange(ref UnsafePtr.As<IntPtr>(ref location1), (IntPtr)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void*** Exchange(ref void*** location1, void*** value)
        {
            return (void***)Interlocked.Exchange(ref UnsafePtr.As<IntPtr>(ref location1), (IntPtr)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T* Exchange<T>(ref T* location1, T* value)
            where T : unmanaged
        {
            return (T*)Interlocked.Exchange(ref UnsafePtr.As<T, IntPtr>(ref location1), (IntPtr)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T** Exchange<T>(ref T** location1, T** value)
            where T : unmanaged
        {
            return (T**)Interlocked.Exchange(ref UnsafePtr.As<T, IntPtr>(ref location1), (IntPtr)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T*** Exchange<T>(ref T*** location1, T*** value)
            where T : unmanaged
        {
            return (T***)Interlocked.Exchange(ref UnsafePtr.As<T, IntPtr>(ref location1), (IntPtr)value);
        }
    }
}
