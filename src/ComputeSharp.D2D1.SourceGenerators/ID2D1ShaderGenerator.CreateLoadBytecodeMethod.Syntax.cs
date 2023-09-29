using System.Linq;
using ComputeSharp.D2D1.SourceGenerators.Models;
using ComputeSharp.SourceGeneration.Helpers;
using Microsoft.CodeAnalysis;

namespace ComputeSharp.D2D1.SourceGenerators;

/// <inheritdoc/>
partial class ID2D1ShaderGenerator
{
    /// <inheritdoc/>
    partial class LoadBytecode
    {
        /// <summary>
        /// Writes the <c>ShaderProfile</c> property.
        /// </summary>
        /// <param name="info">The input <see cref="D2D1ShaderInfo"/> instance with gathered shader info.</param>
        /// <param name="writer">The <see cref="IndentedTextWriter"/> instance to write into.</param>
        public static void WriteShaderProfileSyntax(D2D1ShaderInfo info, IndentedTextWriter writer)
        {
            writer.WriteLine($"readonly ComputeSharp.D2D1.D2D1ShaderProfile global::ComputeSharp.D2D1.__Internals.ID2D1Shader.ShaderProfile => global::ComputeSharp.D2D1.D2D1ShaderProfile.{info.HlslInfoKey.EffectiveShaderProfile};");
        }

        /// <summary>
        /// Writes the <c>CompileOptions</c> property.
        /// </summary>
        /// <param name="info">The input <see cref="D2D1ShaderInfo"/> instance with gathered shader info.</param>
        /// <param name="writer">The <see cref="IndentedTextWriter"/> instance to write into.</param>
        public static void WriteCompileOptionsSyntax(D2D1ShaderInfo info, IndentedTextWriter writer)
        {
            // Get a formatted representation of the compile options being used
            string compileOptionsExpression =
                info.HlslInfoKey.EffectiveCompileOptions
                .ToString()
                .Split(',')
                .Select(static name => $"global::ComputeSharp.D2D1.D2D1CompileOptions.{name.Trim()}")
                .Aggregate("", static (left, right) => left.Length > 0 ? $"{left} | {right}" : right);

            writer.Write($"readonly ComputeSharp.D2D1.D2D1CompileOptions global::ComputeSharp.D2D1.__Internals.ID2D1Shader.CompileOptions => {compileOptionsExpression};");
        }

        /// <summary>
        /// Writes the <c>HlslBytecode</c> property.
        /// </summary>
        /// <param name="info">The input <see cref="D2D1ShaderInfo"/> instance with gathered shader info.</param>
        /// <param name="writer">The <see cref="IndentedTextWriter"/> instance to write into.</param>
        public static void WriteHlslBytecodeSyntax(D2D1ShaderInfo info, IndentedTextWriter writer)
        {
            writer.WriteLine("readonly global::System.ReadOnlyMemory<global::ComputeSharp.D2D1.Interop.D2D1ResourceTextureDescription> global::ComputeSharp.D2D1.__Internals.ID2D1Shader.ResourceTextureDescriptions => ");

            // If there is no bytecode, just return a default expression.
            // Otherwise, return the memory manager backed memory instance.
            if (info.HlslInfo is not HlslBytecodeInfo.Success)
            {
                writer.WriteLine("default;");
            }
            else
            {
                writer.WriteLine("HlslBytecodeMemoryManager.Instance.Memory;");
            }
        }

        /// <summary>
        /// Registers a callback to generate an additional type, if needed.
        /// </summary>
        /// <param name="info">The input <see cref="D2D1ShaderInfo"/> instance with gathered shader info.</param>
        /// <param name="callbacks">The registered callbacks to generate additional types.</param>
        public static void RegisterAdditionalTypeSyntax(D2D1ShaderInfo info, ImmutableArrayBuilder<IndentedTextWriter.Callback<D2D1ShaderInfo>> callbacks)
        {
            // If there is no bytecode, no memory manager is needed
            if (info.HlslInfo is not HlslBytecodeInfo.Success)
            {
                return;
            }

            // Declare the HlslBytecodeMemoryManager custom memory manager type
            static void Callback(D2D1ShaderInfo info, IndentedTextWriter writer)
            {
                writer.WriteLine($$"""/// <summary>""");
                writer.WriteLine($$"""<see cref="global::System.Buffers.MemoryManager{T}"/> implementation to get the HLSL bytecode.""");
                writer.WriteLine($$"""/// </summary>""");
                writer.WriteLine($$"""[global::System.CodeDom.Compiler.GeneratedCode("{{typeof(ID2D1ShaderGenerator).FullName}}", "{{typeof(ID2D1ShaderGenerator).Assembly.GetName().Version}}")]""");
                writer.WriteLine($$"""[global::System.Diagnostics.DebuggerNonUserCode]""");
                writer.WriteLine($$"""[global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]""");
                writer.WriteLine($$"""file sealed class HlslBytecodeMemoryManager : global::System.Buffers.MemoryManager<byte>""");

                using (writer.WriteBlock())
                {
                    // Static singleton instance (to avoid the static constructor, just like with the input types)
                    writer.WriteLine($$"""/// <summary>The singleton <see cref="HlslBytecodeMemoryManager"/> instance to use.</summary>""");
                    writer.WriteLine($$"""public static readonly HlslBytecodeMemoryManager Instance = new();""");

                    // RVA field (with the compiled HLSL bytecode, on a single line)
                    writer.WriteLine();
                    writer.WriteLine("/// <summary>The RVA data with the HLSL bytecode.</summary>");
                    writer.Write("private static global::System.ReadOnlySpan<byte> Data => new[] { ");

                    SyntaxFormattingHelper.WriteByteArrayInitializationExpressions(((HlslBytecodeInfo.Success)info.HlslInfo).Bytecode.AsSpan(), writer);

                    writer.WriteLine(" };");

                    // Add the remaining members for the memory manager
                    writer.WriteLine("""
                        /// <inheritdoc/>
                        public override unsafe global::System.Span<byte> GetSpan
                        {
                            return new(global::System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::System.Runtime.InteropServices.MemoryMarshal(Data)), Data.Length);
                        }

                        /// <inheritdoc/>
                        public override global::System.Memory<byte> Memory
                        {
                            [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
                            get => CreateMemory(Data.Length);
                        }

                        /// <inheritdoc/>
                        public override unsafe global::System.Buffers.MemoryHandle Pin(int elementIndex)
                        {
                            return new(Unsafe.AsPointer(ref Unsafe.AsRef(in Data[elementIndex])), pinnable: this);
                        }

                        /// <inheritdoc/>
                        public override void Unpin()
                        {
                        }

                        /// <inheritdoc/>
                        protected override void Dispose(bool disposing)
                        {
                        }
                        """, isMultiline: true);
                }
            }

            callbacks.Add(Callback);
        }
    }
}