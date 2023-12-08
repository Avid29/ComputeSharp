using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputeSharp.Tests;

[TestClass]
public unsafe partial class GlobalUsingDirectivesTests
{
    [TestMethod]
    [DataRow(typeof(bool2), typeof(Bool2))]
    [DataRow(typeof(bool3), typeof(Bool3))]
    [DataRow(typeof(bool4), typeof(Bool4))]
    [DataRow(typeof(bool1x1), typeof(Bool1x1))]
    [DataRow(typeof(bool1x2), typeof(Bool1x2))]
    [DataRow(typeof(bool1x3), typeof(Bool1x3))]
    [DataRow(typeof(bool1x4), typeof(Bool1x4))]
    [DataRow(typeof(bool2x1), typeof(Bool2x1))]
    [DataRow(typeof(bool2x2), typeof(Bool2x2))]
    [DataRow(typeof(bool2x3), typeof(Bool2x3))]
    [DataRow(typeof(bool2x4), typeof(Bool2x4))]
    [DataRow(typeof(bool3x1), typeof(Bool3x1))]
    [DataRow(typeof(bool3x2), typeof(Bool3x2))]
    [DataRow(typeof(bool3x3), typeof(Bool3x3))]
    [DataRow(typeof(bool3x4), typeof(Bool3x4))]
    [DataRow(typeof(bool4x1), typeof(Bool4x1))]
    [DataRow(typeof(bool4x2), typeof(Bool4x2))]
    [DataRow(typeof(bool4x3), typeof(Bool4x3))]
    [DataRow(typeof(bool4x4), typeof(Bool4x4))]
    [DataRow(typeof(double2), typeof(Double2))]
    [DataRow(typeof(double3), typeof(Double3))]
    [DataRow(typeof(double4), typeof(Double4))]
    [DataRow(typeof(double1x1), typeof(Double1x1))]
    [DataRow(typeof(double1x2), typeof(Double1x2))]
    [DataRow(typeof(double1x3), typeof(Double1x3))]
    [DataRow(typeof(double1x4), typeof(Double1x4))]
    [DataRow(typeof(double2x1), typeof(Double2x1))]
    [DataRow(typeof(double2x2), typeof(Double2x2))]
    [DataRow(typeof(double2x3), typeof(Double2x3))]
    [DataRow(typeof(double2x4), typeof(Double2x4))]
    [DataRow(typeof(double3x1), typeof(Double3x1))]
    [DataRow(typeof(double3x2), typeof(Double3x2))]
    [DataRow(typeof(double3x3), typeof(Double3x3))]
    [DataRow(typeof(double3x4), typeof(Double3x4))]
    [DataRow(typeof(double4x1), typeof(Double4x1))]
    [DataRow(typeof(double4x2), typeof(Double4x2))]
    [DataRow(typeof(double4x3), typeof(Double4x3))]
    [DataRow(typeof(double4x4), typeof(Double4x4))]
    [DataRow(typeof(float2), typeof(Float2))]
    [DataRow(typeof(float3), typeof(Float3))]
    [DataRow(typeof(float4), typeof(Float4))]
    [DataRow(typeof(float1x1), typeof(Float1x1))]
    [DataRow(typeof(float1x2), typeof(Float1x2))]
    [DataRow(typeof(float1x3), typeof(Float1x3))]
    [DataRow(typeof(float1x4), typeof(Float1x4))]
    [DataRow(typeof(float2x1), typeof(Float2x1))]
    [DataRow(typeof(float2x2), typeof(Float2x2))]
    [DataRow(typeof(float2x3), typeof(Float2x3))]
    [DataRow(typeof(float2x4), typeof(Float2x4))]
    [DataRow(typeof(float3x1), typeof(Float3x1))]
    [DataRow(typeof(float3x2), typeof(Float3x2))]
    [DataRow(typeof(float3x3), typeof(Float3x3))]
    [DataRow(typeof(float3x4), typeof(Float3x4))]
    [DataRow(typeof(float4x1), typeof(Float4x1))]
    [DataRow(typeof(float4x2), typeof(Float4x2))]
    [DataRow(typeof(float4x3), typeof(Float4x3))]
    [DataRow(typeof(float4x4), typeof(Float4x4))]
    [DataRow(typeof(int2), typeof(Int2))]
    [DataRow(typeof(int3), typeof(Int3))]
    [DataRow(typeof(int4), typeof(Int4))]
    [DataRow(typeof(int1x1), typeof(Int1x1))]
    [DataRow(typeof(int1x2), typeof(Int1x2))]
    [DataRow(typeof(int1x3), typeof(Int1x3))]
    [DataRow(typeof(int1x4), typeof(Int1x4))]
    [DataRow(typeof(int2x1), typeof(Int2x1))]
    [DataRow(typeof(int2x2), typeof(Int2x2))]
    [DataRow(typeof(int2x3), typeof(Int2x3))]
    [DataRow(typeof(int2x4), typeof(Int2x4))]
    [DataRow(typeof(int3x1), typeof(Int3x1))]
    [DataRow(typeof(int3x2), typeof(Int3x2))]
    [DataRow(typeof(int3x3), typeof(Int3x3))]
    [DataRow(typeof(int3x4), typeof(Int3x4))]
    [DataRow(typeof(int4x1), typeof(Int4x1))]
    [DataRow(typeof(int4x2), typeof(Int4x2))]
    [DataRow(typeof(int4x3), typeof(Int4x3))]
    [DataRow(typeof(int4x4), typeof(Int4x4))]
    [DataRow(typeof(uint2), typeof(UInt2))]
    [DataRow(typeof(uint3), typeof(UInt3))]
    [DataRow(typeof(uint4), typeof(UInt4))]
    [DataRow(typeof(uint1x1), typeof(UInt1x1))]
    [DataRow(typeof(uint1x2), typeof(UInt1x2))]
    [DataRow(typeof(uint1x3), typeof(UInt1x3))]
    [DataRow(typeof(uint1x4), typeof(UInt1x4))]
    [DataRow(typeof(uint2x1), typeof(UInt2x1))]
    [DataRow(typeof(uint2x2), typeof(UInt2x2))]
    [DataRow(typeof(uint2x3), typeof(UInt2x3))]
    [DataRow(typeof(uint2x4), typeof(UInt2x4))]
    [DataRow(typeof(uint3x1), typeof(UInt3x1))]
    [DataRow(typeof(uint3x2), typeof(UInt3x2))]
    [DataRow(typeof(uint3x3), typeof(UInt3x3))]
    [DataRow(typeof(uint3x4), typeof(UInt3x4))]
    [DataRow(typeof(uint4x1), typeof(UInt4x1))]
    [DataRow(typeof(uint4x2), typeof(UInt4x2))]
    [DataRow(typeof(uint4x3), typeof(UInt4x3))]
    [DataRow(typeof(uint4x4), typeof(UInt4x4))]
    public void EnsureGlobalUsingDirectivesArePresent(Type left, Type right)
    {
        Assert.AreEqual(left, right);
    }
}