using System;

namespace Rmzone.Sdl2
{
    [Flags]
    public enum WindowFlags : uint
    {
        Fullscreen = 0x00000001,
        OpenGl = 0x00000002,
        Shown = 0x00000004,
        Hidden = 0x00000008,
        Borderless = 0x00000010,
        Resizable = 0x00000020,
        Minimized = 0x00000040,
        Maximized = 0x00000080,
        InputGrabbed = 0x00000100,
        InputFocus = 0x00000200,
        MouseFocus = 0x00000400,
        FullScreenDesktop = Fullscreen | 0x00001000,
        Foreign = 0x00000800,
        AllowHighdpi = 0x00002000,
        MouseCapture = 0x00004000,
        AlwaysOnTop = 0x00008000,
        SkipTaskbar = 0x00010000,
        Utility = 0x00020000,
        Tooltip = 0x00040000,
        PopupMenu = 0x00080000,
        Vulkan = 0x10000000,
    }
}
