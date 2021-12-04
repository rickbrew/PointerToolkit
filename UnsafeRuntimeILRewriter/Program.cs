using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;
using System;
using System.IO;

public static class Program
{
    public static int Main(string[] args)
    {
        try
        {
            MainImpl(args);
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine($"*** Unhandled Exception: {ex}");
            return ex.HResult;
        }
    }

    private static void MainImpl(string[] args)
    {
        string assemblyPath = args[0];

        Console.WriteLine($"Reading {assemblyPath} ...");
        AssemblyDefinition assemblyDef = AssemblyDefinition.ReadAssembly(assemblyPath);

        ModuleDefinition module = assemblyDef.MainModule;

        const string className = "UnsafeRuntime.UnsafePtr";
        TypeDefinition unsafeHelpersTypeDef = module.GetType(className);

        // Every method needs the same IL code, so we'll just rewrite them all to the same thing. No tagging or filtering other than the basics.
        //     ldarg.0
        //     ret
        foreach (MethodDefinition methodDef in unsafeHelpersTypeDef.Methods)
        {
            if (methodDef.IsConstructor || !methodDef.IsStatic || methodDef.Parameters.Count != 1)
            {
                continue;
            }

            Console.WriteLine($"Rewriting {className}.{methodDef.Name} ...");

            Collection<Instruction> instructions = methodDef.Body.Instructions;
            instructions.Clear();
            instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
            instructions.Add(Instruction.Create(OpCodes.Ret));
        }

        Console.WriteLine($"Saving {assemblyPath} ...");

        using (MemoryStream tempStream = new MemoryStream())
        {
            assemblyDef.Write(tempStream);
            assemblyDef.Dispose();

            using (FileStream outputStream = new FileStream(assemblyPath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
            {
                outputStream.Write(tempStream.GetBuffer(), 0, checked((int)tempStream.Position));
            }
        }
    }
}