using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming

namespace Rmzone.Sdl2.Internal
{
    public static unsafe partial class Sdl2Native
    {
        /// <summary>
        /// A special sentinel value indicating that a newly-created window should be centered in the screen.
        /// </summary>
        public const int SDL_WINDOWPOS_CENTERED = 0x2FFF0000;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate WindowPtr SDL_CreateWindow_t(string title, int x, int y, int w, int h, WindowFlags flags);
        private static readonly SDL_CreateWindow_t s_sdl_createWindow = LoadFunction<SDL_CreateWindow_t>("SDL_CreateWindow");
        public static WindowPtr SDL_CreateWindow(string title, int x, int y, int w, int h, WindowFlags flags) => s_sdl_createWindow(title, x, y, w, h, flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate WindowPtr SDL_CreateWindowFrom_t(IntPtr data);
        private static readonly SDL_CreateWindowFrom_t s_sdl_createWindowFrom = LoadFunction<SDL_CreateWindowFrom_t>("SDL_CreateWindowFrom");
        public static WindowPtr CreateWindowFrom(IntPtr data) => s_sdl_createWindowFrom(data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_DestroyWindow_t(WindowPtr sdl2WindowPtr);
        private static readonly SDL_DestroyWindow_t s_sdl_destroyWindow = LoadFunction<SDL_DestroyWindow_t>("SDL_DestroyWindow");
        public static void DestroyWindow(WindowPtr sdl2WindowPtr) => s_sdl_destroyWindow(sdl2WindowPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetWindowSize_t(WindowPtr sdl2WindowPtr, int* w, int* h);
        private static readonly SDL_GetWindowSize_t s_getWindowSize = LoadFunction<SDL_GetWindowSize_t>("SDL_GetWindowSize");
        public static void GetWindowSize(WindowPtr sdl2WindowPtr, int* w, int* h) => s_getWindowSize(sdl2WindowPtr, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetWindowPosition_t(WindowPtr sdl2WindowPtr, int* x, int* y);
        private static readonly SDL_GetWindowPosition_t s_getWindowPosition = LoadFunction<SDL_GetWindowPosition_t>("SDL_GetWindowPosition");
        public static void GetWindowPosition(WindowPtr sdl2WindowPtr, int* x, int* y) => s_getWindowPosition(sdl2WindowPtr, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowPosition_t(WindowPtr sdl2WindowPtr, int x, int y);
        private static readonly SDL_SetWindowPosition_t s_setWindowPosition = LoadFunction<SDL_SetWindowPosition_t>("SDL_SetWindowPosition");
        public static void SetWindowPosition(WindowPtr sdl2WindowPtr, int x, int y) => s_setWindowPosition(sdl2WindowPtr, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowSize_t(WindowPtr sdl2WindowPtr, int w, int h);
        private static readonly SDL_SetWindowSize_t s_setWindowSize = LoadFunction<SDL_SetWindowSize_t>("SDL_SetWindowSize");
        public static void SetWindowSize(WindowPtr sdl2WindowPtr, int w, int h) => s_setWindowSize(sdl2WindowPtr, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate string SDL_GetWindowTitle_t(WindowPtr sdl2WindowPtr);
        private static readonly SDL_GetWindowTitle_t s_getWindowTitle = LoadFunction<SDL_GetWindowTitle_t>("SDL_GetWindowTitle");
        public static string GetWindowTitle(WindowPtr sdl2WindowPtr) => s_getWindowTitle(sdl2WindowPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowTitle_t(WindowPtr sdl2WindowPtr, string title);
        private static readonly SDL_SetWindowTitle_t s_setWindowTitle = LoadFunction<SDL_SetWindowTitle_t>("SDL_SetWindowTitle");
        public static void SetWindowTitle(WindowPtr sdl2WindowPtr, string title) => s_setWindowTitle(sdl2WindowPtr, title);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate WindowFlags SDL_GetWindowFlags_t(WindowPtr sdl2WindowPtr);
        private static readonly SDL_GetWindowFlags_t s_getWindowFlags = LoadFunction<SDL_GetWindowFlags_t>("SDL_GetWindowFlags");
        public static WindowFlags GetWindowFlags(WindowPtr sdl2WindowPtr) => s_getWindowFlags(sdl2WindowPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowBordered_t(WindowPtr sdl2WindowPtr, uint bordered);
        private static readonly SDL_SetWindowBordered_t s_setWindowBordered = LoadFunction<SDL_SetWindowBordered_t>("SDL_SetWindowBordered");
        public static void SetWindowBordered(WindowPtr sdl2WindowPtr, uint bordered) => s_setWindowBordered(sdl2WindowPtr, bordered);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_MaximizeWindow_t(WindowPtr sdl2WindowPtr);
        private static readonly SDL_MaximizeWindow_t s_maximizeWindow = LoadFunction<SDL_MaximizeWindow_t>("SDL_MaximizeWindow");
        public static void MaximizeWindow(WindowPtr sdl2WindowPtr) => s_maximizeWindow(sdl2WindowPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_MinimizeWindow_t(WindowPtr sdl2WindowPtr);
        private static readonly SDL_MinimizeWindow_t s_minimizeWindow = LoadFunction<SDL_MinimizeWindow_t>("SDL_MinimizeWindow");
        public static void MinimizeWindow(WindowPtr sdl2WindowPtr) => s_minimizeWindow(sdl2WindowPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetWindowFullscreen_t(WindowPtr sdl2WindowPtr, FullScreenMode mode);
        private static readonly SDL_SetWindowFullscreen_t s_setWindowFullscreen = LoadFunction<SDL_SetWindowFullscreen_t>("SDL_SetWindowFullscreen");
        public static int SetWindowFullscreen(WindowPtr sdl2WindowPtr, FullScreenMode mode) => s_setWindowFullscreen(sdl2WindowPtr, mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_ShowWindow_t(WindowPtr sdl2WindowPtr);
        private static readonly SDL_ShowWindow_t s_showWindow = LoadFunction<SDL_ShowWindow_t>("SDL_ShowWindow");
        public static void ShowWindow(WindowPtr sdl2WindowPtr) => s_showWindow(sdl2WindowPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_HideWindow_t(WindowPtr sdl2WindowPtr);
        private static readonly SDL_HideWindow_t s_hideWindow = LoadFunction<SDL_HideWindow_t>("SDL_HideWindow");
        public static void HideWindow(WindowPtr sdl2WindowPtr) => s_hideWindow(sdl2WindowPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint SDL_GetWindowID_t(WindowPtr sdl2WindowPtr);
        private static readonly SDL_GetWindowID_t s_getWindowID = LoadFunction<SDL_GetWindowID_t>("SDL_GetWindowID");
        public static uint GetWindowID(WindowPtr sdl2WindowPtr) => s_getWindowID(sdl2WindowPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetWindowOpacity_t(WindowPtr windowPtr, float opacity);
        private static readonly SDL_SetWindowOpacity_t s_setWindowOpacity = LoadFunction<SDL_SetWindowOpacity_t>("SDL_SetWindowOpacity");
        public static int SetWindowOpacity(WindowPtr sdl2WindowPtr, float opacity) => s_setWindowOpacity(sdl2WindowPtr, opacity);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetWindowOpacity_t(WindowPtr windowPtr, float* opacity);
        private static readonly SDL_GetWindowOpacity_t s_getWindowOpacity = LoadFunction<SDL_GetWindowOpacity_t>("SDL_GetWindowOpacity");
        public static int GetWindowOpacity(WindowPtr sdl2WindowPtr, float* opacity) => s_getWindowOpacity(sdl2WindowPtr, opacity);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowResizable_t(WindowPtr windowPtr, uint resizable);
        private static readonly SDL_SetWindowResizable_t s_setWindowResizable = LoadFunction<SDL_SetWindowResizable_t>("SDL_SetWindowResizable");
        public static void SetWindowResizable(WindowPtr windowPtr, uint resizable) => s_setWindowResizable(windowPtr, resizable);
    }

    public enum FullScreenMode : uint
    {
        Windowed = 0,
        Fullscreen = 0x00000001,
        FullScreenDesktop = (Fullscreen | 0x00001000),
    }
}
