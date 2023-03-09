using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

	#endregion

	#endregion
	#region Int Vectors

	#region Vector2
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

	#endregion
}
