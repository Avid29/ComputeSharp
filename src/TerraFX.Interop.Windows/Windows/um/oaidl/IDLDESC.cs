// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/oaidl.h in the Windows SDK for Windows 10.0.20348.0
// Original source is Copyright © Microsoft. All rights reserved.

namespace TerraFX.Interop.Windows
{
    internal partial struct IDLDESC
    {
        [NativeTypeName("ULONG_PTR")]
        public nuint dwReserved;

        public ushort wIDLFlags;
    }
}
