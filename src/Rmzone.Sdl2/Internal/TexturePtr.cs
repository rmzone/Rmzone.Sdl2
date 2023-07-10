using System;

namespace Rmzone.Sdl2.Internal;

/// <summary>
/// A transparent wrapper over a pointer representing an SDL Texture object.
/// </summary>
internal readonly struct TexturePtr
{
    /// <summary>
    /// The native SDL_Texture pointer.
    /// </summary>
    private readonly IntPtr _nativePointer;

    private TexturePtr(IntPtr pointer)
    {
        _nativePointer = pointer;
    }

    public static implicit operator IntPtr(TexturePtr texturePointer) => texturePointer._nativePointer;
    public static implicit operator TexturePtr(IntPtr pointer) => new(pointer);
}
