using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace RaylibTest01
{
    public class RandomTargetBall
    {
        private Vector2 _position;

        private Vector2 _targetPosition;
        
        private float _speed;
        private float _radius;

        private float _targetChangePeriod;

        private float _curTime;

        public int X  => (int)_position.X;
        public int Y  => (int)_position.Y;

        public RandomTargetBall(Vector2 position, float speed, float radius, float targetChangePeriod)
        {
            _position = position;
            _speed = speed;
            _radius = radius;
            _targetChangePeriod = targetChangePeriod;
            _curTime = 0.0f;
            
            PickTarget();
        }
        
        private static int GetRandomX(int radius)
        {
            return GetRandomValue((int)0.0f + radius, Program.Width - radius);
        }
        
        private static int GetRandomY(int radius)
        {
            return GetRandomValue((int)0.0f + radius, Program.Height - radius);
        }

        public void Update()
        {
            var directionToTarget = _targetPosition - _position;

            float directionLength = directionToTarget.Length();

            Vector2 normalizedDirection = directionToTarget / directionLength;
			
            float distanceCovered = _speed * Raylib.GetFrameTime();

            Vector2 delta = normalizedDirection * distanceCovered;
			
            _position += delta;
            
            _curTime += Raylib.GetFrameTime(); 
            
            if (_curTime >= _targetChangePeriod)
            {
                PickTarget();
                _curTime = 0f;
            }

        }

        public void Draw()
        {
            DrawCircle(X, Y, 30.0f, Color.VIOLET);
        }

        private void PickTarget()
        {
            _targetPosition = new Vector2(GetRandomX((int)_radius), GetRandomY((int)_radius));
        }
    }

    
}