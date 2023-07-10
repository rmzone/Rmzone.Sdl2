using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using NativeLibrary = NativeLibraryLoader.NativeLibrary;

// ReSharper disable InconsistentNaming
// ReSharper disable

namespace Rmzone.Sdl2.Internal;

internal static unsafe partial class Sdl2Native
{
    private static readonly NativeLibrary s_sdl2ImageLib = LoadSdl2Image();

    private static NativeLibrary LoadSdl2Image()
    {
        string[] names;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            names = new[] { "SDL2_image.dll" };
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            names = new[]
            {
                "libSDL2_image.so",
                "libSDL2_image-2.0.so",
                "libSDL2_image-2.0.so.0",
                "libSDL2_image-2.0.so.0.2.1"
            };
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            names = new[]
            {
                "libsdl2_image.dylib"
            };
        }
        else
        {
            Debug.WriteLine("Unknown SDL platform. Attempting to load 'SDL2 Imgage'");
            names = new[] { "SDL2_Image.dll" };
        }

        var lib = new NativeLibrary(names);
        return lib;
    }

    /// <summary>
    /// Loads an SDL2 function by the given name.
    /// </summary>
    /// <typeparam name="T">The delegate type of the function to load.</typeparam>
    /// <param name="name">The name of the exported native function.</param>
    /// <returns>A delegate which can be used to invoke the native function.</returns>
    /// <exception cref="System.InvalidOperationException">Thrown when no function with the given name is exported by SDL2.
    /// </exception>
    private static T LoadImageFunction<T>(string name)
    {
        try
        {
            return s_sdl2ImageLib.LoadFunction<T>(name);
        }
        catch
        {
            Debug.WriteLine(
                $"Unable to load SDL2 Image function \"{name}\". " +
                $"Attempting to call this function will cause an exception to be thrown.");
            return default(T);
        }
    }
    /* Similar to the headers, this is the version we're expecting to be
	 * running with. You will likely want to check this somewhere in your
	 * program!
	 */

    private const int SDL_IMAGE_MAJOR_VERSION =	2;
    private const int SDL_IMAGE_MINOR_VERSION =	0;
    private const int SDL_IMAGE_PATCHLEVEL =		2;

    [Flags]
    public enum IMG_InitFlags
    {
        IMG_INIT_JPG =	0x00000001,
        IMG_INIT_PNG =	0x00000002,
        IMG_INIT_TIF =	0x00000004,
        IMG_INIT_WEBP =	0x00000008
    }

    public static void SDL_IMAGE_VERSION(out SDL_version X)
    {
        X.major = SDL_IMAGE_MAJOR_VERSION;
        X.minor = SDL_IMAGE_MINOR_VERSION;
        X.patch = SDL_IMAGE_PATCHLEVEL;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int IMG_Init_t(IMG_InitFlags flags);
    private static readonly IMG_Init_t s_img_init = LoadImageFunction<IMG_Init_t>("IMG_Init");
    public static int IMG_Init(IMG_InitFlags flags) => s_img_init(flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void IMG_Quit_t();
    private static readonly IMG_Quit_t s_img_quit = LoadImageFunction<IMG_Quit_t>("IMG_Quit");
    public static void IMG_Quit() => s_img_quit();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate IntPtr IMG_Load_t(byte[] file);
    private static readonly IMG_Load_t s_img_load = LoadImageFunction<IMG_Load_t>("IMG_Load");
    public static IntPtr IMG_Load(string file) => s_img_load(Utilities.UTF8_ToNative(file));
}
