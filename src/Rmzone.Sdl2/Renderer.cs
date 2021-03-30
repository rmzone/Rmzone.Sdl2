using System;
using Rmzone.Sdl2.Internal;

namespace Rmzone.Sdl2
{
    public class Renderer
    {
        private readonly RendererPtr _rendererPtr;

        public RendererPtr Handle => _rendererPtr;

        public Renderer(Window window, int index, RendererFlags flags)
        {
            _rendererPtr = Sdl2Native.SDL_CreateRenderer(window.SdlWindowHandle, index, flags);
        }

        /// <summary>
        /// Use this function to set the color used for drawing operations (Rect, Line and Clear).
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public void SetDrawColor(byte r, byte g, byte b, byte a)
        {
            Sdl2Native.SDL_SetRenderDrawColor(_rendererPtr, r, g, b, a);
        }
        
        public void SetDrawColor(RgbaByte color)
        {
            Sdl2Native.SDL_SetRenderDrawColor(_rendererPtr, color.R, color.G, color.B, color.A);
        }

        /// <summary>
        /// Use this function to clear the current rendering target with the drawing color.
        /// </summary>
        public void Clear()
        {
            Sdl2Native.SDL_RenderClear(_rendererPtr);
        }

        public void Render()
        {
            Sdl2Native.SDL_RenderPresent(_rendererPtr);
        }

        public void SetHint(string sdlHintRenderScaleQuality, string linear)
        {
//            Sdl2Native.SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "linear");
            // TODO: SDL_SetHint("SDL_RENDER_SCALE_QUALITY", "linear");  // make the scaled rendering look smoother.
            Sdl2Native.SDL_SetHint("SDL_RENDER_SCALE_QUALITY", "linear");
        }

        /// <summary>
        /// Use this function to set a device independent resolution for rendering.
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <exception cref="Exception"></exception>
        public void RenderSetLogicalSize(int w, int h)
        {
            var result = Sdl2Native.SDL_RenderSetLogicalSize(_rendererPtr, w, h);
            if (result != 0)
            {
                throw new Exception($"SDL Error: {Sdl2Native.SDL_GetError()}");
            }
        }
    }
}
