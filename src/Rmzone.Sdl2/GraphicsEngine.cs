using System;

namespace Rmzone.Sdl2;

public class GraphicsEngine
{
    protected Window Window { get; }
    protected Renderer Renderer { get; }

    private int _width;
    private int _height;
    private int _scale;
    private string _title;

    private const int WindowposUndefined =	0x1FFF0000;
    private const int WindowposCentered =	0x2FFF0000;

    /// <summary>
    ///
    /// </summary>
    /// <param name="title"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="scale"></param>
    /// <exception cref="Exception"></exception>
    protected GraphicsEngine(string title, int width, int height, int scale)
    {
        if (scale < 1)
        {
            throw new Exception("Scale must be >= 1");
        }

        _width = width;
        _height = height;
        _scale = scale;
        _title = title;

        var windowCi = new WindowCreateInfo
        {
            X = WindowposUndefined,
            Y = WindowposUndefined,
            WindowWidth = _width,
            WindowHeight = _height,
            WindowTitle = _title,
            WindowInitialState = WindowState.Normal
        };

        if (!Startup.Init(InitFlags.Everything))
        {
            throw new Exception("Unable to init systems");
        }

        Window = Startup.CreateWindow(ref windowCi);
        Renderer = Startup.CreateRenderer(Window, -1, RendererFlags.Accelerated | RendererFlags.TargetTexture);
        Renderer.RenderSetLogicalSize(_width/_scale, _height/_scale);
    }
}
