using System.Collections.Generic;
using UnityEngine;

namespace Dynamic
{
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
		/// Clamps a value between min and max
		/// </summary>
		/// <param name="value">The value to clamp</param>
		/// <param name="min">The minium value</param>
		/// <param name="max">The maximum value</param>
		/// <returns>The clamped value</returns>
		public static float Clamp(this int value, int min, int max) => Mathf.Clamp(value, min, max);

		/// <summary>
		/// Converts a large number to an array of ints
		/// </summary>
		/// <param name="value">The value to convert</param>
		/// <returns>An array of numbers</returns>
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

		public static int MultipleNumbersTOLargeNumber(this IEnumerable<int> values)
		{
			string value = string.Empty;
			foreach (char character in values)
			{
				value += System.Convert.ToInt32(character);
			}
			return int.Parse(value);
		}
	}
}