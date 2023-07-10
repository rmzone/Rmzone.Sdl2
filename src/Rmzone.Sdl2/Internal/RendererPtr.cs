using System;

namespace Rmzone.Sdl2.Internal;

/// <summary>
/// A transparent wrapper over a pointer representing an SDL Renderer object.
/// </summary>
internal readonly struct RendererPtr
{
    /// <summary>
    /// The native SDL_Renderer pointer.
    /// </summary>
    private readonly IntPtr _nativePointer;

    private RendererPtr(IntPtr pointer)
    {
        _nativePointer = pointer;
    }

    public static implicit operator IntPtr(RendererPtr renderer) => renderer._nativePointer;
    public static implicit operator RendererPtr(IntPtr pointer) => new(pointer);
}
