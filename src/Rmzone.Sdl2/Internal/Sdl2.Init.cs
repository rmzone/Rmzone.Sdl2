using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Rmzone.Sdl2.Internal
{
    public static partial class Sdl2Native
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_Init_t(InitFlags flags);
        private static readonly SDL_Init_t s_sdl_init = LoadFunction<SDL_Init_t>("SDL_Init");
        public static int SDL_Init(InitFlags flags) => s_sdl_init(flags);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_InitSubSystem_t(InitFlags flags);
        private static readonly SDL_InitSubSystem_t s_sdl_init_subsystem = LoadFunction<SDL_InitSubSystem_t>("SDL_InitSubSystem");
        public static int SDL_InitSubSystem(InitFlags flags) => s_sdl_init_subsystem(flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_Quit_t();
        private static readonly SDL_Quit_t s_sdl_quit = LoadFunction<SDL_Quit_t>("SDL_Quit");
        public static void SDL_Quit() => s_sdl_quit();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_QuitSubSystem_t(InitFlags flags);
        private static readonly SDL_QuitSubSystem_t s_sdl_quit_subsystem = LoadFunction<SDL_QuitSubSystem_t>("SDL_QuitSubSystem");
        public static void SDL_QuitSubSystem(InitFlags flags) => s_sdl_quit_subsystem(flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint SDL_WasInit_t(InitFlags flags);
        private static readonly SDL_WasInit_t s_sdl_was_init = LoadFunction<SDL_WasInit_t>("SDL_WasInit");
        public static uint SDL_WasInit(InitFlags flags) => s_sdl_was_init(flags);
    }
}
