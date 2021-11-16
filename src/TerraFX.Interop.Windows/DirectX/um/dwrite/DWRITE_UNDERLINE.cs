// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/dwrite.h in the Windows SDK for Windows 10.0.20348.0
// Original source is Copyright © Microsoft. All rights reserved.

namespace TerraFX.Interop.DirectX
{
    internal unsafe partial struct DWRITE_UNDERLINE
    {
        public float width;

        public float thickness;

        public float offset;

        public float runHeight;

        public DWRITE_READING_DIRECTION readingDirection;

        public DWRITE_FLOW_DIRECTION flowDirection;

        [NativeTypeName("const WCHAR *")]
        public ushort* localeName;

        public DWRITE_MEASURING_MODE measuringMode;
    }
}
