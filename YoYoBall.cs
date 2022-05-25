using System;
using System.Numerics;
using Raylib_cs;

namespace RaylibTest01
{
    public class YoYoBall
    {
        //params
        private readonly Vector2 _positionA;
        private readonly Vector2 _positionB;

        private readonly Color _color;
        
        private readonly float _radiusA;
        private readonly float _radiusB;

        private readonly float _fullTime;
        
        //dynamic vars
        private float _curTime;
        private Vector2 _curPosition;
        private float _curRadius;
        
        
        public YoYoBall(Vector2 positionA, Vector2 positionB, Color color, float radiusA, float radiusB, float fullTime)
        {
            _positionA = positionA;
            _positionB = positionB;

            _color = color;

            _radiusA = radiusA;
            _radiusB = radiusB;

            _fullTime = fullTime;

            _curTime = 0.0f;
            _curPosition = positionA;
            _curRadius = _radiusA;

        }

        
        
        public void Update()
        {
            _curTime += Raylib.GetFrameTime();

            float fullTimeFactor = (_curTime % _fullTime) / _fullTime;

            float loopedFactor = MathUtils.GetLoopedFactor(fullTimeFactor);

            _curPosition = Vector2.Lerp(_positionA, _positionB, loopedFactor);
            _curRadius = MathUtils.Lerp(_radiusA, _radiusB, loopedFactor);
        }

        
        
        public void Draw()
        {
            Raylib.DrawCircle((int)_curPosition.X, (int)_curPosition.Y, _curRadius, _color);
        }
        
        
    }
}