using System;
using Raylib_cs;

namespace RaylibTest01
{
    public class BouncingBall
    {
        private float _x;
        private float _y;

        private float _speed;
        private float _radius;

        private Direction _direction;
        
        private Color _color;

        public int CurX => (int) _x;
        public int CurY => (int) _y;


        public BouncingBall(float x, float y, float speed, float radius, Color color)
        {
            _x = x;
            _y = y;
            _speed = speed;
            _radius = radius;
            _color = color;
            
            _direction = DirectionUtils.GetRandomDiagonalDirection();
        }

        public void Update()
        {
            float delta = _speed * Raylib.GetFrameTime();

            const float screenMinX = 0.0f;
            const float screenMaxX = Program.Width;
            const float screenMinY = 0.0f;
            const float screenMaxY = Program.Height;
            

            //wall collisions

            //up wall
            if (CurY - _radius <= screenMinY)
            {
                if (_direction == Direction.UpRight)
                { 
                    _direction = Direction.DownRight;
                }
                else
                {
                    _direction = Direction.DownLeft;
                }
            }

            //right wall
            if (CurX + _radius >= screenMaxX)
            {
                if (_direction == Direction.UpRight)
                {
                    _direction = Direction.UpLeft;
                }
                else
                {
                    _direction = Direction.DownLeft;
                }
            }

            //down wall
            if (CurY + _radius >= screenMaxY)
            {
                if (_direction == Direction.DownLeft)
                { 
                    _direction = Direction.UpLeft;
                }
                else
                {
                    _direction = Direction.UpRight;
                }
            }

            //left wall
            if (CurX - _radius <= screenMinX)
            {
                if (_direction == Direction.UpLeft)
                {
                    _direction = Direction.UpRight;
                }
                else
                { 
                    _direction = Direction.DownRight;
                }
            }

            //moving
            switch (_direction)
            {
                case Direction.UpRight:
                    _x += delta;
                    _y -= delta;
                    break;


                case Direction.UpLeft:
                    _x -= delta;
                    _y -= delta;
                    break;


                case Direction.DownLeft:
                    _x -= delta;
                    _y += delta;
                    break;


                case Direction.DownRight:
                {
                    _x += delta;
                    _y += delta;
                    break;
                }
            }

        }
        

        public void Draw()
        {
            Raylib.DrawCircle((int) _x, (int) _y, _radius, _color);
        }
    }
}    