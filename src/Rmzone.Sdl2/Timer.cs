using Rmzone.Sdl2.Internal;

namespace Rmzone.Sdl2
{
    public class Timer
    {
        /// <summary>
        /// Milliseconds since system initialized
        /// </summary>
        /// <returns></returns>
        public static uint GetTicks()
        {
            return Sdl2Native.SDL_GetTicks();
        }

        /// <summary>
        /// Use this function to get the current value of the high resolution counter.
        /// </summary>
        /// <returns></returns>
        public static ulong GetPerformanceCounter()
        {
            return Sdl2Native.SDL_GetPerformanceCounter();
        }
        
        /// <summary>
        /// se this function to get the count per second of the high resolution counter.
        /// </summary>
        /// <returns></returns>
        public static ulong GetPerformanceFrequency()
        {
            return Sdl2Native.SDL_GetPerformanceFrequency();
        }
    }
}
