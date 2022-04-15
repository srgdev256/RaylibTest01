using Raylib_cs;

namespace RaylibTest01
{
    public class BlueBall
    {
        private int _x;
        private int _y;

        private int _speed;
        
        public int X => _x;
        public int Y => _y;
        
        public BlueBall(int x, int y, int speed)
        {
            _x = x;
            _y = y;
            _speed = speed;
        }

        public void Update()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                _x -= _speed;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                _x += _speed;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                _y -= _speed;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                _y += _speed;
            }
        }

        public void Draw()
        {
            Raylib.DrawCircle(_x, _y, 48.0f, Color.BLUE);
        }
    }
}