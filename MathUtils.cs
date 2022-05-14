namespace RaylibTest01
{
	public static class MathUtils
	{
		public static float Lerp(float p1, float p2, float factor)
		{
			return p2 * factor + p1 * (1.0f - factor);
		}
	}
}