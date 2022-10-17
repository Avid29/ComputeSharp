using ABI.Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas;
using System.Numerics;
using System;
using Windows.Foundation;
using TerraFX.Interop.Windows;
using TerraFX.Interop.DirectX;
using ComputeSharp.D2D1.Interop;
using ComputeSharp.D2D1.Extensions;

namespace ComputeSharp.D2D1.Uwp;

/// <summary>
/// A custom <see cref="ICanvasImage"/> implementation powered by a supplied shader type.
/// </summary>
/// <typeparam name="T">The type of shader to use to render frames.</typeparam>
public sealed class PixelShaderEffect<T> : ICanvasImage, ICanvasImageInterop
    where T : unmanaged, ID2D1PixelShader
{
    /// <summary>
    /// The current <typeparamref name="T"/> value in use.
    /// </summary>
    public T Value;

    private ComPtr<ID2D1Effect> effect;

    /// <inheritdoc/>
    public void Dispose()
    {
    }

    /// <inheritdoc/>
    Rect ICanvasImage.GetBounds(ICanvasResourceCreator resourceCreator)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    Rect ICanvasImage.GetBounds(ICanvasResourceCreator resourceCreator, Matrix3x2 transform)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    unsafe int ICanvasImageInterop.GetDevice(IUnknown** device)
    {
        return S.S_OK;
    }

    /// <inheritdoc/>
    unsafe int ICanvasImageInterop.GetD2DImage(
        IUnknown* device,
        ID2D1DeviceContext* deviceContext,
        CanvasImageGetD2DImageFlags flags,
        float targetDpi,
        float* realizeDpi,
        ID2D1Image** ppImage)
    {
        if (realizeDpi is not null)
        {
            *realizeDpi = 0;
        }

        try
        {
            if (this.effect.Get() is null)
            {
                using ComPtr<ID2D1Factory> d2D1Factory = default;

                deviceContext->GetFactory(d2D1Factory.GetAddressOf());

                using ComPtr<ID2D1Factory1> d2D1Factory1 = default;

                d2D1Factory.CopyTo(d2D1Factory1.GetAddressOf()).Assert();

                D2D1PixelShaderEffect.RegisterForD2D1Factory1<T>(d2D1Factory1.Get(), out _);

                using ComPtr<ID2D1Effect> d2D1Effect = default;

                D2D1PixelShaderEffect.CreateFromD2D1DeviceContext<T>(deviceContext, (void**)d2D1Effect.GetAddressOf());

                D2D1PixelShaderEffect.SetConstantBufferForD2D1Effect(in this.Value, d2D1Effect.Get());

                this.effect = new(d2D1Effect.Get());

                d2D1Effect.CopyTo(ppImage).Assert();
            }
            else
            {
                D2D1PixelShaderEffect.SetConstantBufferForD2D1Effect(in this.Value, this.effect.Get());

                this.effect.CopyTo(ppImage).Assert();
            }

            return S.S_OK;
        }
        catch (Exception e)
        {
            return e.HResult;
        }
    }
}