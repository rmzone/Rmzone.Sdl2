using System;

namespace Rmzone.Sdl2
{
    [Flags]
    public enum WindowFlags : uint
    {
        Fullscreen =		0x00000001,
        OpenGl =		0x00000002,
        Shown =		0x00000004,
        Hidden =		0x00000008,
        Borderless =		0x00000010,
        Resizable =		0x00000020,
        Minimized =		0x00000040,
        Maximized =		0x00000080,
        SDL_WINDOW_INPUT_GRABBED =	0x00000100,
        InputFocus =	0x00000200,
        SDL_WINDOW_MOUSE_FOCUS =	0x00000400,
        FullScreenDesktop =
            (Fullscreen | 0x00001000),
        SDL_WINDOW_FOREIGN =		0x00000800,
        SDL_WINDOW_ALLOW_HIGHDPI =	0x00002000,
        SDL_WINDOW_MOUSE_CAPTURE =	0x00004000,
        SDL_WINDOW_ALWAYS_ON_TOP =	0x00008000,
        SDL_WINDOW_SKIP_TASKBAR =	0x00010000,
        SDL_WINDOW_UTILITY =		0x00020000,
        SDL_WINDOW_TOOLTIP =		0x00040000,
        SDL_WINDOW_POPUP_MENU =		0x00080000,
        Vulkan =		0x10000000,
    }
}
