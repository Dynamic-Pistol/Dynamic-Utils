using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dynamic
{
	public static class VectorExtensions
	{
		#region Float Vectors

		#region Vector2

		#region Values Change

		public static Vector2 WithX(this Vector2 vector, float xValue) => new Vector2(xValue, vector.y);

		public static Vector2 WithY(this Vector2 vector, float yValue) => new Vector2(vector.x, yValue);

		public static Vector2 Inverted(this Vector2 vector) => new Vector2(vector.y, vector.x);

		public static Vector3 InsertZ(this Vector2 vector, float z) => new Vector3(vector.x, vector.y, z);

		/// <summary>
		/// Changes a Vector2 to a Top-Down 3D view
		/// </summary>
		/// <param name="input">The Vector2 to convert</param>
		/// <returns>a Top-Down Vector3 from a Vector2</returns>
		public static Vector3 TopDown3D(this Vector2 input) => new Vector3(input.x, 0, input.y);

		/// <summary>
		/// Clamps a Vector2
		/// </summary>
		/// <param name="value"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>a Vector2 between the min and max value</returns>
		public static Vector2 ClampVector2(this Vector2 value, Vector2 min, Vector2 max)
		{
			float x = Mathf.Clamp(value.x, min.x, max.x);
			float y = Mathf.Clamp(value.y, min.y, max.y);
			return new Vector2(x, y);
		}

		#endregion

		#region Misc
		public static float Angle(this Vector2 vector)
		{
			return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
		}

		public static float AngleOffsetted(this Vector2 vector)
		{
			return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg - 90;
		}

		public static float AngleFromTarget(this Vector2 origin, Vector2 direction)
		{
			Vector2 target = direction - origin;
			return Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
		}

		public static float AngleFromTargetOffsetted(this Vector2 origin, Vector2 target)
		{
			Vector2 targetDir = target - origin;
			return Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90;
		}

		public static Vector2 GetShortest(this IEnumerable<Vector2> vectors, Vector2 origin) => vectors.OrderBy(x => (x - origin).sqrMagnitude).FirstOrDefault();
		#endregion

		#endregion

		#region Vector3

		public static Vector3 WithX(this Vector3 vector, float xValue) => new Vector3(xValue, vector.y, vector.z);

		public static Vector3 WithY(this Vector3 vector, float yValue) => new Vector3(vector.x, yValue, vector.z);

		public static Vector3 WithZ(this Vector3 vector, float zValue) => new Vector3(vector.x, vector.y, zValue);

		/// <summary>
		/// Clamps a Vector3
		/// </summary>
		/// <param name="value"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>a Vector3 between the min and max value</returns>
		public static Vector3 ClampVector3(this Vector3 value, Vector3 min, Vector3 max)
		{
			float x = Mathf.Clamp(value.x, min.x, max.x);
			float y = Mathf.Clamp(value.y, min.y, max.y);
			float z = Mathf.Clamp(value.z, min.z, max.z);
			return new Vector3(x, y, z);
		}


		/// <summary>
		/// Gets the shortest
		/// </summary>
		/// <param name="vectors"></param>
		/// <param name="origin"></param>
		/// <returns></returns>
		public static Vector3 GetShortest(this IEnumerable<Vector3> vectors, Vector3 origin) => vectors.OrderBy(x => (x - origin).sqrMagnitude).FirstOrDefault();

		#endregion

		#endregion
		#region Int Vectors

		#region Vector2

		/// <summary>
		/// Clamps a Vector2Int
		/// </summary>
		/// <param name="value"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>a Vector2Int between the min and max value</returns>
		public static Vector2Int ClampVector2Int(this Vector2Int value, Vector2Int min, Vector2Int max)
		{
			int x = Mathf.Clamp(value.x, min.x, max.x);
			int y = Mathf.Clamp(value.y, min.y, max.y);
			return new Vector2Int(x, y);
		}

		public static float Angle(this Vector2Int vector)
		{
			return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
		}

		public static float AngleOffsetted(this Vector2Int vector)
		{
			return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg - 90;
		}

		public static float AngleFromTarget(this Vector2Int origin, Vector2Int direction)
		{
			Vector2Int target = direction - origin;
			return Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
		}

		public static float AngleFromTargetOffsetted(this Vector2Int origin, Vector2Int target)
		{
			Vector2Int targetDir = target - origin;
			return Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90;
		}

		/// <summary>
		/// Changes a Vector2Int to a Top-Down 3D view
		/// </summary>
		/// <param name="input">The Vector2Int to convert</param>
		/// <returns>a Top-Down Vector3Int from a Vector2Int</returns>
		public static Vector3Int TopDown3D(this Vector2Int input) => new Vector3Int(input.x, 0, input.y);
		#endregion

		#region Vector3

		/// <summary>
		/// Clamps a Vector3Int
		/// </summary>
		/// <param name="value"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>a Vector3Int between the min and max value</returns>
		public static Vector3Int ClampVector3Int(this Vector3Int value, Vector3Int min, Vector3Int max)
		{
			int x = Mathf.Clamp(value.x, min.x, max.x);
			int y = Mathf.Clamp(value.y, min.y, max.y);
			int z = Mathf.Clamp(value.z, min.z, max.z);
			return new Vector3Int(x, y, z);
		}

		#endregion

		#endregion
	}
}

