using Raylib_cs;

namespace RaylibTest01
{
    public class BouncingBall
    {
        private float _x;
        private float _y;
        
        private float _speed;
        private float _radius;

        private Color _color;
        
        public int CurX => (int)_x;
        public int CurY => (int)_y;
        
        
        public BouncingBall(float x, float y, float speed,float radius, Color color)
        {
            _x = x;
            _y = y;
            _speed = speed;
            _radius = radius;
            _color = color;
        }

        public void Update()
        {
            
        }
        
        public void Draw()
        {
            Raylib.DrawCircle(CurX, CurY, _radius, _color);
        }
    }
}