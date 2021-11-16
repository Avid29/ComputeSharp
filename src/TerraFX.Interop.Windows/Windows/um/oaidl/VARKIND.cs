// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/oaidl.h in the Windows SDK for Windows 10.0.20348.0
// Original source is Copyright © Microsoft. All rights reserved.

namespace TerraFX.Interop.Windows
{
    internal enum VARKIND
    {
        VAR_PERINSTANCE = 0,
        VAR_STATIC = (VAR_PERINSTANCE + 1),
        VAR_CONST = (VAR_STATIC + 1),
        VAR_DISPATCH = (VAR_CONST + 1),
    }
}
