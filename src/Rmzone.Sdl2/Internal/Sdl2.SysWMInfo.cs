using System;
using System.Runtime.InteropServices;

namespace Rmzone.Sdl2.Internal
{
    internal static unsafe partial class Sdl2Native
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetWindowWMInfo_t(WindowPtr sdl2WindowPtr, SDL_SysWMinfo* info);
        private static readonly SDL_GetWindowWMInfo_t s_getWindowWMInfo = LoadFunction<SDL_GetWindowWMInfo_t>("SDL_GetWindowWMInfo");
        public static int SDL_GetWMWindowInfo(WindowPtr sdl2WindowPtr, SDL_SysWMinfo* info) => s_getWindowWMInfo(sdl2WindowPtr, info);
    }

    internal struct SDL_SysWMinfo
    {
        public SDL_version version;
        public SysWMType subsystem;
        public WindowInfo info;
    }

    internal unsafe struct WindowInfo
    {
        public const int WindowInfoSizeInBytes = 100;
        private fixed byte bytes[WindowInfoSizeInBytes];
    }

    internal struct Win32WindowInfo
    {
        /// <summary>
        /// The Sdl2Window handle.
        /// </summary>
        public IntPtr Sdl2Window;
        /// <summary>
        /// The Sdl2Window device context.
        /// </summary>
        public IntPtr hdc;
        /// <summary>
        /// The instance handle.
        /// </summary>
        public IntPtr hinstance;
    }

    internal struct X11WindowInfo
    {
        public IntPtr display;
        public IntPtr Sdl2Window;
    }

    internal struct WaylandWindowInfo
    {
        public IntPtr display;
        public IntPtr surface;
        public IntPtr shellSurface;
    }

    internal struct CocoaWindowInfo
    {
        /// <summary>
        /// The NSWindow* Cocoa window.
        /// </summary>
        public IntPtr Window;
    }

    internal enum SysWMType
    {
        Unknown,
        Windows,
        X11,
        DirectFB,
        Cocoa,
        UIKit,
        Wayland,
        Mir,
        WinRT,
        Android,
        Vivante
    }
}
