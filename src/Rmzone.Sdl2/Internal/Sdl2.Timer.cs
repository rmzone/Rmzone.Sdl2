using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming

namespace Rmzone.Sdl2.Internal
{
    internal static partial class Sdl2Native
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate UInt32 SDL_GetTicks_t();
        private static readonly SDL_GetTicks_t s_sdl_get_ticks = LoadFunction<SDL_GetTicks_t>("SDL_GetTicks");
        public static UInt32 SDL_GetTicks() => s_sdl_get_ticks();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate UInt32 SDL_GetPerformanceCounter_t();
        private static readonly SDL_GetPerformanceCounter_t s_sdl_get_performance_counter = LoadFunction<SDL_GetPerformanceCounter_t>("SDL_GetPerformanceCounter");
        public static UInt64 SDL_GetPerformanceCounter() => s_sdl_get_performance_counter();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate UInt32 SDL_GGetPerformanceFrequency_t();
        private static readonly SDL_GGetPerformanceFrequency_t s_sdl_get_performance_frequency = LoadFunction<SDL_GGetPerformanceFrequency_t>("SDL_GetPerformanceFrequency");
        public static UInt64 SDL_GetPerformanceFrequency() => s_sdl_get_performance_frequency();
    }
}
