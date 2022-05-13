using System;
using System.Numerics;
using Raylib_cs;

namespace RaylibTest01
{
    public class BouncingBall
    {
        private Vector2 _position;

        private float _speed;
        private float _radius;

        private Direction _direction;
        
        private Color _color;

        private bool _isDead;

        public int CurX => (int) _position.X;
        public int CurY => (int) _position.Y;


        public BouncingBall(float x, float y, float speed, float radius, Color color)
        {
            _position = new Vector2(x, y);
            _speed = speed;
            _radius = radius;
            _color = color;
            _isDead = false;
            
            _direction = DirectionUtils.GetRandomDiagonalDirection();
        }

        public BouncingBall(float speed, float radius, Color color):this(GetRandomX((int)radius), GetRandomY((int)radius), speed, radius, color)
        {
          
        }

        private static int GetRandomX(int radius)
        {
            return Raylib.GetRandomValue((int)0.0f + radius, Program.Width - radius);
        }
        
        private static int GetRandomY(int radius)
        {
            return Raylib.GetRandomValue((int)0.0f + radius, Program.Height - radius);
        }       
        

        public void Update()
        {
            if (_isDead)
            {
                return;
            }
            
            float delta = _speed * Raylib.GetFrameTime();

            const float screenMinX = 0.0f;
            const float screenMaxX = Program.Width;
            const float screenMinY = 0.0f;
            const float screenMaxY = Program.Height;

            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                var mousePosition = Raylib.GetMousePosition();

                if (Raylib.CheckCollisionPointCircle(mousePosition, _position, _radius))
                {
                    _isDead = true;
                    return;
                }
            }
            

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
                    _position.X += delta;
                    _position.Y -= delta;
                    break;


                case Direction.UpLeft:
                    _position.X -= delta;
                    _position.Y -= delta;
                    break;


                case Direction.DownLeft:
                    _position.X -= delta;
                    _position.Y += delta;
                    break;


                case Direction.DownRight:
                {
                    _position.X += delta;
                    _position.Y += delta;
                    break;
                }
            }
        }
        

        public void Draw()
        {
            if (_isDead)
            {
                return;
            }
            
            Raylib.DrawCircle(CurX, CurY, _radius, _color);
        }

        public void DrawLineTo(int x, int y)
        {
            if (_isDead)
            {
                return;
            }
            
            Raylib.DrawLine(CurX, CurY, x, y, Color.LIME);
        }
    }
}    