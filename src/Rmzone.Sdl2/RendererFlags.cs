using System;

namespace Rmzone.Sdl2
{
    [Flags]
    public enum RendererFlags : uint
    {
        Default = 0x0000000u,
        Software = 0x00000001u,
        Accelerated = 0x00000002u,
        PresentVsync = 0x00000004u,
        TargetTexture = 0x00000008u
    }
}
