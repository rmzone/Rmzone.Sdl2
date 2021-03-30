using System.Text;

namespace Rmzone.Sdl2
{
    internal static class Utilities
    {
        public static unsafe string GetString(byte* stringStart)
        {
            var characters = 0;
            while (stringStart[characters] != 0)
            {
                characters++;
            }

            return Encoding.UTF8.GetString(stringStart, characters);
        }

        public static byte[] UTF8_ToNative(string s)
        {
            return s == null ? null : Encoding.UTF8.GetBytes(s + '\0');
        }
    }
}
