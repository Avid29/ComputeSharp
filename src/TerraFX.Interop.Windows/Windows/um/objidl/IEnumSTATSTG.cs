// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/objidl.h in the Windows SDK for Windows 10.0.20348.0
// Original source is Copyright © Microsoft. All rights reserved.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TerraFX.Interop.Windows
{
    [Guid("0000000D-0000-0000-C000-000000000046")]
    [NativeTypeName("struct IEnumSTATSTG : IUnknown")]
    [NativeInheritance("IUnknown")]
    public unsafe partial struct IEnumSTATSTG : IEnumSTATSTG.Interface
    {
        public void** lpVtbl;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(0)]
        public HRESULT QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged<IEnumSTATSTG*, Guid*, void**, int>)(lpVtbl[0]))((IEnumSTATSTG*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged<IEnumSTATSTG*, uint>)(lpVtbl[1]))((IEnumSTATSTG*)Unsafe.AsPointer(ref this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged<IEnumSTATSTG*, uint>)(lpVtbl[2]))((IEnumSTATSTG*)Unsafe.AsPointer(ref this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(3)]
        public HRESULT Next([NativeTypeName("ULONG")] uint celt, STATSTG* rgelt, [NativeTypeName("ULONG *")] uint* pceltFetched)
        {
            return ((delegate* unmanaged<IEnumSTATSTG*, uint, STATSTG*, uint*, int>)(lpVtbl[3]))((IEnumSTATSTG*)Unsafe.AsPointer(ref this), celt, rgelt, pceltFetched);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(4)]
        public HRESULT Skip([NativeTypeName("ULONG")] uint celt)
        {
            return ((delegate* unmanaged<IEnumSTATSTG*, uint, int>)(lpVtbl[4]))((IEnumSTATSTG*)Unsafe.AsPointer(ref this), celt);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(5)]
        public HRESULT Reset()
        {
            return ((delegate* unmanaged<IEnumSTATSTG*, int>)(lpVtbl[5]))((IEnumSTATSTG*)Unsafe.AsPointer(ref this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(6)]
        public HRESULT Clone(IEnumSTATSTG** ppenum)
        {
            return ((delegate* unmanaged<IEnumSTATSTG*, IEnumSTATSTG**, int>)(lpVtbl[6]))((IEnumSTATSTG*)Unsafe.AsPointer(ref this), ppenum);
        }

        public interface Interface : IUnknown.Interface
        {
            [VtblIndex(3)]
            HRESULT Next([NativeTypeName("ULONG")] uint celt, STATSTG* rgelt, [NativeTypeName("ULONG *")] uint* pceltFetched);

            [VtblIndex(4)]
            HRESULT Skip([NativeTypeName("ULONG")] uint celt);

            [VtblIndex(5)]
            HRESULT Reset();

            [VtblIndex(6)]
            HRESULT Clone(IEnumSTATSTG** ppenum);
        }

        public partial struct Vtbl
        {
            [NativeTypeName("HRESULT (const IID &, void **) __attribute__((stdcall))")]
            public delegate* unmanaged<IEnumSTATSTG*, Guid*, void**, int> QueryInterface;

            [NativeTypeName("ULONG () __attribute__((stdcall))")]
            public delegate* unmanaged<IEnumSTATSTG*, uint> AddRef;

            [NativeTypeName("ULONG () __attribute__((stdcall))")]
            public delegate* unmanaged<IEnumSTATSTG*, uint> Release;

            [NativeTypeName("HRESULT (ULONG, STATSTG *, ULONG *) __attribute__((stdcall))")]
            public delegate* unmanaged<IEnumSTATSTG*, uint, STATSTG*, uint*, int> Next;

            [NativeTypeName("HRESULT (ULONG) __attribute__((stdcall))")]
            public delegate* unmanaged<IEnumSTATSTG*, uint, int> Skip;

            [NativeTypeName("HRESULT () __attribute__((stdcall))")]
            public delegate* unmanaged<IEnumSTATSTG*, int> Reset;

            [NativeTypeName("HRESULT (IEnumSTATSTG **) __attribute__((stdcall))")]
            public delegate* unmanaged<IEnumSTATSTG*, IEnumSTATSTG**, int> Clone;
        }
    }
}
