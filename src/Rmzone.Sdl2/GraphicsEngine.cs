using System;

namespace Rmzone.Sdl2
{
    public class GraphicsEngine
    {
        protected readonly Window _window;
        protected readonly Renderer _renderer;

        private int _width;
        private int _height;
        private int _scale;
        private string _title;

        private const int WindowposUndefined =	0x1FFF0000;
        private const int WindowposCentered =	0x2FFF0000;

        /// <summary>
        ///
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="scale"></param>
        /// <param name="title"></param>
        /// <exception cref="Exception"></exception>
        protected GraphicsEngine(int width, int height, int scale, string title)
        {
            if (scale < 1)
            {
                throw new Exception("Scale must be >= 1");
            }

            _width = width;
            _height = height;
            _scale = scale;
            _title = title;

            var windowCi = new WindowCreateInfo()
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

            _window = Startup.CreateWindow(ref windowCi);
            _renderer = Startup.CreateRenderer(_window, -1, RendererFlags.Accelerated | RendererFlags.TargetTexture);
            _renderer.RenderSetLogicalSize(_width/_scale, _height/_scale);
        }

        // private readonly List<GameControllerPtr> _gameControllers = new List<GameControllerPtr>();

        // protected void SetupGamepads()
        // {
        //     for (var i = 0; i< Sdl2Native.SDL_NumJoysticks(); i++ )
        //     {
        //         if (Sdl2Native.SDL_IsGameController(i))
        //         {
        //             var controller = Sdl2Native.SDL_GameControllerOpen(i);
        //             if (controller == IntPtr.Zero)
        //             {
        //                 Console.WriteLine("Could not open gamecontroller {0}: {1}", i, Sdl2Native.SDL_GetError());
        //                 break;
        //             }
        //
        //             _gameControllers.Add(controller);
        //         }
        //     }
        // }

        // protected void ShutDownGamepads()
        // {
        //     foreach (var pad in _gameControllers)
        //     {
        //         Sdl2Native.SDL_GameControllerClose(pad);
        //     }
        // }

        // void AddController( int id )
        // {
        //     if( SDL_IsGameController( id ) ) {
        //         SDL_GameController *pad = SDL_GameControllerOpen( id );
        //
        //         if( pad ) {
        //             SDL_Joystick *joy = SDL_GameControllerGetJoystick( pad );
        //             int instanceID = SDL_JoystickInstanceID( joy );
        //
        //             // You can add to your own map of joystick IDs to controllers here.
        //             YOUR_FUNCTION_THAT_CREATES_A_MAPPING( id, pad );
        //         }
        //     }
        // }
        //
        // void RemoveController( int id )
        // {
        //     SDL_GameController *pad = YOUR_FUNCTION_THAT_RETRIEVES_A_MAPPING( id );
        //     SDL_GameControllerClose( pad );
        // }
        //
        // void OnControllerButton( const SDL_ControllerButtonEvent sdlEvent )
        // {
        //     // Button presses and axis movements both sent here as SDL_ControllerButtonEvent structures
        // }
        //
        // void OnControllerAxis( const SDL_ControllerAxisEvent sdlEvent )
        // {
        //     // Axis movements and button presses both sent here as SDL_ControllerAxisEvent structures
        // }
    }
}
