using InlineIL;
using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit
{
    public static unsafe class UnsafePtr
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref U As<T, U>(ref T* source)
            where T : unmanaged
            where U : unmanaged
        {
            IL.Emit.Ldarg_0();
            IL.Emit.Ret();
            throw IL.Unreachable();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref U As<T, U>(ref T** source)
            where T : unmanaged
            where U : unmanaged
        {
            IL.Emit.Ldarg_0();
            IL.Emit.Ret();
            throw IL.Unreachable();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref U As<T, U>(ref T*** source)
            where T : unmanaged
            where U : unmanaged
        {
            IL.Emit.Ldarg_0();
            IL.Emit.Ret();
            throw IL.Unreachable();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T As<T>(ref void* source)
            where T : unmanaged
        {
            IL.Emit.Ldarg_0();
            IL.Emit.Ret();
            throw IL.Unreachable();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T As<T>(ref void** source)
            where T : unmanaged
        {
            IL.Emit.Ldarg_0();
            IL.Emit.Ret();
            throw IL.Unreachable();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T As<T>(ref void*** source)
            where T : unmanaged
        {
            IL.Emit.Ldarg_0();
            IL.Emit.Ret();
            throw IL.Unreachable();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref U* AsPointer<T, U>(ref T source)
            where T : unmanaged
            where U : unmanaged
        {
            IL.Emit.Ldarg_0();
            IL.Emit.Ret();
            throw IL.Unreachable();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref U** AsPointer2<T, U>(ref T source)
            where T : unmanaged
            where U : unmanaged
        {
            IL.Emit.Ldarg_0();
            IL.Emit.Ret();
            throw IL.Unreachable();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref U*** AsPointer3<T, U>(ref T source)
            where T : unmanaged
            where U : unmanaged
        {
            IL.Emit.Ldarg_0();
            IL.Emit.Ret();
            throw IL.Unreachable();
        }
    }
}
