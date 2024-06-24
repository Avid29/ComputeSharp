using ComputeSharp.Graphics.Resources.Enums;
using ComputeSharp.Resources;
using ComputeSharp.Resources.Debug;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ComputeSharp;

/// <summary>
/// A <see langword="class"/> representing a typed append buffer stored on GPU memory.
/// </summary>
/// <typeparam name="T">The type of items stored on the buffer.</typeparam>
[DebuggerTypeProxy(typeof(BufferDebugView<>))]
[DebuggerDisplay("{ToString(),raw}")]
public sealed class AppendBuffer<T> : StructuredBuffer<T>
    where T : unmanaged
{
    /// <summary>
    /// Creates a new <see cref="AppendBuffer{T}"/> instance with the specified parameters.
    /// </summary>
    /// <param name="device">The <see cref="GraphicsDevice"/> associated with the current instance.</param>
    /// <param name="length">The number of items to store in the current buffer.</param>
    /// <param name="allocationMode">The allocation mode to use for the new resource.</param>
    [RequiresUnreferencedCode("This method reads type info of all fields of the resource element type (recursively).")]
    internal AppendBuffer(GraphicsDevice device, int length, AllocationMode allocationMode)
        : base(device, length, ResourceType.ReadWrite, allocationMode)
    {
    }

    /// <summary>
    /// Appends a <typeparamref name="T"/> value to the end of the buffer
    /// </summary>
    /// <param name="item">The value to append.</param>
    /// <remarks>This API can only be used from a compute shader, and will always throw if used anywhere else.</remarks>
    public void Append(T item)
    {
        throw new InvalidExecutionContextException($"{typeof(AppendBuffer<T>)}.Append({typeof(T)})");
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"ComputeSharp.AppendBuffer<{typeof(T)}>[{Length}]";
    }
}
