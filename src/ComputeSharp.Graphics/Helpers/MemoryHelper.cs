﻿using System;
using System.Runtime.CompilerServices;

namespace ComputeSharp.Graphics.Helpers
{
    /// <summary>
    /// A <see langword="class"/> with some helper methods to copy data between memory areas.
    /// </summary>
    internal static class MemoryHelper
    {
        /// <summary>
        /// Copies the content of a <see cref="ReadOnlySpan{T}"/> to the area pointed by an input <see cref="IntPtr"/> value.
        /// </summary>
        /// <typeparam name="T">The type of values in the input <see cref="ReadOnlySpan{T}"/>.</typeparam>
        /// <param name="source">The source <see cref="ReadOnlySpan{T}"/> to read.</param>
        /// <param name="destination">The pointer for the destination memory area.</param>
        /// <param name="destinationOffset">The destination offset to start writing data to.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy<T>(ReadOnlySpan<T> source, void* destination, int destinationOffset)
            where T : unmanaged
        {
            source.CopyTo(new Span<T>((T*)destination + destinationOffset, source.Length));
        }

        /// <summary>
        /// Copies a memory area pointed by an <see cref="IntPtr"/> value to a target <see cref="Span{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of values to read.</typeparam>
        /// <param name="source">The <see cref="IntPtr"/> that indicates the memory area to read from.</param>
        /// <param name="sourceOffset">The source offset to start reading data from.</param>
        /// <param name="destination">The destination <see cref="Span{T}"/> to write.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Copy<T>(void* source, int sourceOffset, Span<T> destination)
            where T : unmanaged
        {
            new Span<T>((T*)source + sourceOffset, destination.Length).CopyTo(destination);
        }
    }
}
