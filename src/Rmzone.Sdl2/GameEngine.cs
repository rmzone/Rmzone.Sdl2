using System;

namespace Rmzone.Sdl2
{
    public abstract class GameEngine // : IDisposable
    {
        #region Fields

        private readonly Window _window;
        private readonly Renderer _renderer;

        private bool _quit;

        #endregion

        #region Properties

        protected Renderer Renderer => _renderer;

        #endregion

        #region Constructor

        protected GameEngine(string title, int width, int height)
        {
            var windowCi = new WindowCreateInfo
            {
                X = Startup.WindowposUndefined,
                Y = Startup.WindowposUndefined,
                WindowWidth = width,
                WindowHeight = height,
                WindowTitle = title,
                WindowInitialState = WindowState.Normal
            };

            if (!Startup.Init(InitFlags.Everything))
            {
                throw new Exception("Unable to init systems");
            }

            _window = Startup.CreateWindow(ref windowCi);
            _renderer = Startup.CreateRenderer(_window, -1, RendererFlags.Accelerated | RendererFlags.TargetTexture);
            _renderer.RenderSetLogicalSize(width, height);
        }

        #endregion

        #region Methods

        public void Run()
        {
            OnCreate();
            
            while (!_quit)
            {
                if (!_window.Exists) continue;
                HandleEvents();
                OnUpdate(1.0f); // todo: add delta between last call
            }

            OnDestroy();
            Startup.Quit();
        }

        protected virtual void OnCreate() {}
        protected abstract void OnUpdate(float delta);
        protected virtual void OnDestroy() {}
        
        private void HandleEvents()
        {
            if (!_window.Exists) return;
            var snapshot = _window.PumpEvents();
            InputTracker.UpdateFrameInput(snapshot);
            
            if (InputTracker.GetKeyDown(Key.Escape))
            {
                _quit = true;
            }
        }

        #endregion
    }
}
