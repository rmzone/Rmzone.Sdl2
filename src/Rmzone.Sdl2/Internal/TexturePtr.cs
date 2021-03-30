using System;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global

namespace Rmzone.Sdl2.Internal
{
    /// <summary>
    /// A transparent wrapper over a pointer representing an SDL Texture object.
    /// </summary>
    public readonly struct TexturePtr
    {
        /// <summary>
        /// The native SDL_Renderer pointer.
        /// </summary>
        public readonly IntPtr NativePointer;

        public TexturePtr(IntPtr pointer)
        {
            NativePointer = pointer;
        }

        public static implicit operator IntPtr(TexturePtr Sdl2Window) => Sdl2Window.NativePointer;
        public static implicit operator TexturePtr(IntPtr pointer) => new TexturePtr(pointer);
    }
}
