using System.Collections.Generic;
using System.Numerics;
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

            RedBall redBall = new RedBall(200, 100, 70);
            
            BlueBall blueBall = new BlueBall(500, 500, 70);

            List<BouncingBall> bouncingBalls = CreateBouncingBalls(5);

            YoYoBall yoYoBall = new YoYoBall(new Vector2(100.0f, 100.0f), new Vector2(Width - 100, Height - 100), Color.BLACK, 16.0f, 48.0f, 6.0f);

            VectorBall vectorBall = new VectorBall(new Vector2(), 200.0f);
            
            //GAME LOOP
            while (!Raylib.WindowShouldClose())
            {
                //1. update
                
                //red ball update
                redBall.Update();

                //blue ball update
                blueBall.Update();
                
                //bouncing ball update
                foreach (var ball in bouncingBalls)
                {
                    ball.Update();
                }
                
                yoYoBall.Update();
                
                vectorBall.Update();

                //2. draw
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);
                Raylib.DrawText("FPS: " + Raylib.GetFPS().ToString(), 12, 30, 20, Color.BLACK);
                
                //line
                Raylib.DrawLine(redBall.CurX, redBall.CurY, blueBall.X, blueBall.Y, Color.GRAY);

                foreach (var ball in bouncingBalls)
                {
                    ball.DrawLineTo(redBall.CurX, redBall.CurY);
                }
                
                //blue ball draw
                blueBall.Draw();
                
                //red ball draw
                redBall.Draw();
                
                //bouncing ball draw
                foreach (var ball in bouncingBalls)
                {
                    ball.Draw();
                }
                
                yoYoBall.Draw();
                
                vectorBall.Draw();
                
                Raylib.EndDrawing();
            }

            //CLEANUP
            Raylib.CloseWindow();
        }


        private static List<BouncingBall> CreateBouncingBalls(int ballsCount)
        {
            List<BouncingBall> result = new List<BouncingBall>(ballsCount);

            for (int i = 0; i < ballsCount; i++)
            {
                float speed = Raylib.GetRandomValue(10, 200);
                float radius = Raylib.GetRandomValue(16, 64);
                Color color = Color.GREEN;

                var ball = new BouncingBall(speed, radius, color);

                result.Add(ball);
            }

            return result;
        }
    }
}