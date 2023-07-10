using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global

namespace Rmzone.Sdl2.Internal
{
    internal static partial class Sdl2Native
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Rect
        {
            public int x;
            public int y;
            public int w;
            public int h;
        }

        public const uint SDL_SWSURFACE =	0x00000000;
        public const uint SDL_PREALLOC =	0x00000001;
        public const uint SDL_RLEACCEL =	0x00000002;
        public const uint SDL_DONTFREE =	0x00000004;

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Surface
        {
            public uint flags;
            public IntPtr format; // SDL_PixelFormat*
            public int w;
            public int h;
            public int pitch;
            public IntPtr pixels; // void*
            public IntPtr userdata; // void*
            public int locked;
            public IntPtr lock_data; // void*
            public SDL_Rect clip_rect;
            public IntPtr map; // SDL_BlitMap*
            public int refcount;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_PixelFormat
        {
            public uint format;
            public IntPtr palette; // SDL_Palette*
            public byte BitsPerPixel;
            public byte BytesPerPixel;
            public uint Rmask;
            public uint Gmask;
            public uint Bmask;
            public uint Amask;
            public byte Rloss;
            public byte Gloss;
            public byte Bloss;
            public byte Aloss;
            public byte Rshift;
            public byte Gshift;
            public byte Bshift;
            public byte Ashift;
            public int refcount;
            public IntPtr next; // SDL_PixelFormat*
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private  delegate SurfacePtr SDL_GetWindowSurface_t(WindowPtr windowPtr);
        private static readonly SDL_GetWindowSurface_t s_sdl_getWindowSurface = LoadFunction<SDL_GetWindowSurface_t>("SDL_GetWindowSurface");
        public static SurfacePtr SDL_GetWindowSurface(WindowPtr windowPtr) => s_sdl_getWindowSurface(windowPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private  delegate int SDL_FillRect_t(SurfacePtr dst, IntPtr rect, int color);
        private static readonly SDL_FillRect_t s_sdl_fill_rect = LoadFunction<SDL_FillRect_t>("SDL_FillRect");
        public static int SDL_FillRect(SurfacePtr dst, IntPtr rect, int color) => s_sdl_fill_rect(dst, rect, color);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private  delegate uint SDL_MapRGB_t(IntPtr format, byte r, byte g, byte b);
        private static readonly SDL_MapRGB_t s_sdl_map_rgb = LoadFunction<SDL_MapRGB_t>("SDL_MapRGB");
        public static uint SDL_MapRGB(IntPtr format, byte r, byte g, byte b) => s_sdl_map_rgb(format, r, g, b);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private  delegate int SDL_UpdateWindowSurface_t(WindowPtr windowPtr);
        private static readonly SDL_UpdateWindowSurface_t s_sdl_update_window_surface = LoadFunction<SDL_UpdateWindowSurface_t>("SDL_UpdateWindowSurface");
        public static int SDL_UpdateWindowSurface(WindowPtr windowPtr) => s_sdl_update_window_surface(windowPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private  delegate int SDL_LockSurface_t(SurfacePtr surface);
        private static readonly SDL_LockSurface_t s_sdl_lock_surface = LoadFunction<SDL_LockSurface_t>("SDL_LockSurface");
        public static int SDL_LockSurface(SurfacePtr surface) => s_sdl_lock_surface(surface);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private  delegate void SDL_UnlockLockSurface_t(SurfacePtr surface);
        private static readonly SDL_UnlockLockSurface_t s_sdl_unlock_surface = LoadFunction<SDL_UnlockLockSurface_t>("SDL_UnlockSurface");
        public static void SDL_UnlockSurface(SurfacePtr surface) => s_sdl_unlock_surface(surface);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private  delegate SurfacePtr SDL_CreateRGBSurface_t(uint flags, int width, int height, int depth, uint Rmask, uint Gmask, uint Bmask, uint Amask);
        private static readonly SDL_CreateRGBSurface_t s_sdl_create_surface = LoadFunction<SDL_CreateRGBSurface_t>("SDL_CreateRGBSurface");
        public static SurfacePtr SDL_CreateRGBSurface(uint flags, int width, int height, int depth, uint rmask, uint gmask, uint bmask, uint amask )
            => s_sdl_create_surface(flags, width, height, depth, rmask, gmask, bmask, amask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private  delegate void SDL_BlitSurface_t(SurfacePtr src, IntPtr srcRect, SurfacePtr dst, IntPtr dstRect);
        private static readonly SDL_BlitSurface_t s_sdl_blit_surface = LoadFunction<SDL_BlitSurface_t>("SDL_UpperBlit");
        public static void SDL_BlitSurface(SurfacePtr src, IntPtr srcRect, SurfacePtr dst, IntPtr dstRect) => s_sdl_blit_surface(src, srcRect, dst, dstRect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private  delegate void SDL_FreeSurface_t(SurfacePtr surface);
        private static readonly SDL_FreeSurface_t s_sdl_free_surface = LoadFunction<SDL_FreeSurface_t>("SDL_FreeSurface");
        public static void SDL_FreeSurface(SurfacePtr surface) => s_sdl_free_surface(surface);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetColorKey_t(SurfacePtr surface, int flag, uint key);
        private static readonly SDL_SetColorKey_t s_sdl_set_colorkey = LoadFunction<SDL_SetColorKey_t>("SDL_SetColorKey");
        public static int SDL_SetColorKey(SurfacePtr surface, int flag, uint key)
            => s_sdl_set_colorkey(surface, flag, key);
    }
}
