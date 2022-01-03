using InlineIL;
using System;
using System.Runtime.CompilerServices;

namespace PointerToolkit;

public static unsafe class UnsafePtr
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T* AddByteOffset<T>(T* p, nuint offset)
        where T : unmanaged
    {
        return (T*)((byte*)p + offset);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T* AddByteOffset<T>(T* p, nint offset)
        where T : unmanaged
    {
        return (T*)((byte*)p + offset);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T* SubtractByteOffset<T>(T* p, nuint offset)
        where T : unmanaged
    {
        return unchecked((T*)((byte*)p - offset));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T* SubtractByteOffset<T>(T* p, nint offset)
        where T : unmanaged
    {
        return unchecked((T*)((byte*)p - offset));
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
    public static T* AsPointer<T>(ref T source)
        where T : unmanaged
    {
        IL.Emit.Ldarg_0();
        IL.Emit.Ret();
        throw IL.Unreachable();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T** AsPointer<T>(ref T* source)
        where T : unmanaged
    {
        IL.Emit.Ldarg_0();
        IL.Emit.Ret();
        throw IL.Unreachable();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T*** AsPointer<T>(ref T** source)
        where T : unmanaged
    {
        IL.Emit.Ldarg_0();
        IL.Emit.Ret();
        throw IL.Unreachable();
    }
}
