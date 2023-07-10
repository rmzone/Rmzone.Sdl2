using Rmzone.Sdl2.Internal;

namespace Rmzone.Sdl2;

public static class DrawingExtensions
{
    public static void DrawPixel(this Renderer renderer, Point pt)
    {
        Sdl2Native.SDL_RenderDrawPoint(renderer.Handle, pt.X, pt.Y);
    }

    public static void DrawLine(this Renderer renderer, Point pt1, Point pt2)
    {
        Sdl2Native.SDL_RenderDrawLine(renderer.Handle, pt1.X, pt1.Y, pt2.X, pt2.Y);
    }

    public static void FillRect(this Renderer renderer, Rectangle rect)
    {
        var box = new Sdl2Native.SDL_Rect {x = rect.X, y = rect.Y, w = rect.Width, h = rect.Height};
        Sdl2Native.SDL_RenderFillRect(renderer.Handle, ref box);
    }
}
