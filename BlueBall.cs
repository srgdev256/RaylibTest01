using System.Numerics;
using Raylib_cs;

namespace RaylibTest01
{
    public class BlueBall
    {
        private Vector2 _position;

        private float _speed;

        public int X  => (int)_position.X;
        public int Y  => (int)_position.Y;
        
        public BlueBall(float x, float y, float speed)
        {
            _position = new Vector2(x, y);
            _position.X = x;
            _position.Y= y;
            _speed = speed;
        }

        public void Update()
        {
            float delta = _speed * Raylib.GetFrameTime();
            
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                _position.X -= delta;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                _position.X += delta;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                _position.Y -= delta;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                _position.Y += delta;
            }
        }

        public void Draw()
        {
            Raylib.DrawCircle(X, Y, 48.0f, Color.BLUE);
        }
    }

    
}