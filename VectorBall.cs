using System.Numerics;
using Raylib_cs;

namespace RaylibTest01
{
	public class VectorBall
	{
		private Vector2 _position;

		private float _speed;
		
		public int X  => (int)_position.X;
		public int Y  => (int)_position.Y;


		public VectorBall(Vector2 position, float speed)
		{
			_position = position;
			
			_speed = speed;
		}


		public void Update()
		{
			var mousePosition = Raylib.GetMousePosition();

			var directionToMouse = mousePosition - _position;

			float directionLength = directionToMouse.Length();

			if (directionLength <= 3.0f)
			{
				return;
			}

			Vector2 normalizedDirection = directionToMouse / directionLength;
			
			float distanceCovered = _speed * Raylib.GetFrameTime();

			Vector2 delta = normalizedDirection * distanceCovered;
			
			_position += delta;
		}
		
		
		public void Draw()
		{
			Raylib.DrawCircle(X, Y, 48.0f, Color.MAROON);
		}
	}
}