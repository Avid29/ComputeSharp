using System;
using System.Collections.Generic;
using ComputeSharp.D2D1.Helpers;

namespace ComputeSharp.D2D1.Uwp.Buffers;

/// <summary>
/// Shared helpers for all types implementing <see cref="IFixedCountList{T}"/>.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
internal static class FixedCountList<T>
{
    /// <summary>
    /// Copies the entire <see cref="IFixedCountList{T}"/> instance to a target array range.
    /// </summary>
    /// <param name="list">The input <see cref="IFixedCountList{T}"/> instance.</param>
    /// <param name="array">The array to copy elements to.</param>
    /// <param name="index">The initial index within <paramref name="array"/>.</param>
    public static void CopyTo(IFixedCountList<T> list, T[] array, int index)
    {
        if (array is null)
        {
            ThrowHelper.ThrowArgumentNullException(nameof(array), "The input array cannot be null.");
        }

        Span<T> span = array.AsSpan(index);

        if (list.Indices.Length > span.Length)
        {
            ThrowHelper.ThrowArgumentException(nameof(array), "The destination array range is smaller than the number of source items.");
        }

        foreach (int i in list.Indices)
        {
            span[i] = list[i];
        }
    }

    /// <summary>
    /// Copies the entire <see cref="IFixedCountList{T}"/> instance to a target array range.
    /// </summary>
    /// <param name="list">The input <see cref="IFixedCountList{T}"/> instance.</param>
    /// <param name="array">The array to copy elements to.</param>
    /// <param name="index">The initial index within <paramref name="array"/>.</param>
    public static void CopyTo(IFixedCountList<T> list, Array array, int index)
    {
        if (array is null)
        {
            ThrowHelper.ThrowArgumentNullException(nameof(array), "The input array cannot be null.");
        }

        if ((uint)index >= array.Length)
        {
            ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index), "The starting array index is out of range.");
        }

        int remainingLength = array.Length - index;

        if (list.Indices.Length > remainingLength)
        {
            ThrowHelper.ThrowArgumentException(nameof(array), "The destination array range is smaller than the number of source items.");
        }

        foreach (int i in list.Indices)
        {
            array.SetValue(list[i], i);
        }
    }

    /// <summary>
    /// Creates an <see cref="IEnumerable{T}"/> for an input <see cref="IFixedCountList{T}"/> instance.
    /// </summary>
    /// <param name="list">The input <see cref="IFixedCountList{T}"/> instance.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> instance for <paramref name="list"/>.</returns>
    public static IEnumerator<T> GetEnumerator(IFixedCountList<T> list)
    {
        foreach (int i in list.Indices)
        {
            yield return list[i];
        }
    }

    /// <summary>
    /// Searches for the specified object and returns the zero-based index of the first occurrence
    /// within the range of elements in a given <see cref="IFixedCountList{T}"/> instance.
    /// </summary>
    /// <param name="list">The input <see cref="IFixedCountList{T}"/> instance.</param>
    /// <param name="value">
    /// The object to locate in <paramref name="list"/>. The value can be <see langword="null"/> for reference types.
    /// </param>
    /// <returns>
    /// The zero-based index of the first occurrence of item within <paramref name="list"/>, otherwise -1.
    /// </returns>
    public static int IndexOf(IFixedCountList<T> list, T value)
    {
        foreach (int i in list.Indices)
        {
            if (EqualityComparer<T>.Default.Equals(list[i], value))
            {
                return i;
            }
        }

        return -1;
    }
}