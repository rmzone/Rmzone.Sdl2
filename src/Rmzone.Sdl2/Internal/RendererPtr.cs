using System;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global

namespace Rmzone.Sdl2.Internal
{
    /// <summary>
    /// A transparent wrapper over a pointer representing an SDL Renderer object.
    /// </summary>
    public readonly struct RendererPtr
    {
        /// <summary>
        /// The native SDL_Renderer pointer.
        /// </summary>
        public readonly IntPtr NativePointer;

        public RendererPtr(IntPtr pointer)
        {
            NativePointer = pointer;
        }

        public static implicit operator IntPtr(RendererPtr renderer) => renderer.NativePointer;
        public static implicit operator RendererPtr(IntPtr pointer) => new RendererPtr(pointer);
    }
}
