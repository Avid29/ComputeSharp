// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from shared/dxgi.h in the Windows SDK for Windows 10.0.20348.0
// Original source is Copyright © Microsoft. All rights reserved.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TerraFX.Interop.Windows;

namespace TerraFX.Interop.DirectX
{
    [Guid("CAFCB56C-6AC3-4889-BF47-9E23BBD260EC")]
    [NativeTypeName("struct IDXGISurface : IDXGIDeviceSubObject")]
    [NativeInheritance("IDXGIDeviceSubObject")]
    public unsafe partial struct IDXGISurface : IDXGISurface.Interface
    {
        public void** lpVtbl;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(0)]
        public HRESULT QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged<IDXGISurface*, Guid*, void**, int>)(lpVtbl[0]))((IDXGISurface*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged<IDXGISurface*, uint>)(lpVtbl[1]))((IDXGISurface*)Unsafe.AsPointer(ref this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged<IDXGISurface*, uint>)(lpVtbl[2]))((IDXGISurface*)Unsafe.AsPointer(ref this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(3)]
        public HRESULT SetPrivateData([NativeTypeName("const GUID &")] Guid* Name, uint DataSize, [NativeTypeName("const void *")] void* pData)
        {
            return ((delegate* unmanaged<IDXGISurface*, Guid*, uint, void*, int>)(lpVtbl[3]))((IDXGISurface*)Unsafe.AsPointer(ref this), Name, DataSize, pData);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(4)]
        public HRESULT SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* Name, [NativeTypeName("const IUnknown *")] IUnknown* pUnknown)
        {
            return ((delegate* unmanaged<IDXGISurface*, Guid*, IUnknown*, int>)(lpVtbl[4]))((IDXGISurface*)Unsafe.AsPointer(ref this), Name, pUnknown);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(5)]
        public HRESULT GetPrivateData([NativeTypeName("const GUID &")] Guid* Name, uint* pDataSize, void* pData)
        {
            return ((delegate* unmanaged<IDXGISurface*, Guid*, uint*, void*, int>)(lpVtbl[5]))((IDXGISurface*)Unsafe.AsPointer(ref this), Name, pDataSize, pData);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(6)]
        public HRESULT GetParent([NativeTypeName("const IID &")] Guid* riid, void** ppParent)
        {
            return ((delegate* unmanaged<IDXGISurface*, Guid*, void**, int>)(lpVtbl[6]))((IDXGISurface*)Unsafe.AsPointer(ref this), riid, ppParent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(7)]
        public HRESULT GetDevice([NativeTypeName("const IID &")] Guid* riid, void** ppDevice)
        {
            return ((delegate* unmanaged<IDXGISurface*, Guid*, void**, int>)(lpVtbl[7]))((IDXGISurface*)Unsafe.AsPointer(ref this), riid, ppDevice);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(8)]
        public HRESULT GetDesc(DXGI_SURFACE_DESC* pDesc)
        {
            return ((delegate* unmanaged<IDXGISurface*, DXGI_SURFACE_DESC*, int>)(lpVtbl[8]))((IDXGISurface*)Unsafe.AsPointer(ref this), pDesc);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(9)]
        public HRESULT Map(DXGI_MAPPED_RECT* pLockedRect, uint MapFlags)
        {
            return ((delegate* unmanaged<IDXGISurface*, DXGI_MAPPED_RECT*, uint, int>)(lpVtbl[9]))((IDXGISurface*)Unsafe.AsPointer(ref this), pLockedRect, MapFlags);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(10)]
        public HRESULT Unmap()
        {
            return ((delegate* unmanaged<IDXGISurface*, int>)(lpVtbl[10]))((IDXGISurface*)Unsafe.AsPointer(ref this));
        }

        public interface Interface : IDXGIDeviceSubObject.Interface
        {
            [VtblIndex(8)]
            HRESULT GetDesc(DXGI_SURFACE_DESC* pDesc);

            [VtblIndex(9)]
            HRESULT Map(DXGI_MAPPED_RECT* pLockedRect, uint MapFlags);

            [VtblIndex(10)]
            HRESULT Unmap();
        }

        public partial struct Vtbl
        {
            [NativeTypeName("HRESULT (const IID &, void **) __attribute__((stdcall))")]
            public delegate* unmanaged<IDXGISurface*, Guid*, void**, int> QueryInterface;

            [NativeTypeName("ULONG () __attribute__((stdcall))")]
            public delegate* unmanaged<IDXGISurface*, uint> AddRef;

            [NativeTypeName("ULONG () __attribute__((stdcall))")]
            public delegate* unmanaged<IDXGISurface*, uint> Release;

            [NativeTypeName("HRESULT (const GUID &, UINT, const void *) __attribute__((stdcall))")]
            public delegate* unmanaged<IDXGISurface*, Guid*, uint, void*, int> SetPrivateData;

            [NativeTypeName("HRESULT (const GUID &, const IUnknown *) __attribute__((stdcall))")]
            public delegate* unmanaged<IDXGISurface*, Guid*, IUnknown*, int> SetPrivateDataInterface;

            [NativeTypeName("HRESULT (const GUID &, UINT *, void *) __attribute__((stdcall))")]
            public delegate* unmanaged<IDXGISurface*, Guid*, uint*, void*, int> GetPrivateData;

            [NativeTypeName("HRESULT (const IID &, void **) __attribute__((stdcall))")]
            public delegate* unmanaged<IDXGISurface*, Guid*, void**, int> GetParent;

            [NativeTypeName("HRESULT (const IID &, void **) __attribute__((stdcall))")]
            public delegate* unmanaged<IDXGISurface*, Guid*, void**, int> GetDevice;

            [NativeTypeName("HRESULT (DXGI_SURFACE_DESC *) __attribute__((stdcall))")]
            public delegate* unmanaged<IDXGISurface*, DXGI_SURFACE_DESC*, int> GetDesc;

            [NativeTypeName("HRESULT (DXGI_MAPPED_RECT *, UINT) __attribute__((stdcall))")]
            public delegate* unmanaged<IDXGISurface*, DXGI_MAPPED_RECT*, uint, int> Map;

            [NativeTypeName("HRESULT () __attribute__((stdcall))")]
            public delegate* unmanaged<IDXGISurface*, int> Unmap;
        }
    }
}
