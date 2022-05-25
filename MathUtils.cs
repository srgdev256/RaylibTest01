namespace RaylibTest01
{
	public static class MathUtils
	{
		public static float Lerp(float p1, float p2, float factor)
		{
			return p2 * factor + p1 * (1.0f - factor);
		}

		public static float GetLoopedFactor(float factor)
		{
			if (factor < 0.5f)
			{
				return factor * 2.0f;
			}
			else
			{
				return 1.0f - (factor - 0.5f) * 2.0f;
			}
		}
	}
}