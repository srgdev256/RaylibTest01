using Raylib_cs;

namespace RaylibTest01
{
	public static class DirectionUtils
	{
		public static Direction GetRandomCardinalDirection()
		{
			int randomValue = Raylib.GetRandomValue((int)Direction.Up, (int)Direction.Right);
			return (Direction)randomValue;
		}
		
		public static Direction GetRandomDiagonalDirection()
		{
			int randomValue = Raylib.GetRandomValue((int)Direction.UpLeft, (int)Direction.DownRight);
			return (Direction)randomValue;
		}
	}
}