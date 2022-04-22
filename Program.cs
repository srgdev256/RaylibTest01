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

            RedBall redBall = new RedBall(200, 100, 10);
            
            BlueBall blueBall = new BlueBall(500, 500, 10);
            
            //GAME LOOP
            while (!Raylib.WindowShouldClose())
            {
                //1. update
                
                //red ball update
                redBall.Update();

                //blue ball update
                blueBall.Update();
                
                
                //2. draw
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);
                Raylib.DrawText("FPS: " + Raylib.GetFPS().ToString(), 12, 30, 20, Color.BLACK);
                
                //line
                Raylib.DrawLine(redBall.CurX, redBall.CurY, blueBall.X, blueBall.Y, Color.GRAY);
                
                //blue ball draw
                blueBall.Draw();
                
                //red ball draw
                redBall.Draw();
                

                
                Raylib.EndDrawing();
            }

            //CLEANUP
            Raylib.CloseWindow();
        }
    }
}