using System;
using System.Runtime.InteropServices;
using Rmzone.Sdl2.Internal;

namespace Rmzone.Sdl2
{
    [Flags]
    public enum SDL_BlendMode
    {
        SDL_BLENDMODE_NONE =	0x00000000,
        SDL_BLENDMODE_BLEND =	0x00000001,
        SDL_BLENDMODE_ADD =	0x00000002,
        SDL_BLENDMODE_MOD =	0x00000004,
        SDL_BLENDMODE_INVALID =	0x7FFFFFFF
    }

    public class Texture
    {
        private readonly TexturePtr _texturePtr;
        private readonly Renderer _renderer;
        private readonly int _width;
        private readonly int _height;

        private readonly RgbaByte[] _buffer;

        private bool _isDirty = true;

        /// <summary>
        /// Returns a pointer to the created texture or NULL if no rendering context was active, the format
        /// was unsupported, or the width or height were out of range; call SDL_GetError() for more information.
        /// </summary>
        /// <param name="renderer">the rendering context</param>
        /// <param name="format">one of the enumerated values in SDL_PixelFormatEnum; see Remarks for details</param>
        /// <param name="access">one of the enumerated values in SDL_TextureAccess; see Remarks for details</param>
        /// <param name="w">the width of the texture in pixels</param>
        /// <param name="h">he height of the texture in pixels</param>
        public Texture(Renderer renderer, uint format, TextureAccess access, int w, int h)
        {
            _width = w;
            _height = h;
            _renderer = renderer;
            _texturePtr = Sdl2Native.SDL_CreateTexture(renderer.Handle, Sdl2Native.SDL_PIXELFORMAT_ABGR8888,  (int) access, w, h);
            _buffer = new RgbaByte[w*h];
            Sdl2Native.SDL_SetTextureBlendMode(_texturePtr, SDL_BlendMode.SDL_BLENDMODE_BLEND);
        }

        /// <summary>
        /// Create a texture from an image file
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="file"></param>
        public Texture(Renderer renderer, string file)
        {
            IntPtr newTexture = IntPtr.Zero;
            var loadedSurface = Sdl2Native.IMG_Load(file);

            if (loadedSurface == IntPtr.Zero)
            {
                Console.WriteLine("Unable to load image {0}! SDL Error: {1}", file, Sdl2Native.SDL_GetError());
            }
            else
            {
                var s = Marshal.PtrToStructure<Sdl2Native.SDL_Surface>(loadedSurface);

                // color key image
//                Sdl2Native.SDL_SetColorKey(loadedSurface, (int)Sdl2Native.SDL_bool.SDL_TRUE, Sdl2Native.SDL_MapRGB(s.format, 0, 0xFF, 0xFF));

                // create texture from surface pixels
                newTexture = Sdl2Native.SDL_CreateTextureFromSurface(renderer.Handle, loadedSurface);
                if (newTexture == IntPtr.Zero)
                {
                    Console.WriteLine("Unable to create texture from {0}! SDL Error: {1}", file, Sdl2Native.SDL_GetError());
                }
                else
                {
                    //Get image dimensions
                    _width = s.w;
                    _height = s.h;
                }

                //Get rid of old loaded surface
                Sdl2Native.SDL_FreeSurface(loadedSurface);
            }

            _texturePtr = newTexture;
            _renderer = renderer;
        }

        private TexturePtr Handle => _texturePtr;

        public RgbaByte[] Buffer => _buffer;

        public void Destroy()
        {
            // TODO: Should this be done with an IDispose pattern?
            // SDL_DestroyTexture
        }

        /// <summary>
        /// Renders texture at given point
        /// </summary>
        public void Render(int x, int y, int w, int h)
        {
            Update(new Rectangle(), _buffer, _width * 4);

            var renderQuad = new Sdl2Native.SDL_Rect {x = x, y = y, w = w, h = h};
            var result = Sdl2Native.SDL_RenderCopy(_renderer.Handle, Handle, IntPtr.Zero, ref renderQuad);
            if (result != 0)
            {
                throw new Exception($"SDL Error: {Sdl2Native.SDL_GetError()}");
            }
        }

        public void Render(Rectangle src, Rectangle dst, RgbaByte color)
        {
            Update(new Rectangle(), _buffer, _width * 4);

            var srcrect = new Sdl2Native.SDL_Rect {x = src.X, y = src.Y, w = src.Width, h = src.Height};
            var dstrect = new Sdl2Native.SDL_Rect {x = dst.X, y = dst.Y, w = dst.Width, h = dst.Height};

            Sdl2Native.SDL_SetTextureColorMod(Handle, color.R, color.G, color.B);
            var result = Sdl2Native.SDL_RenderCopy(_renderer.Handle, Handle, ref srcrect, ref dstrect);
            if (result != 0)
            {
                throw new Exception($"SDL Error: {Sdl2Native.SDL_GetError()}");
            }
        }

        public void SetPixel(int x, int y, RgbaByte color)
        {
            // clip first
            if (x < 0 || x >= _width || y < 0 || y >= _height) return;

            _buffer[x + y * _width] = color;
            _isDirty = true;
        }

        public enum TextureAccess : uint
        {
            Static = 0,
            Streaming = 1,
            Target = 2
        }

        public void FillRect(int x, int y, int w, int h, RgbaByte color)
        {
            var x2 = x + w;
            var y2 = y + h;

            for (int i = x; i < x2; i++)
            for (int j = y; j < y2; j++)
                SetPixel(i, j, color);
        }

        public void DrawRect(int x, int y, int w, int h, RgbaByte color)
        {
            DrawLine(x, y, x+w, y, color);
            DrawLine(x+w, y, x+w, y+h, color);
            DrawLine(x+w, y+h, x, y+h, color);
            DrawLine(x, y+h, x, y, color);
        }

        public void DrawLine(int x1, int y1, int x2, int y2, RgbaByte color)
        {
            var dx = x2 - x1;
            var dy = y2 - y1;

            // vertical line
            if (dx == 0)
            {
                if (y2 < y1) Swap(ref y1, ref y2);

                for (var y = y1; y <= y2; y++)
                {
                    SetPixel(x1, y, color);
                }

                return;
            }

            // horizontal line
            if (dy == 0)
            {
                if (x2 < x1) Swap(ref x1, ref x2);

                for (var x = x1; x <= x2; x++)
                {
                    SetPixel(x, y1, color);
                }

                return;
            }

            // todo: linear line not aligned with the axis
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Use this function to update the given texture rectangle with new pixel data.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="pixels"></param>
        /// <param name="pitch"></param>
        private unsafe void Update(Rectangle rect, RgbaByte[] pixels, int pitch)
        {
            if (!_isDirty) return;

            fixed (RgbaByte* mPixelsPtr = &pixels[0])
            {
                var result = Sdl2Native.SDL_UpdateTexture(_texturePtr, IntPtr.Zero, (IntPtr)mPixelsPtr, pitch);

                if (result != 0)
                {
                    throw new Exception($"SDL Error: {Sdl2Native.SDL_GetError()}");
                }
            }

            _isDirty = false;
        }
    }
}
