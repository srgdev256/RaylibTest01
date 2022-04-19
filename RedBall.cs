using Raylib_cs;

namespace RaylibTest01
{
    public class RedBall
    {
        private int _x;
        private int _y;

        private int _shift;
        private int _redBallShift;
        
        public int CurX => _x + _redBallShift;
        public int CurY => _y;
        
        public RedBall(int startX, int startY, int shift)
        {
            _x = startX;
            _y = startY;
            _shift = shift;
        }

        public void Update()
        {
            _shift += 1;

            if (_shift == 200)
            {
                _shift = 0;
            }

            if (_shift < 100)
            {
                _redBallShift = _shift;
            }
            else
            {
                _redBallShift = 100 - (_shift - 100);
            }

            
        }

        public void Draw()
        {
            Raylib.DrawCircle(CurX, CurY, 32.0f, Color.RED);
        }
    }
}