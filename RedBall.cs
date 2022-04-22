using System;
using Raylib_cs;

namespace RaylibTest01
{
    public class RedBall
    {
        private float _x;
        private float _y;
        
        private float _speed;

        private float _shift;
        private float _redBallShift;
        
        public int CurX => (int)_x + (int)_redBallShift;
        public int CurY => (int)_y;
        
        public RedBall(float x, float y, float speed)
        {
            _x = x;
            _y = y;
            _speed = speed;
        }

        public void Update()
        {
            //frame time: 0.01
            //speed: 10
            //delta: 10 * 0.01 = 0.1;
            //(int)delta = 0
            float delta = _speed * Raylib.GetFrameTime();
            
            _shift += delta;

            if (_shift >= 200.0f)
            {
                _shift = 0;
            }

            if (_shift < 100.0f)
            {
                _redBallShift = _shift;
            }
            else
            
            {
                _redBallShift = 100.0f - (_shift - 100.0f);
            }

        }

        public void Draw()
        {
            Raylib.DrawCircle(CurX, CurY, 32.0f, Color.RED);
        }
    }
}