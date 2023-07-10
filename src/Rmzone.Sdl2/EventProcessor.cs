using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Rmzone.Sdl2.Internal;
using static Rmzone.Sdl2.Internal.Sdl2Native;

namespace Rmzone.Sdl2
{
    internal static class EventProcessor
    {
        public static readonly object Lock = new();
        private static readonly Dictionary<uint, Window> EventsByWindowId
            = new();

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
