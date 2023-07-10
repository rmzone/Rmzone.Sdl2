using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global

namespace Rmzone.Sdl2.Internal
{
    internal static unsafe partial class Sdl2Native
    {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SDL_RendererInfo
        {
            public IntPtr name; // const char*
            public uint flags;
            public uint num_texture_formats;
            public fixed uint texture_formats[16];
            public int max_texture_width;
            public int max_texture_height;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate RendererPtr SDL_CreateRenderer_t(WindowPtr sdl2WindowPtr, int index, RendererFlags flags);
        private static readonly SDL_CreateRenderer_t s_sdl_createRenderer = LoadFunction<SDL_CreateRenderer_t>("SDL_CreateRenderer");
        public static RendererPtr SDL_CreateRenderer(WindowPtr sdl2WindowPtr, int index, RendererFlags flags)
           => s_sdl_createRenderer(sdl2WindowPtr, index, flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_DestroyRenderer_t(RendererPtr rendererPtr);
        private static readonly SDL_DestroyRenderer_t s_sdl_destroyRenderer
            = LoadFunction<SDL_DestroyRenderer_t>("SDL_DestroyRenderer");
        public static void SDL_DestroyRenderer(RendererPtr rendererPtr)
           => s_sdl_destroyRenderer(rendererPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetRenderDrawColor_t(RendererPtr rendererPtr, byte r, byte g, byte b, byte a);
        private static readonly SDL_SetRenderDrawColor_t s_sdl_setRenderDrawColor
            = LoadFunction<SDL_SetRenderDrawColor_t>("SDL_SetRenderDrawColor");
        public static int SDL_SetRenderDrawColor(RendererPtr rendererPtr, byte r, byte g, byte b, byte a)
            => s_sdl_setRenderDrawColor(rendererPtr, r, g, b, a);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderClear_t(RendererPtr rendererPtr);
        private static readonly SDL_RenderClear_t s_sdl_renderClear
            = LoadFunction<SDL_RenderClear_t>("SDL_RenderClear");
        public static int SDL_RenderClear(RendererPtr rendererPtr) => s_sdl_renderClear(rendererPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderFillRect_t(RendererPtr rendererPtr, ref SDL_Rect rect);
        private static readonly SDL_RenderFillRect_t s_sdl_renderFillRect = LoadFunction<SDL_RenderFillRect_t>("SDL_RenderFillRect");
        public static int SDL_RenderFillRect(RendererPtr rendererPtr, ref SDL_Rect rect) => s_sdl_renderFillRect(rendererPtr, ref rect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderPresent_t(RendererPtr rendererPtr);
        private static readonly SDL_RenderPresent_t s_sdl_renderPresent
            = LoadFunction<SDL_RenderPresent_t>("SDL_RenderPresent");
        public static int SDL_RenderPresent(RendererPtr rendererPtr) => s_sdl_renderPresent(rendererPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderSetLogicalSize_t(RendererPtr rendererPtr, int w, int h);
        private static readonly SDL_RenderSetLogicalSize_t s_sdl_render_setlogicalsize
            = LoadFunction<SDL_RenderSetLogicalSize_t>("SDL_RenderSetLogicalSize");
        public static int SDL_RenderSetLogicalSize(RendererPtr renderer, int w, int h)
            => s_sdl_render_setlogicalsize(renderer, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderCopy_t(RendererPtr renderer, TexturePtr texture, IntPtr srcrect, ref SDL_Rect dstrect);
        private static readonly SDL_RenderCopy_t s_sdl_render_copy = LoadFunction<SDL_RenderCopy_t>("SDL_RenderCopy");
        public static int SDL_RenderCopy(RendererPtr renderer, TexturePtr texture, IntPtr srcrect, ref SDL_Rect dstrect)
            => s_sdl_render_copy(renderer, texture, srcrect, ref dstrect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderCopy2_t(RendererPtr renderer, TexturePtr texture, ref SDL_Rect srcrect, ref SDL_Rect dstrect);
        private static readonly SDL_RenderCopy2_t s_sdl_render_copy2 = LoadFunction<SDL_RenderCopy2_t>("SDL_RenderCopy");
        public static int SDL_RenderCopy(RendererPtr renderer, TexturePtr texture, ref SDL_Rect srcrect, ref SDL_Rect dstrect)
            => s_sdl_render_copy2(renderer, texture, ref srcrect, ref dstrect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetHint_t(byte[] name, byte[] value);
        private static readonly SDL_SetHint_t s_sdl_set_hint = LoadFunction<SDL_SetHint_t>("SDL_SetHint");
        public static int SDL_SetHint(string name, string value) => s_sdl_set_hint(Utilities.UTF8_ToNative(name), Utilities.UTF8_ToNative(value));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetRendererInfo_t(IntPtr renderer, out SDL_RendererInfo info);
        private static readonly SDL_GetRendererInfo_t s_sdl_get_renderer_info = LoadFunction<SDL_GetRendererInfo_t>("SDL_GetRendererInfo");
        public static int SDL_GetRendererInfo(IntPtr renderer, out SDL_RendererInfo info) => s_sdl_get_renderer_info(renderer, out info);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderDrawPoint_t(RendererPtr rendererPtr, int x, int y);
        private static readonly SDL_RenderDrawPoint_t s_sdl_renderDrawPoint = LoadFunction<SDL_RenderDrawPoint_t>("SDL_RenderDrawPoint");
        public static int SDL_RenderDrawPoint(RendererPtr rendererPtr, int x, int y) => s_sdl_renderDrawPoint(rendererPtr, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderDrawLine_t(RendererPtr rendererPtr, int x1, int y1, int x2, int y2);
        private static readonly SDL_RenderDrawLine_t s_sdl_renderDrawLine = LoadFunction<SDL_RenderDrawLine_t>("SDL_RenderDrawLine");
        public static int SDL_RenderDrawLine(RendererPtr rendererPtr, int x1, int y1, int x2, int y2) => s_sdl_renderDrawLine(rendererPtr, x1, y1, x2, y2);
    }
}
