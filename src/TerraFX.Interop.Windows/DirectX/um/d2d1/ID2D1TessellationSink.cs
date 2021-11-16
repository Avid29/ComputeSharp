// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/d2d1.h in the Windows SDK for Windows 10.0.20348.0
// Original source is Copyright © Microsoft. All rights reserved.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TerraFX.Interop.Windows;

namespace TerraFX.Interop.DirectX
{
    [Guid("2CD906C1-12E2-11DC-9FED-001143A055F9")]
    [NativeTypeName("struct ID2D1TessellationSink : IUnknown")]
    [NativeInheritance("IUnknown")]
    public unsafe partial struct ID2D1TessellationSink : ID2D1TessellationSink.Interface
    {
        public void** lpVtbl;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(0)]
        public HRESULT QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged<ID2D1TessellationSink*, Guid*, void**, int>)(lpVtbl[0]))((ID2D1TessellationSink*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged<ID2D1TessellationSink*, uint>)(lpVtbl[1]))((ID2D1TessellationSink*)Unsafe.AsPointer(ref this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged<ID2D1TessellationSink*, uint>)(lpVtbl[2]))((ID2D1TessellationSink*)Unsafe.AsPointer(ref this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(3)]
        public void AddTriangles([NativeTypeName("const D2D1_TRIANGLE *")] D2D1_TRIANGLE* triangles, [NativeTypeName("UINT32")] uint trianglesCount)
        {
            ((delegate* unmanaged<ID2D1TessellationSink*, D2D1_TRIANGLE*, uint, void>)(lpVtbl[3]))((ID2D1TessellationSink*)Unsafe.AsPointer(ref this), triangles, trianglesCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(4)]
        public HRESULT Close()
        {
            return ((delegate* unmanaged<ID2D1TessellationSink*, int>)(lpVtbl[4]))((ID2D1TessellationSink*)Unsafe.AsPointer(ref this));
        }

        public interface Interface : IUnknown.Interface
        {
            [VtblIndex(3)]
            void AddTriangles([NativeTypeName("const D2D1_TRIANGLE *")] D2D1_TRIANGLE* triangles, [NativeTypeName("UINT32")] uint trianglesCount);

            [VtblIndex(4)]
            HRESULT Close();
        }

        public partial struct Vtbl
        {
            [NativeTypeName("HRESULT (const IID &, void **) __attribute__((stdcall))")]
            public delegate* unmanaged<ID2D1TessellationSink*, Guid*, void**, int> QueryInterface;

            [NativeTypeName("ULONG () __attribute__((stdcall))")]
            public delegate* unmanaged<ID2D1TessellationSink*, uint> AddRef;

            [NativeTypeName("ULONG () __attribute__((stdcall))")]
            public delegate* unmanaged<ID2D1TessellationSink*, uint> Release;

            [NativeTypeName("void (const D2D1_TRIANGLE *, UINT32) __attribute__((nothrow)) __attribute__((stdcall))")]
            public delegate* unmanaged<ID2D1TessellationSink*, D2D1_TRIANGLE*, uint, void> AddTriangles;

            [NativeTypeName("HRESULT () __attribute__((nothrow)) __attribute__((stdcall))")]
            public delegate* unmanaged<ID2D1TessellationSink*, int> Close;
        }
    }
}
