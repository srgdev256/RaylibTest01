using System;
using System.Numerics;
using Raylib_cs;

namespace RaylibTest01
{
    public class RedBall
    {
        private Vector2 _position;
        
        private float _speed;

        private float _shift;
        private float _redBallShift;
        
        public int CurX => (int)_position.X + (int)_redBallShift;
        public int CurY => (int)_position.Y;
        
        public RedBall(float x, float y, float speed)
        {
            _position = new Vector2(x, y);
            _position.X = x;
            _position.Y = y;
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