using System;
using System.Runtime.InteropServices;
using Rmzone.Sdl2.Internal;

namespace Rmzone.Sdl2
{
    public sealed class Surface
    {
        #region Fields

        private readonly SurfacePtr _surfacePtr;

        #endregion

        #region Constructor

        private Surface(SurfacePtr surfacePtr)
        {
            _surfacePtr = surfacePtr;
        }

        #endregion

        #region Methods

        public static Surface GetWindowSurface(Window window)
        {
            var surfacePtr = Sdl2Native.SDL_GetWindowSurface(window.SdlWindowHandle);
            if (surfacePtr == IntPtr.Zero)
            {
                throw new Exception($"SDL Error: {Sdl2Native.SDL_GetError()}");
            }

            return new Surface(surfacePtr);
        }

        public static Surface CreateSurface(uint flags, int w, int h, int d, Surface surface)
        {
            var screen = Marshal.PtrToStructure<Sdl2Native.SDL_Surface>(surface._surfacePtr);

            var format = Marshal.PtrToStructure<Sdl2Native.SDL_PixelFormat>(screen.format);

            var sclscreen = Sdl2Native.SDL_CreateRGBSurface(flags, w, h, d,
                format.Rmask,
                format.Gmask,
                format.Bmask,
                format.Amask);

            return new Surface(sclscreen);
        }

        public void Lock()
        {
            Sdl2Native.SDL_LockSurface(_surfacePtr);
        }

        public void UnLock()
        {
            Sdl2Native.SDL_UnlockSurface(_surfacePtr);
        }

        public static void BlitSurface(Surface src, object o, Surface dst, object o1)
        {
            Sdl2Native.SDL_BlitSurface(src._surfacePtr, IntPtr.Zero, dst._surfacePtr, IntPtr.Zero);
        }

        #endregion
    }
}
