using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public static class Program
{
    public static int Main(string[] args)
    {
        try
        {
            MainImpl(args[0]);
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("*** Unhandled Exception: " + ex.ToString());
            return ex.HResult;
        }
    }

    public static void MainImpl(string outputDirPath)
    {
        Console.WriteLine($"PointerToolkit generator, outputting to {outputDirPath}");
        
        // This is 1 plus the maximum number of base COM interfaces needed to support TerraFX.Interop.Windows
        const int maxBaseCount = 12;

        // CastPtr`N.Generated.cs
        for (int baseCount = 0; baseCount <= maxBaseCount; ++baseCount)
        {
            GenerateFile(
                Path.Combine(outputDirPath, $"CastPtr`{baseCount + 1}.Generated.cs"),
                delegate (TextWriter writer)
                {
                    writer.WriteLine("#nullable enable");
                    writer.WriteLine();
                    writer.WriteLine("using System;");
                    writer.WriteLine("using System.Runtime.CompilerServices;");
                    writer.WriteLine();
                    writer.WriteLine("namespace PointerToolkit;");

                    string typeList;
                    {
                        StringBuilder builder = new();
                        builder.Append("T");
                        for (int i = 1; i <= baseCount; ++i)
                        {
                            builder.Append($", TBase{i}");
                        }

                        typeList = builder.ToString();
                    }

                    writer.WriteLine();
                    writer.WriteLine($"public unsafe readonly ref struct CastPtr<{typeList}>");
                    writer.WriteLine("    where T : unmanaged");
                    for (int i = 1; i <= baseCount; ++i)
                    {
                        writer.WriteLine($"    where TBase{i} : unmanaged");
                    }
                    writer.WriteLine("{");
                    writer.WriteLine("    private readonly T* p;");
                    writer.WriteLine();
                    writer.WriteLine("    [MethodImpl(MethodImplOptions.AggressiveInlining)]");
                    writer.WriteLine("    private CastPtr(T* p) => this.p = p;");

                    if (baseCount == 0)
                    {
                        writer.WriteLine();
                        writer.WriteLine("    [MethodImpl(MethodImplOptions.AggressiveInlining)]");
                        writer.WriteLine($"    public static implicit operator CastPtr<T>(T* p) => *(CastPtr<T>*)&p;");
                    }

                    writer.WriteLine();
                    writer.WriteLine("    [MethodImpl(MethodImplOptions.AggressiveInlining)]");
                    writer.WriteLine($"    public static implicit operator T*(CastPtr<{typeList}> ptr) => ptr.p;");
                    for (int i = 1; i <= baseCount; ++i)
                    {
                        writer.WriteLine();
                        writer.WriteLine("    [MethodImpl(MethodImplOptions.AggressiveInlining)]");
                        writer.WriteLine($"    public static implicit operator TBase{i}*(CastPtr<{typeList}> ptr) => (TBase{i}*)ptr.p;");
                    }
                    writer.WriteLine();
                    writer.WriteLine("    [MethodImpl(MethodImplOptions.AggressiveInlining)]");
                    writer.WriteLine($"    public static implicit operator void*(CastPtr<{typeList}> ptr) => ptr.p;");

                    // Casts to Ptr<T>
                    /*
                    writer.WriteLine();
                    writer.WriteLine("    [MethodImpl(MethodImplOptions.AggressiveInlining)]");
                    writer.WriteLine($"    public static implicit operator Ptr<T>(CastPtr<{typeList}> ptr) => ptr.p;");
                    for (int i = 1; i <= baseCount; ++i)
                    {
                        writer.WriteLine();
                        writer.WriteLine("    [MethodImpl(MethodImplOptions.AggressiveInlining)]");
                        writer.WriteLine($"    public static implicit operator Ptr<TBase{i}>(CastPtr<{typeList}> ptr) => (TBase{i}*)ptr.p;");
                    }
                    writer.WriteLine();
                    writer.WriteLine("    [MethodImpl(MethodImplOptions.AggressiveInlining)]");
                    writer.WriteLine($"    public static implicit operator Ptr(CastPtr<{typeList}> ptr) => ptr.p;");
                    */

                    writer.WriteLine("}");
                });
        }
    }

    public static void GenerateFile(string filePath, Action<TextWriter> writeCallback)
    {
        Console.Write($"{filePath} ... ");

        using MemoryStream stream = new MemoryStream();
        using (TextWriter writer = new StreamWriter(stream, Encoding.UTF8, leaveOpen: true))
        {
            writeCallback(writer);
        }

        byte[] newBytes = stream.GetBuffer();
        Array.Resize(ref newBytes, checked((int)stream.Length));

        if (File.Exists(filePath))
        {
            byte[] oldBytes = File.ReadAllBytes(filePath);

            if (oldBytes.SequenceEqual(newBytes))
            {
                // don't write anything
                Console.WriteLine("unchanged");
                return;
            }
        }

        File.WriteAllBytes(filePath, newBytes);
        Console.WriteLine();
    }
}