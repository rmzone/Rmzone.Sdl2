using Rmzone.Sdl2;

namespace Rmzone.SdlTestApp
{
    public class TestApp : GraphicsEngine
    {
        private const int Scale = 1;
        public TestApp(string title, int width, int height)
            : base(title, width, height, Scale) { }

        protected void OnUpdate(float delta)
        {
            Draw();
        }

        private void Draw()
        {
            Renderer.SetDrawColor(0, 70, 70, 255);
            Renderer.Clear();

            Renderer.SetDrawColor(RgbaByte.Pink);

            for (var x = 0; x < 100; x++)
            {
                Renderer.DrawPixel(new Point(x, 10));
            }

            Renderer.SetDrawColor(RgbaByte.Green);
            Renderer.FillRect(new Rectangle(50, 50, 100, 100));

            Renderer.SetDrawColor(RgbaByte.Orange);
            Renderer.DrawLine(new Point(50, 50), new Point(200, 200));
            Renderer.DrawLine(new Point(50, 200), new Point(200, 50));

            Renderer.Render();
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}
