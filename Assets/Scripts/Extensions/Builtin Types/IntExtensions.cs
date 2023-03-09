using System.Collections.Generic;
using UnityEngine;

public static class IntExtensions
{
	/// <summary>
	/// Checks if the int is between the minimum and maximum
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="min">The minimum value</param>
	/// <param name="max">The maximum value</param>
	/// <returns>True if between the minimum and maximum,otherwise false</returns>
	public static bool IsBetween(this int value, int min, int max) => min < value && value < max;

	/// <summary>
	/// Checks if the int is between or equal the minimum and maximum
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="min">The minimum value</param>
	/// <param name="max">The maximum value</param>
	/// <returns>True if between or equal the minimum and maximum,otherwise false</returns>
	public static bool IsBetweenEqual(this int value, int min, int max) => min <= value && value <= max;

	/// <summary>
	/// Checks if the int is not between the minimum and maximum
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="min">The minimum value</param>
	/// <param name="max">The maximum value</param>
	/// <returns>True if not between the minimum and maximum,otherwise false</returns>
	public static bool IsExcluded(this int value, int min, int max) => !IsBetween(value, min, max);

	/// <summary>
	/// Checks if the int is between the minimum and maximum
	/// </summary>
	/// <param name="value">The value to check</param>
	/// <param name="min">The minimum value</param>
	/// <param name="max">The maximum value</param>
	/// <returns>True if not between or equal the minimum and maximum,otherwise false</returns>
	public static bool IsExcludedEqual(this int value, int min, int max) => !IsBetweenEqual(value, min, max);

	/// <summary>
	/// Converts a large number to an array of ints
	/// </summary>
	/// <param name="value">The value to convert</param>
	/// <returns></returns>
	public static int[] LargeNumberToMultipleNumbers(this int value)
	{
		string valueString = value.ToString();

		int[] values = new int[valueString.Length];

		for (int i = 0; i < values.Length; i++)
		{
			values[i] = (int)char.GetNumericValue(valueString[i]);
		}
		return values;
	}
	
	public static int MultipleNumbersTOLargeNumber(this List<int> values)
	{
		int value = 0;
		values.ForEach(x => value += x);
		return value;
	}
}