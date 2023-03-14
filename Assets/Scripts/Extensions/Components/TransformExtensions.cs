using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Dynamic;

namespace Dynamic
{
	public static class TransformExtensions
	{
		#region Sets

		/// <summary>
		/// Sets the X position of a transform
		/// </summary>
		/// <param name="transform">The Transform to Set</param>
		/// <param name="value">The value to set</param>
		public static void SetPositionX(this Transform transform, float value) => transform.position = transform.position.WithX(value);

		/// <summary>
		/// Sets the Y position of a transform
		/// </summary>
		/// <param name="transform">The Transform to Set</param>
		/// <param name="value">The value to set</param>
		public static void SetPositionY(this Transform transform, float value) => transform.position = transform.position.WithY(value);

		/// <summary>
		/// Sets the Z position of a transform
		/// </summary>
		/// <param name="transform">The Transform to Set</param>
		/// <param name="value">The value to set</param>
		public static void SetPositionZ(this Transform transform, float value) => transform.position = transform.position.WithZ(value);

		/// <summary>
		/// Sets the X rotation of a transform
		/// </summary>
		/// <param name="transform">The Transform to Set</param>
		/// <param name="value">The value to set</param>
		public static void SetEulerX(this Transform transform, float value) => transform.eulerAngles = transform.eulerAngles.WithX(value);

		/// <summary>
		/// Sets the Y rotation of a transform
		/// </summary>
		/// <param name="transform">The Transform to Set</param>
		/// <param name="value">The value to set</param>
		public static void SetEulerY(this Transform transform, float value) => transform.eulerAngles = transform.eulerAngles.WithY(value);

		/// <summary>
		/// Sets the Z rotation of a transform
		/// </summary>
		/// <param name="transform">The Transform to Set</param>
		/// <param name="value">The value to set</param>
		public static void SetEulerZ(this Transform transform, float value) => transform.eulerAngles = transform.eulerAngles.WithZ(value);

		/// <summary>
		/// Sets the X scale of a transform
		/// </summary>
		/// <param name="transform">The Transform to Set</param>
		/// <param name="value">The value to set</param>
		public static void SetScaleX(this Transform transform, float value) => transform.localScale = transform.localScale.WithX(value);

		/// <summary>
		/// Sets the Y scale of a transform
		/// </summary>
		/// <param name="transform">The Transform to Set</param>
		/// <param name="value">The value to set</param>
		public static void SetScaleY(this Transform transform, float value) => transform.localScale = transform.localScale.WithY(value);

		/// <summary>
		/// Sets the Z scale of a transform
		/// </summary>
		/// <param name="transform">The Transform to Set</param>
		/// <param name="value">The value to set</param>
		public static void SetScaleZ(this Transform transform, float value) => transform.localScale = transform.localScale.WithZ(value);

		/// <summary>
		/// Sets the scale of a transform on all axis
		/// </summary>
		/// <param name="transform">The Transform to Set</param>
		/// <param name="value">The value to set</param>
		public static void SetScale(this Transform transform, float value) => transform.localScale = Vector3.one * value;

		#endregion


		#region Children
		/// <summary>
		/// Gets the children of a transform
		/// </summary>
		/// <param name="transform">The transform to get</param>
		/// <returns>All the children of the transform</returns>
		public static IEnumerable<Transform> GetChildren(this Transform transform) => transform.Cast<Transform>();

		/// <summary>
		/// Checks if the transform has any children
		/// </summary>
		/// <param name="transform">The transform to check</param>
		/// <returns>True if has children,otherwise false</returns>
		public static bool HasChildren(this Transform transform) => transform.childCount > 0;


		/// <summary>
		/// Gets a random child
		/// </summary>
		/// <param name="transform">The transform to get</param>
		/// <returns>Random child</returns>
		public static Transform GetRandomChild(this Transform transform) => transform.GetChild(Random.Range(0, transform.childCount));

		#endregion

		#region Resetting
		/// <summary>
		/// Resets the world position of a transform
		/// </summary>
		/// <param name="transform">The transform to rese</param>
		public static void ResetWorld(this Transform transform)
		{
			transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
			transform.localScale = Vector3.one;
		}

		/// <summary>
		/// Rests the local position of a transform
		/// </summary>
		/// <param name="transform">The transform to reset</param>
		public static void ResetLocal(this Transform transform)
		{
			transform.localPosition = Vector3.zero;
			transform.rotation = Quaternion.identity;
			transform.localScale = Vector3.one;
		}
		#endregion
	}
}