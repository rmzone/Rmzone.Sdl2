using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Rmzone.Sdl2.Internal
{
    public static partial class Sdl2Native
    {
        public const int SDL_QUERY = -1;
        public const int SDL_DISABLE = 0;
        public const int SDL_ENABLE = 1;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_ShowCursor_t(int toggle);
        private static readonly SDL_ShowCursor_t s_sdl_showCursor = LoadFunction<SDL_ShowCursor_t>("SDL_ShowCursor");
        public static int SDL_ShowCursor(int toggle) => s_sdl_showCursor(toggle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_WarpMouseInWindow_t(WindowPtr windowPtr, int x, int y);
        private static readonly SDL_WarpMouseInWindow_t s_sdl_warpMouseInWindow = LoadFunction<SDL_WarpMouseInWindow_t>("SDL_WarpMouseInWindow");
        public static void SDL_WarpMouseInWindow(WindowPtr windowPtr, int x, int y) => s_sdl_warpMouseInWindow(windowPtr, x, y);

    }
}
