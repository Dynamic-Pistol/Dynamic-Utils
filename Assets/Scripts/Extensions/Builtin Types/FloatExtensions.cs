using UnityEngine;

public static class FloatExtensions
{
	/// <summary>
	/// Checks if the float is between the minimum and maximum
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="min">The minimum value</param>
	/// <param name="max">The maximum value</param>
	/// <returns>True if between the minimum and maximum,otherwise false</returns>
	public static bool IsBetween(this float value, float min, float max) => min < value && value < max;

	/// <summary>
	/// Checks if the float is between or equal the minimum and maximum
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="min">The minimum value</param>
	/// <param name="max">The maximum value</param>
	/// <returns>True if between or equal the minimum and maximum,otherwise false</returns>
	public static bool IsBetweenEqual(this float value, float min, float max) => min <= value && value <= max;

	/// <summary>
	/// Checks if the float is not between the minimum and maximum
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="min">The minimum value</param>
	/// <param name="max">The maximum value</param>
	/// <returns>True if not between the minimum and maximum,otherwise false</returns>
	public static bool IsExcluded(this float value, float min, float max) => !IsBetween(value, min, max);

	/// <summary>
	/// Checks if the float is between the minimum and maximum
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="min">The minimum value</param>
	/// <param name="max">The maximum value</param>
	/// <returns>True if not between or equal the minimum and maximum,otherwise false</returns>
	public static bool IsExcludedEqual(this float value, float min, float max) => !IsBetweenEqual(value, min, max);

	/// <summary>
	/// Changes from angle to Vector2
	/// </summary>
	/// <param name="angle">The angle to Change</param>
	/// <returns>Vector2 from angle</returns>
	public static Vector2 ToVector2(this float angle)
	{
		float angleRad = angle * Mathf.Rad2Deg;
		return new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
	}

}
