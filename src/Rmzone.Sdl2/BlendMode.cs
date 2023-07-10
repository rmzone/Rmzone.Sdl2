using System;

namespace Rmzone.Sdl2;

[Flags]
public enum BlendMode
{
    None = 0x00000000,
    Blend = 0x00000001,
    Add = 0x00000002,
    Modulate = 0x00000004,
    Multiply = 0x00000005,
    Invalid = 0x7FFFFFFF
}
