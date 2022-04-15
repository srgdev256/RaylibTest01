using Raylib_cs;

namespace RaylibTest01
{
    static class Program
    {
        public static void Main()
        {
            Raylib.InitWindow(1280, 800, "Hello World");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}