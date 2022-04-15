using Raylib_cs;

namespace RaylibTest01
{
    static class Program
    {
        public const int Width = 1280;
        public const int Height = 800;
        
        public static void Main()
        {
            //INIT
            Raylib.SetConfigFlags(ConfigFlags.FLAG_VSYNC_HINT);
            Raylib.InitWindow(Width, Height, "Hello World");

            
            int shift = 0;
            int redBallShift;

            BlueBall blueBall = new BlueBall(500, 500, 3);
            
            //GAME LOOP
            while (!Raylib.WindowShouldClose())
            {
                //1. update
                
                //red ball update
                shift += 1;

                if (shift == 200)
                {
                    shift = 0;
                }

                if (shift < 100)
                {
                    redBallShift = shift;
                }
                else
                {
                    redBallShift = 100 - (shift - 100);
                }

                //blue ball update
                blueBall.Update();
                
                
                //2. draw
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);

                //line
                Raylib.DrawLine(200 + redBallShift, 100, blueBall.X, blueBall.Y, Color.GRAY);
                
                //blue ball draw
                blueBall.Draw();
                
                //red ball draw
                Raylib.DrawCircle(200 + redBallShift, 100, 32.0f, Color.RED);
                

                
                Raylib.EndDrawing();
            }

            //CLEANUP
            Raylib.CloseWindow();
        }
    }
}