using Raylib_cs;

namespace RaylibTest01
{
    public class BlueBall
    {
        private float _x;
        private float _y;

        private float _speed;

        public int X  => (int)_x;
        public int Y  => (int)_y;
        
        public BlueBall(float x, float y, float speed)
        {
            _x = x;
            _y = y;
            _speed = speed;
        }

        public void Update()
        {
            float delta = _speed * Raylib.GetFrameTime();
            
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                _x -= delta;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                _x += delta;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                _y -= delta;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                _y += delta;
            }
        }

        public void Draw()
        {
            Raylib.DrawCircle(X, Y, 48.0f, Color.BLUE);
        }
    }

    
}