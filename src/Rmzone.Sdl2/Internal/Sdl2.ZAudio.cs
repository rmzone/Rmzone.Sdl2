using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global

namespace Rmzone.Sdl2.Internal;

internal static unsafe partial class Sdl2Native
{
    #region Defs

    private const ushort SDL_AUDIO_MASK_BITSIZE = 0xFF;
    private const ushort SDL_AUDIO_MASK_DATATYPE = 1 << 8;
    private const ushort SDL_AUDIO_MASK_ENDIAN =	1 << 12;
    private const ushort SDL_AUDIO_MASK_SIGNED =	1 << 15;

    public static ushort SDL_AUDIO_BITSIZE(ushort x)
    {
        return (ushort) (x & SDL_AUDIO_MASK_BITSIZE);
    }

    public static bool SDL_AUDIO_ISFLOAT(ushort x)
    {
        return (x & SDL_AUDIO_MASK_DATATYPE) != 0;
    }

    public static bool SDL_AUDIO_ISBIGENDIAN(ushort x)
    {
        return (x & SDL_AUDIO_MASK_ENDIAN) != 0;
    }

    public static bool SDL_AUDIO_ISSIGNED(ushort x)
    {
        return (x & SDL_AUDIO_MASK_SIGNED) != 0;
    }

    public static bool SDL_AUDIO_ISINT(ushort x)
    {
        return (x & SDL_AUDIO_MASK_DATATYPE) == 0;
    }

    public static bool SDL_AUDIO_ISLITTLEENDIAN(ushort x)
    {
        return (x & SDL_AUDIO_MASK_ENDIAN) == 0;
    }

    public static bool SDL_AUDIO_ISUNSIGNED(ushort x)
    {
        return (x & SDL_AUDIO_MASK_SIGNED) == 0;
    }

    public const ushort AUDIO_U8 =		0x0008;
    public const ushort AUDIO_S8 =		0x8008;
    public const ushort AUDIO_U16LSB =	0x0010;
    public const ushort AUDIO_S16LSB =	0x8010;
    public const ushort AUDIO_U16MSB =	0x1010;
    public const ushort AUDIO_S16MSB =	0x9010;
    public const ushort AUDIO_U16 =		AUDIO_U16LSB;
    public const ushort AUDIO_S16 =		AUDIO_S16LSB;
    public const ushort AUDIO_S32LSB =	0x8020;
    public const ushort AUDIO_S32MSB =	0x9020;
    public const ushort AUDIO_S32 =		AUDIO_S32LSB;
    public const ushort AUDIO_F32LSB =	0x8120;
    public const ushort AUDIO_F32MSB =	0x9120;
    public const ushort AUDIO_F32 =		AUDIO_F32LSB;

    public static readonly ushort AUDIO_U16SYS =
        BitConverter.IsLittleEndian ? AUDIO_U16LSB : AUDIO_U16MSB;
    public static readonly ushort AUDIO_S16SYS =
        BitConverter.IsLittleEndian ? AUDIO_S16LSB : AUDIO_S16MSB;
    public static readonly ushort AUDIO_S32SYS =
        BitConverter.IsLittleEndian ? AUDIO_S32LSB : AUDIO_S32MSB;
    public static readonly ushort AUDIO_F32SYS =
        BitConverter.IsLittleEndian ? AUDIO_F32LSB : AUDIO_F32MSB;

    public const uint SDL_AUDIO_ALLOW_FREQUENCY_CHANGE =	0x00000001;
    public const uint SDL_AUDIO_ALLOW_FORMAT_CHANGE =	0x00000002;
    public const uint SDL_AUDIO_ALLOW_CHANNELS_CHANGE =	0x00000004;
    public const uint SDL_AUDIO_ALLOW_SAMPLES_CHANGE =	0x00000008;
    public const uint SDL_AUDIO_ALLOW_ANY_CHANGE = (
        SDL_AUDIO_ALLOW_FREQUENCY_CHANGE |
        SDL_AUDIO_ALLOW_FORMAT_CHANGE |
        SDL_AUDIO_ALLOW_CHANNELS_CHANGE |
        SDL_AUDIO_ALLOW_SAMPLES_CHANGE
    );

