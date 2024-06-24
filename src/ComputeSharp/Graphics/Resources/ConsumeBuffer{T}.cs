using ComputeSharp.Graphics.Resources.Enums;
using ComputeSharp.Resources;
using ComputeSharp.Resources.Debug;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ComputeSharp;

/// <summary>
/// A <see langword="class"/> representing a typed consume buffer stored on GPU memory.
/// </summary>
/// <typeparam name="T">The type of items stored on the buffer.</typeparam>
[DebuggerTypeProxy(typeof(BufferDebugView<>))]
[DebuggerDisplay("{ToString(),raw}")]
public sealed class ConsumeBuffer<T> : StructuredBuffer<T>
    where T : unmanaged
{
    /// <summary>
    /// Creates a new <see cref="ConsumeBuffer{T}"/> instance with the specified parameters.
    /// </summary>
    /// <param name="device">The <see cref="GraphicsDevice"/> associated with the current instance.</param>
    /// <param name="length">The number of items to store in the current buffer.</param>
    /// <param name="allocationMode">The allocation mode to use for the new resource.</param>
    [RequiresUnreferencedCode("This method reads type info of all fields of the resource element type (recursively).")]
    internal ConsumeBuffer(GraphicsDevice device, int length, AllocationMode allocationMode)
        : base(device, length, ResourceType.ReadWrite, allocationMode)
    {
    }

    /// <summary>
    /// Removes a <typeparamref name="T"/> value from the end of the buffer
    /// </summary>
    /// <remarks>This API can only be used from a compute shader, and will always throw if used anywhere else.</remarks>
    public T Consume()
    {
        throw new InvalidExecutionContextException($"{typeof(ConsumeBuffer<T>)}.Consume({typeof(T)})");
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"ComputeSharp.ConsumeBuffer<{typeof(T)}>[{Length}]";
    }
}
