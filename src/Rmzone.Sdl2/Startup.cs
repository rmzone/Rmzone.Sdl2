using System;
using Rmzone.Sdl2.Internal;

namespace Rmzone.Sdl2
{
    public struct WindowCreateInfo
    {
        public int X;
        public int Y;
        public int WindowWidth;
        public int WindowHeight;
        public WindowState WindowInitialState;
        public string WindowTitle;
    }

    /// <summary>
    /// Helper class for initializing the SDL system
    /// </summary>
    public static class Startup
    {
        public const int WindowposUndefined =	0x1FFF0000;
        public const int WindowposCentered =	0x2FFF0000;

        public static bool Init(InitFlags flags)
        {
            if (Sdl2Native.SDL_Init(flags) != 0)
            {
                Console.WriteLine($"SDL_image could not initialize! SDL Error: {Sdl2Native.SDL_GetError()}");
                return false;
            }

            return true;
        }

        public static Window CreateWindow(ref WindowCreateInfo windowCi)
        {
            var flags = WindowFlags.OpenGl | GetWindowFlags(windowCi.WindowInitialState);

            if (windowCi.WindowInitialState != WindowState.Hidden)
            {
                flags |= WindowFlags.Shown;
            }

            var window = new Window(
                windowCi.WindowTitle,
                windowCi.X,
                windowCi.Y,
                windowCi.WindowWidth,
                windowCi.WindowHeight,
                flags,
                false);

            // setup image lib
            var imgFlags = Sdl2Native.IMG_InitFlags.IMG_INIT_PNG;
            if ((Sdl2Native.IMG_Init(imgFlags) > 0 & imgFlags > 0) == false)
            {
                Console.WriteLine("SDL_image could not initialize! SDL_image Error: {0}", Sdl2Native.SDL_GetError());
            }

            return window;
        }

        public static void Quit()
        {
            Sdl2Native.SDL_Quit();
        }

        private static WindowFlags GetWindowFlags(WindowState state)
        {
            switch (state)
            {
                case WindowState.Normal:
                    return 0;
                case WindowState.FullScreen:
                    return WindowFlags.Fullscreen;
                case WindowState.Maximized:
                    return WindowFlags.Maximized;
                case WindowState.Minimized:
                    return WindowFlags.Minimized;
                case WindowState.BorderlessFullScreen:
                    return WindowFlags.FullScreenDesktop;
                case WindowState.Hidden:
                    return WindowFlags.Hidden;
                default:
                    throw new Exception("Invalid WindowState: " + state);
            }
        }

        public static Renderer CreateRenderer(Window window, int index, RendererFlags renderFlags)
        {
            return new Renderer(window, index, renderFlags);
        }
    }
}
