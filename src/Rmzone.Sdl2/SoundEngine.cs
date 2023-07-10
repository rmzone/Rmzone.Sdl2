using System;
using Rmzone.Sdl2.Internal;

namespace Rmzone.Sdl2
{
    public class SoundEngine<T> where T : unmanaged
    {
        #region Fields

        private readonly uint _deviceId;
        private readonly Action<T[], int> _userCallback;
        private readonly Sdl2Native.SDL_AudioSpec _srec;
        private readonly Sdl2Native.SDL_AudioSpec _arec;

        private readonly object _queueLock = new object();

        #endregion

        #region Constructor

        public SoundEngine(int frequency, int channels, int samples, Action<T[], int> callback)
        {
            _userCallback = callback;
            _srec.freq = frequency;
            _srec.format = GetAudioFormat();
            _srec.channels = (byte)channels;
            _srec.samples = (ushort)samples;
            _srec.userdata = new IntPtr();
            _srec.callback = AudioCallback;

            _deviceId = Sdl2Native.SDL_OpenAudioDevice(null, 0, ref _srec, out _arec, Convert.ToInt16(Sdl2Native.SDL_AUDIO_ALLOW_ANY_CHANGE));
            if (_deviceId ==0)
            {
                throw new Exception(Sdl2Native.SDL_GetError());
            }
        }

        private static ushort GetAudioFormat()
        {
            var type = typeof(T).FullName;
            switch (type)
            {
                case "System.Byte":
                    return Sdl2Native.AUDIO_U8;

                case "System.Single": // aka `float`
                    return Sdl2Native.AUDIO_F32SYS;

                // see https://wiki.libsdl.org/SDL2/SDL_AudioSpec for other formats

                default:
                    throw new NotSupportedException($"Type {type} not supported as a valid audio format");
            }
        }

        #endregion

        #region Methods

        public void Start()
        {
            Sdl2Native.SDL_PauseAudioDevice(_deviceId, 0);
        }

        public void Stop()
        {
            Sdl2Native.SDL_PauseAudioDevice(_deviceId, 1);
        }

        public void Quit()
        {
            Sdl2Native.SDL_CloseAudioDevice(_deviceId);
        }

        unsafe void AudioCallback(IntPtr userdata, IntPtr stream, int len)
        {
            len /= sizeof(T);
            var streamPtr = (T*)stream;

            if (streamPtr == null)
            {
                throw new Exception("Null pointer!");
            }

            lock (_queueLock)
            {
                var data = new T[len];
                _userCallback(data, len);

                for (var i = 0; i < len; i++)
                {
                    streamPtr[i] = data[i];
                }
            }
        }

        #endregion
    }
}
