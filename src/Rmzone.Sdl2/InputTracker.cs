using System.Collections.Generic;
using System.Numerics;

namespace Rmzone.Sdl2
{
    public static class InputTracker
    {
        private static readonly HashSet<Key> CurrentlyPressedKeys = new HashSet<Key>();
        private static readonly HashSet<Key> NewKeysThisFrame = new HashSet<Key>();

        private static readonly HashSet<MouseButton> CurrentlyPressedMouseButtons = new HashSet<MouseButton>();
        private static readonly HashSet<MouseButton> NewMouseButtonsThisFrame = new HashSet<MouseButton>();

        public static Vector2 MousePosition;
        public static InputSnapshot FrameSnapshot { get; private set; }

        public static bool GetKey(Key key)
        {
            return CurrentlyPressedKeys.Contains(key);
        }

        public static bool GetKeyDown(Key key)
        {
            return NewKeysThisFrame.Contains(key);
        }

        public static bool GetMouseButton(MouseButton button)
        {
            return CurrentlyPressedMouseButtons.Contains(button);
        }

        public static bool GetMouseButtonDown(MouseButton button)
        {
            return NewMouseButtonsThisFrame.Contains(button);
        }

        public static void UpdateFrameInput(InputSnapshot snapshot)
        {
            FrameSnapshot = snapshot;
            NewKeysThisFrame.Clear();
            NewMouseButtonsThisFrame.Clear();

            MousePosition = snapshot.MousePosition;

            foreach (var ke in snapshot.KeyEvents)
            {
                if (ke.Down)
                {
                    KeyDown(ke);
                }
                else
                {
                    KeyUp(ke);
                }
            }

            foreach (var me in snapshot.MouseEvents)
            {
                if (me.Down)
                {
                    MouseDown(me.MouseButton);
                }
                else
                {
                    MouseUp(me.MouseButton);
                }
            }
        }

        private static void MouseUp(MouseButton mouseButton)
        {
            CurrentlyPressedMouseButtons.Remove(mouseButton);
            NewMouseButtonsThisFrame.Remove(mouseButton);
        }

        private static void MouseDown(MouseButton mouseButton)
        {
            if (CurrentlyPressedMouseButtons.Add(mouseButton))
            {
                NewMouseButtonsThisFrame.Add(mouseButton);
            }
        }

        private static void KeyUp(KeyEvent ke)
        {
            RawKey = (char)0;
            CurrentlyPressedKeys.Remove(ke.Key);
            NewKeysThisFrame.Remove(ke.Key);
        }

        public static char RawKey { get; private set; }

        private static void KeyDown(KeyEvent ke)
        {
            RawKey = ke.Raw;

            if (CurrentlyPressedKeys.Add(ke.Key))
            {
                NewKeysThisFrame.Add(ke.Key);
            }
        }
    }
}
