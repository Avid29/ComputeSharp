// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/dwrite.h in the Windows SDK for Windows 10.0.20348.0
// Original source is Copyright © Microsoft. All rights reserved.

namespace TerraFX.Interop.DirectX
{
    internal partial struct DWRITE_TEXT_METRICS
    {
        public float left;

        public float top;

        public float width;

        public float widthIncludingTrailingWhitespace;

        public float height;

        public float layoutWidth;

        public float layoutHeight;

        [NativeTypeName("UINT32")]
        public uint maxBidiReorderingDepth;

        [NativeTypeName("UINT32")]
        public uint lineCount;
    }
}
