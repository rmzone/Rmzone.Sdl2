using System;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global

namespace Rmzone.Sdl2.Internal
{
    /// <summary>
    /// A transparent wrapper over a pointer representing an SDL_Rect object.
    /// </summary>
    public readonly struct RectanglePtr
    {
        /// <summary>
        /// The native SDL_Renderer pointer.
        /// </summary>
        public readonly IntPtr NativePointer;

        public RectanglePtr(IntPtr pointer)
        {
            NativePointer = pointer;
        }

        public static implicit operator IntPtr(RectanglePtr rectangle) => rectangle.NativePointer;
        public static implicit operator RectanglePtr(IntPtr pointer) => new RectanglePtr(pointer);
        public static implicit operator RectanglePtr(Rectangle rect) => new RectanglePtr(IntPtr.Zero);
    }
}
