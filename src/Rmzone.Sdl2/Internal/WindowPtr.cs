using System;

namespace Rmzone.Sdl2.Internal;

/// <summary>
/// A transparent wrapper over a pointer representing an SDL Sdl2Window object.
/// </summary>
internal readonly struct WindowPtr
{
    /// <summary>
    /// The native SDL_Window pointer.
    /// </summary>
    private readonly IntPtr _nativePointer;

    private WindowPtr(IntPtr pointer)
    {
        _nativePointer = pointer;
    }

    public static implicit operator IntPtr(WindowPtr windowPointer) => windowPointer._nativePointer;
    public static implicit operator WindowPtr(IntPtr pointer) => new(pointer);
}
