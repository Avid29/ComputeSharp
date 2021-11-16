// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/d3d12.h in the Windows SDK for Windows 10.0.20348.0
// Original source is Copyright © Microsoft. All rights reserved.

namespace TerraFX.Interop.DirectX
{
    internal enum D3D12_LOGIC_OP
    {
        D3D12_LOGIC_OP_CLEAR = 0,
        D3D12_LOGIC_OP_SET = (D3D12_LOGIC_OP_CLEAR + 1),
        D3D12_LOGIC_OP_COPY = (D3D12_LOGIC_OP_SET + 1),
        D3D12_LOGIC_OP_COPY_INVERTED = (D3D12_LOGIC_OP_COPY + 1),
        D3D12_LOGIC_OP_NOOP = (D3D12_LOGIC_OP_COPY_INVERTED + 1),
        D3D12_LOGIC_OP_INVERT = (D3D12_LOGIC_OP_NOOP + 1),
        D3D12_LOGIC_OP_AND = (D3D12_LOGIC_OP_INVERT + 1),
        D3D12_LOGIC_OP_NAND = (D3D12_LOGIC_OP_AND + 1),
        D3D12_LOGIC_OP_OR = (D3D12_LOGIC_OP_NAND + 1),
        D3D12_LOGIC_OP_NOR = (D3D12_LOGIC_OP_OR + 1),
        D3D12_LOGIC_OP_XOR = (D3D12_LOGIC_OP_NOR + 1),
        D3D12_LOGIC_OP_EQUIV = (D3D12_LOGIC_OP_XOR + 1),
        D3D12_LOGIC_OP_AND_REVERSE = (D3D12_LOGIC_OP_EQUIV + 1),
        D3D12_LOGIC_OP_AND_INVERTED = (D3D12_LOGIC_OP_AND_REVERSE + 1),
        D3D12_LOGIC_OP_OR_REVERSE = (D3D12_LOGIC_OP_AND_INVERTED + 1),
        D3D12_LOGIC_OP_OR_INVERTED = (D3D12_LOGIC_OP_OR_REVERSE + 1),
    }
}
