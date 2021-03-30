using System;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global

namespace Rmzone.Sdl2.Internal
{
    /// <summary>
    /// A transparent wrapper over a pointer representing an SDL Sdl2Window object.
    /// </summary>
    public readonly struct WindowPtr
    {
        /// <summary>
        /// The native SDL_Window pointer.
        /// </summary>
        public readonly IntPtr NativePointer;

        public WindowPtr(IntPtr pointer)
        {
            NativePointer = pointer;
        }

        public static implicit operator IntPtr(WindowPtr sdl2WindowPtr) => sdl2WindowPtr.NativePointer;
        public static implicit operator WindowPtr(IntPtr pointer) => new WindowPtr(pointer);
    }
}
