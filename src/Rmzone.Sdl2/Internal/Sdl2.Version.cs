using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Rmzone.Sdl2.Internal;

internal static unsafe partial class Sdl2Native
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void SDL_GetVersion_t(SDL_version* version);
    private static readonly SDL_GetVersion_t s_getVersion = LoadFunction<SDL_GetVersion_t>("SDL_GetVersion");
    public static void GetVersion(SDL_version* version) => s_getVersion(version);
}

internal struct SDL_version
{
    public byte major;
    public byte minor;
    public byte patch;
}
