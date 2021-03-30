using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Rmzone.Sdl2.Internal;
using static Rmzone.Sdl2.Internal.Sdl2Native;

namespace Rmzone.Sdl2
{
    internal static class Sdl2EventProcessor
    {
        public static readonly object Lock = new object();
        private static readonly Dictionary<uint, Window> EventsByWindowId
            = new Dictionary<uint, Window>();

        public static unsafe void PumpEvents()
        {
            Debug.Assert(Monitor.IsEntered(Lock));
            SDL_Event ev;
            while (SDL_PollEvent(&ev) == 1)
            {
                if (EventsByWindowId.TryGetValue(ev.windowID, out var window))
                {
                    window.AddEvent(ev);
                }
            }
        }

        public static void RegisterWindow(Window window)
        {
            lock (Lock)
            {
                EventsByWindowId.Add(window.WindowId, window);
            }
        }

        public static void RemoveWindow(Window window)
        {
            lock (Lock)
            {
                EventsByWindowId.Remove(window.WindowId);
            }
        }
    }
}
