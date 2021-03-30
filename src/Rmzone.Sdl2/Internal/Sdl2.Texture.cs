using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming

namespace Rmzone.Sdl2.Internal
{
	public static partial class Sdl2Native
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate TexturePtr SDL_CreateTexture_t(RendererPtr renderer, uint format, int access, int w, int h);
        private static readonly SDL_CreateTexture_t s_sdl_create_texture = LoadFunction<SDL_CreateTexture_t>("SDL_CreateTexture");
        public static TexturePtr SDL_CreateTexture(RendererPtr renderer, uint format, int access, int w, int h)
	        => s_sdl_create_texture(renderer, format, access, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate TexturePtr SDL_CreateTextureFromSurface_t(RendererPtr renderer, SurfacePtr surface);
        private static readonly SDL_CreateTextureFromSurface_t s_sdl_create_texture_from_surface = LoadFunction<SDL_CreateTextureFromSurface_t>("SDL_CreateTextureFromSurface");
        public static TexturePtr SDL_CreateTextureFromSurface(RendererPtr renderer, SurfacePtr surface)
	        => s_sdl_create_texture_from_surface(renderer, surface);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_UpdateTexture_t(TexturePtr texture, RectanglePtr rect, IntPtr pixels, int pitch);
        private static readonly SDL_UpdateTexture_t s_sdl_update_texture = LoadFunction<SDL_UpdateTexture_t>("SDL_UpdateTexture");
        public static int SDL_UpdateTexture(TexturePtr texture, RectanglePtr rect, IntPtr pixels, int pitch) => s_sdl_update_texture(texture, rect, pixels, pitch);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetTextureBlendMode_t(TexturePtr texture, SDL_BlendMode blendMode);
        private static readonly SDL_SetTextureBlendMode_t s_sdl_set_textureblendmode = LoadFunction<SDL_SetTextureBlendMode_t>("SDL_SetTextureBlendMode");
        public static int SDL_SetTextureBlendMode(TexturePtr texture, SDL_BlendMode blendMode) => s_sdl_set_textureblendmode(texture, blendMode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetTextureColorMod_t(TexturePtr texture, byte r, byte g, byte b);
        private static readonly SDL_SetTextureColorMod_t s_sdl_set_texturecolormod = LoadFunction<SDL_SetTextureColorMod_t>("SDL_SetTextureColorMod");
        public static int SDL_SetTextureColorMod(TexturePtr texture, byte r, byte g, byte b) => s_sdl_set_texturecolormod(texture, r, g, b);

//        SDL_LockTexture

//	    SDL_UnlockTexture

        // Pixel stuff TODO: move to public and rename methods
        public static uint SDL_DEFINE_PIXELFORMAT(
			SDL_PIXELTYPE_ENUM type,
			SDL_PIXELORDER_ENUM order,
			SDL_PACKEDLAYOUT_ENUM layout,
			byte bits,
			byte bytes
		) {
			return (uint) (
				(1 << 28) |
				(((byte) type) << 24) |
				(((byte) order) << 20) |
				(((byte) layout) << 16) |
				(bits << 8) |
				(bytes)
			);
		}

		public static byte SDL_PIXELFLAG(uint X)
		{
			return (byte) ((X >> 28) & 0x0F);
		}

		public static byte SDL_PIXELTYPE(uint X)
		{
			return (byte) ((X >> 24) & 0x0F);
		}

		public static byte SDL_PIXELORDER(uint X)
		{
			return (byte) ((X >> 20) & 0x0F);
		}

		public static byte SDL_PIXELLAYOUT(uint X)
		{
			return (byte) ((X >> 16) & 0x0F);
		}

		public static byte SDL_BITSPERPIXEL(uint X)
		{
			return (byte) ((X >> 8) & 0xFF);
		}

//		public static byte SDL_BYTESPERPIXEL(uint X)
//		{
//			if (SDL_ISPIXELFORMAT_FOURCC(X))
//			{
//				if (	(X == SDL_PIXELFORMAT_YUY2) ||
//						(X == SDL_PIXELFORMAT_UYVY) ||
//						(X == SDL_PIXELFORMAT_YVYU)	)
//				{
//					return 2;
//				}
//				return 1;
//			}
//			return (byte) (X & 0xFF);
//		}

		public static bool SDL_ISPIXELFORMAT_INDEXED(uint format)
		{
			if (SDL_ISPIXELFORMAT_FOURCC(format))
			{
				return false;
			}
			SDL_PIXELTYPE_ENUM pType =
					(SDL_PIXELTYPE_ENUM) SDL_PIXELTYPE(format);
			return (
				pType == SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1 ||
				pType == SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX4 ||
				pType == SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX8
			);
		}

		public static bool SDL_ISPIXELFORMAT_ALPHA(uint format)
		{
			if (SDL_ISPIXELFORMAT_FOURCC(format))
			{
				return false;
			}
			SDL_PIXELORDER_ENUM pOrder =
					(SDL_PIXELORDER_ENUM) SDL_PIXELORDER(format);
			return (
				pOrder == SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB ||
				pOrder == SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA ||
				pOrder == SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR ||
				pOrder == SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA
			);
		}

		public static bool SDL_ISPIXELFORMAT_FOURCC(uint format)
		{
			return (format == 0) && (SDL_PIXELFLAG(format) != 1);
		}

		public enum SDL_PIXELTYPE_ENUM
		{
			SDL_PIXELTYPE_UNKNOWN,
			SDL_PIXELTYPE_INDEX1,
			SDL_PIXELTYPE_INDEX4,
			SDL_PIXELTYPE_INDEX8,
			SDL_PIXELTYPE_PACKED8,
			SDL_PIXELTYPE_PACKED16,
			SDL_PIXELTYPE_PACKED32,
			SDL_PIXELTYPE_ARRAYU8,
			SDL_PIXELTYPE_ARRAYU16,
			SDL_PIXELTYPE_ARRAYU32,
			SDL_PIXELTYPE_ARRAYF16,
			SDL_PIXELTYPE_ARRAYF32
		}

		public enum SDL_PIXELORDER_ENUM
		{
			/* BITMAPORDER */
			SDL_BITMAPORDER_NONE,
			SDL_BITMAPORDER_4321,
			SDL_BITMAPORDER_1234,
			/* PACKEDORDER */
			SDL_PACKEDORDER_NONE = 0,
			SDL_PACKEDORDER_XRGB,
			SDL_PACKEDORDER_RGBX,
			SDL_PACKEDORDER_ARGB,
			SDL_PACKEDORDER_RGBA,
			SDL_PACKEDORDER_XBGR,
			SDL_PACKEDORDER_BGRX,
			SDL_PACKEDORDER_ABGR,
			SDL_PACKEDORDER_BGRA,
			/* ARRAYORDER */
			SDL_ARRAYORDER_NONE = 0,
			SDL_ARRAYORDER_RGB,
			SDL_ARRAYORDER_RGBA,
			SDL_ARRAYORDER_ARGB,
			SDL_ARRAYORDER_BGR,
			SDL_ARRAYORDER_BGRA,
			SDL_ARRAYORDER_ABGR
		}

		public enum SDL_PACKEDLAYOUT_ENUM
		{
			SDL_PACKEDLAYOUT_NONE,
			SDL_PACKEDLAYOUT_332,
			SDL_PACKEDLAYOUT_4444,
			SDL_PACKEDLAYOUT_1555,
			SDL_PACKEDLAYOUT_5551,
			SDL_PACKEDLAYOUT_565,
			SDL_PACKEDLAYOUT_8888,
			SDL_PACKEDLAYOUT_2101010,
			SDL_PACKEDLAYOUT_1010102
		}

		public static readonly uint SDL_PIXELFORMAT_UNKNOWN = 0;
		public static readonly uint SDL_PIXELFORMAT_INDEX1LSB =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1,
				SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321,
				0,
				1, 0
			);
		public static readonly uint SDL_PIXELFORMAT_INDEX1MSB =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1,
				SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_1234,
				0,
				1, 0
			);
		public static readonly uint SDL_PIXELFORMAT_INDEX4LSB =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX4,
				SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321,
				0,
				4, 0
			);
		public static readonly uint SDL_PIXELFORMAT_INDEX4MSB =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX4,
				SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_1234,
				0,
				4, 0
			);
		public static readonly uint SDL_PIXELFORMAT_INDEX8 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX8,
				0,
				0,
				8, 1
			);
		public static readonly uint SDL_PIXELFORMAT_RGB332 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED8,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XRGB,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_332,
				8, 1
			);
		public static readonly uint SDL_PIXELFORMAT_RGB444 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XRGB,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444,
				12, 2
			);
		public static readonly uint SDL_PIXELFORMAT_RGB555 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XRGB,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555,
				15, 2
			);
		public static readonly uint SDL_PIXELFORMAT_BGR555 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1,
				SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555,
				15, 2
			);
		public static readonly uint SDL_PIXELFORMAT_ARGB4444 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444,
				16, 2
			);
		public static readonly uint SDL_PIXELFORMAT_RGBA4444 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444,
				16, 2
			);
		public static readonly uint SDL_PIXELFORMAT_ABGR4444 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444,
				16, 2
			);
		public static readonly uint SDL_PIXELFORMAT_BGRA4444 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444,
				16, 2
			);
		public static readonly uint SDL_PIXELFORMAT_ARGB1555 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555,
				16, 2
			);
		public static readonly uint SDL_PIXELFORMAT_RGBA5551 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_5551,
				16, 2
			);
		public static readonly uint SDL_PIXELFORMAT_ABGR1555 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555,
				16, 2
			);
		public static readonly uint SDL_PIXELFORMAT_BGRA5551 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_5551,
				16, 2
			);
		public static readonly uint SDL_PIXELFORMAT_RGB565 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XRGB,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_565,
				16, 2
			);
		public static readonly uint SDL_PIXELFORMAT_BGR565 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XBGR,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_565,
				16, 2
			);
		public static readonly uint SDL_PIXELFORMAT_RGB24 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_ARRAYU8,
				SDL_PIXELORDER_ENUM.SDL_ARRAYORDER_RGB,
				0,
				24, 3
			);
		public static readonly uint SDL_PIXELFORMAT_BGR24 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_ARRAYU8,
				SDL_PIXELORDER_ENUM.SDL_ARRAYORDER_BGR,
				0,
				24, 3
			);
		public static readonly uint SDL_PIXELFORMAT_RGB888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XRGB,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
				24, 4
			);
		public static readonly uint SDL_PIXELFORMAT_RGBX8888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBX,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
				24, 4
			);
		public static readonly uint SDL_PIXELFORMAT_BGR888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XBGR,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
				24, 4
			);
		public static readonly uint SDL_PIXELFORMAT_BGRX8888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRX,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
				24, 4
			);
		public static readonly uint SDL_PIXELFORMAT_ARGB8888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
				32, 4
			);
		public static readonly uint SDL_PIXELFORMAT_RGBA8888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
				32, 4
			);
		public static readonly uint SDL_PIXELFORMAT_ABGR8888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
				32, 4
			);
		public static readonly uint SDL_PIXELFORMAT_BGRA8888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888,
				32, 4
			);
		public static readonly uint SDL_PIXELFORMAT_ARGB2101010 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32,
				SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB,
				SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_2101010,
				32, 4
			);
//		public static readonly uint SDL_PIXELFORMAT_YV12 =
//			SDL_DEFINE_PIXELFOURCC(
//				(byte) 'Y', (byte) 'V', (byte) '1', (byte) '2'
//			);
//		public static readonly uint SDL_PIXELFORMAT_IYUV =
//			SDL_DEFINE_PIXELFOURCC(
//				(byte) 'I', (byte) 'Y', (byte) 'U', (byte) 'V'
//			);
//		public static readonly uint SDL_PIXELFORMAT_YUY2 =
//			SDL_DEFINE_PIXELFOURCC(
//				(byte) 'Y', (byte) 'U', (byte) 'Y', (byte) '2'
//			);
//		public static readonly uint SDL_PIXELFORMAT_UYVY =
//			SDL_DEFINE_PIXELFOURCC(
//				(byte) 'U', (byte) 'Y', (byte) 'V', (byte) 'Y'
//			);
//		public static readonly uint SDL_PIXELFORMAT_YVYU =
//			SDL_DEFINE_PIXELFOURCC(
//				(byte) 'Y', (byte) 'V', (byte) 'Y', (byte) 'U'
//			);


    }
}
