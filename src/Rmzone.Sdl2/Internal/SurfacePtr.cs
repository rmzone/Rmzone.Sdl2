using System;

namespace Rmzone.Sdl2.Internal;

/// <summary>
/// A transparent wrapper over a pointer representing an SDL SDL_Surface object.
/// </summary>
internal readonly struct SurfacePtr
{
    /// <summary>
    /// The native SDL_Window pointer.
    /// </summary>
    private readonly IntPtr _nativePointer;

    private SurfacePtr(IntPtr pointer)
    {
        _nativePointer = pointer;
    }

    public static implicit operator IntPtr(SurfacePtr surfacePointer) => surfacePointer._nativePointer;
    public static implicit operator SurfacePtr(IntPtr pointer) => new(pointer);
}
