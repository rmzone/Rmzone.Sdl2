using System;

namespace Rmzone.Sdl2.Internal;

/// <summary>
/// A transparent wrapper over a pointer representing an SDL_Rect object.
/// </summary>
internal readonly struct RectanglePtr
{
    /// <summary>
    /// The native SDL_Renderer pointer.
    /// </summary>
    private readonly IntPtr _nativePointer;

    private RectanglePtr(IntPtr pointer)
    {
        _nativePointer = pointer;
    }

    public static implicit operator IntPtr(RectanglePtr rectangle) => rectangle._nativePointer;
    public static implicit operator RectanglePtr(IntPtr pointer) => new(pointer);
    public static implicit operator RectanglePtr(Rectangle rectange) => new(IntPtr.Zero);
}