    public const int SDL_MIX_MAXVOLUME = 128;

    public enum SDL_AudioStatus
    {
        SDL_AUDIO_STOPPED,
        SDL_AUDIO_PLAYING,
        SDL_AUDIO_PAUSED
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_AudioSpec
    {
        public int freq;
        public ushort format; // SDL_AudioFormat
        public byte channels;
        public byte silence;
        public ushort samples;
        public uint size;
        public SDL_AudioCallback callback;
        public IntPtr userdata; // void*
    }

    /* userdata refers to a void*, stream to a Uint8 */
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SDL_AudioCallback(
        IntPtr userdata,
        IntPtr stream,
        int len
    );

    #endregion

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int SDL_AudioInit_t(byte[] driver_name);
    private static readonly SDL_AudioInit_t s_sdl_audioinit = LoadFunction<SDL_AudioInit_t>("SDL_AudioInit");
    public static int SDL_AudioInit(string driver_name) => s_sdl_audioinit(Utilities.UTF8_ToNative(driver_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void SDL_AudioQuit_t();
    private static readonly SDL_AudioQuit_t s_sdl_audioquit = LoadFunction<SDL_AudioQuit_t>("SDL_AudioQuit");
    public static void SDL_AudioQuit() => s_sdl_audioquit();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void SDL_CloseAudio_t();
    private static readonly SDL_CloseAudio_t s_sdl_closeaudio = LoadFunction<SDL_CloseAudio_t>("SDL_CloseAudio");
    public static void SDL_CloseAudio() => s_sdl_closeaudio();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void SDL_CloseAudioDevice_t(uint dev);
    private static readonly SDL_CloseAudioDevice_t s_sdl_closeaudiodevice = LoadFunction<SDL_CloseAudioDevice_t>("SDL_CloseAudioDevice");
    public static void SDL_CloseAudioDevice(uint dev) => s_sdl_closeaudiodevice(dev);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int SDL_OpenAudio_t(ref SDL_AudioSpec desired, out SDL_AudioSpec obtained);
    private static readonly SDL_OpenAudio_t s_sdl_openaudio = LoadFunction<SDL_OpenAudio_t>("SDL_OpenAudio");
    public static int SDL_OpenAudio(ref SDL_AudioSpec desired, out SDL_AudioSpec obtained) => s_sdl_openaudio(ref desired, out obtained);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate uint SDL_OpenAudioDevice_t(byte[] device,	int iscapture,	ref SDL_AudioSpec desired, out SDL_AudioSpec obtained, int allowed_changes);
    private static readonly SDL_OpenAudioDevice_t s_sdl_openaudiodevice = LoadFunction<SDL_OpenAudioDevice_t>("SDL_OpenAudioDevice");
    public static uint SDL_OpenAudioDevice(string device, int iscapture, ref SDL_AudioSpec desired, out SDL_AudioSpec obtained, int allowed_changes)
        => s_sdl_openaudiodevice(Utilities.UTF8_ToNative(device), iscapture, ref desired, out obtained, allowed_changes);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void SDL_PauseAudio_t(int pause_on);
    private static readonly SDL_PauseAudio_t s_sdl_pauseaudio = LoadFunction<SDL_PauseAudio_t>("SDL_PauseAudio");
    public static void SDL_PauseAudio(int pause_on) => s_sdl_pauseaudio(pause_on);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void SDL_PauseAudioDevice_t(uint dev, int pause_on);
    private static readonly SDL_PauseAudioDevice_t s_sdl_pauseaudiodevice = LoadFunction<SDL_PauseAudioDevice_t>("SDL_PauseAudioDevice");
    public static void SDL_PauseAudioDevice(uint dev, int pause_on) => s_sdl_pauseaudiodevice(dev, pause_on);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int SDL_QueueAudio_t(uint dev,  IntPtr data, uint len);
    private static readonly SDL_QueueAudio_t s_sdl_queueaudio = LoadFunction<SDL_QueueAudio_t>("SDL_QueueAudio");
    public static int SDL_QueueAudio(uint dev, IntPtr data, UInt32 len)=> s_sdl_queueaudio(dev, data, len);
}
