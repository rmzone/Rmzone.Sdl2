namespace Rmzone.Sdl2
{
    public readonly struct MouseEvent
    {
        public MouseButton MouseButton { get; }
        public bool Down { get; }

        public MouseEvent(MouseButton button, bool down)
        {
            MouseButton = button;
            Down = down;
        }
    }

    public enum MouseButton
    {
        /// <summary>
        /// The left mouse button.
        /// </summary>
        Left = 0,
        /// <summary>
        /// The middle mouse button.
        /// </summary>
        Middle = 1,
        /// <summary>
        /// The right mouse button.
        /// </summary>
        Right = 2,
        /// <summary>
        /// The first extra mouse button.
        /// </summary>
        Button1 = 3,
        /// <summary>
        /// The second extra mouse button.
        /// </summary>
        Button2 = 4,
        /// <summary>
        /// The third extra mouse button.
        /// </summary>
        Button3 = 5,
        /// <summary>
        /// The fourth extra mouse button.
        /// </summary>
        Button4 = 6,
        /// <summary>
        /// The fifth extra mouse button.
        /// </summary>
        Button5 = 7,
        /// <summary>
        /// The sixth extra mouse button.
        /// </summary>
        Button6 = 8,
        /// <summary>
        /// The seventh extra mouse button.
        /// </summary>
        Button7 = 9,
        /// <summary>
        /// The eigth extra mouse button.
        /// </summary>
        Button8 = 10,
        /// <summary>
        /// The ninth extra mouse button.
        /// </summary>
        Button9 = 11,
        /// <summary>
        /// Indicates the last available mouse button.
        /// </summary>
        LastButton = 12
    }
}
