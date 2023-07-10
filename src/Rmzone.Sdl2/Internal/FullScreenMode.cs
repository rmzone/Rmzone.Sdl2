namespace Rmzone.Sdl2.Internal;

internal enum FullScreenMode : uint
{
    Windowed = 0,
    Fullscreen = 0x00000001,
    FullScreenDesktop = (Fullscreen | 0x00001000),
}