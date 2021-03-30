using System;

namespace Rmzone.Sdl2
{
    [Flags]
    public enum InitFlags : uint
    {
        Timer = 0x00000001u,
        Audio = 0x00000010u,
        Video = 0x00000020u,
        Joystick = 0x00000200u,
        Haptic = 0x00001000u,
        GameController = 0x00002000u,
        Events = 0x00004000u,
        Sensor = 0x00008000u,
        NoParachute = 0x00100000u,
        Everything = Timer | Audio | Video | Joystick | Haptic | GameController | Events | Sensor 
    }
}
