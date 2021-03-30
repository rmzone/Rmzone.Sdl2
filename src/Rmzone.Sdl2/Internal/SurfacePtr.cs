using System;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global

namespace Rmzone.Sdl2.Internal
{
    /// <summary>
    /// A transparent wrapper over a pointer representing an SDL SDL_Surface object.
    /// </summary>
    public readonly struct SurfacePtr
    {
        /// <summary>
        /// The native SDL_Window pointer.
        /// </summary>
        public readonly IntPtr NativePointer;

        public SurfacePtr(IntPtr pointer)
        {
            NativePointer = pointer;
        }

        public static implicit operator IntPtr(SurfacePtr Sdl2Window) => Sdl2Window.NativePointer;
        public static implicit operator SurfacePtr(IntPtr pointer) => new SurfacePtr(pointer);
    }
}
