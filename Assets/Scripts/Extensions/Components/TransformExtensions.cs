using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class TransformExtensions
{
	public static void SetPositionX(this Transform transform, float value) => transform.position = transform.position.WithX(value);

	public static void SetPositionY(this Transform transform, float value) => transform.position = transform.position.WithY(value);

	public static void SetPositionZ(this Transform transform, float value) => transform.position = transform.position.WithZ(value);

	public static void SetEulerX(this Transform transform, float value) => transform.eulerAngles = transform.eulerAngles.WithX(value);

	public static void SetEulerY(this Transform transform, float value) => transform.eulerAngles = transform.eulerAngles.WithY(value);

	public static void SetEulerZ(this Transform transform, float value) => transform.eulerAngles = transform.eulerAngles.WithZ(value);

	public static void SetScaleX(this Transform transform, float value) => transform.localScale = transform.localScale.WithX(value);

	public static void SetScaleY(this Transform transform, float value) => transform.localScale = transform.localScale.WithY(value);

	public static void SetScaleZ(this Transform transform, float value) => transform.localScale = transform.localScale.WithZ(value);

	public static void SetScale(this Transform transform, float value) => transform.localScale = Vector3.one * value;


	public static IEnumerable<Transform> GetChildren(this Transform transform) => transform.Cast<Transform>();

	public static bool HasChildren(this Transform transform) => transform.childCount > 0;

	public static Transform GetRandomChild(this Transform transform) => transform.GetChild(Random.Range(0, transform.childCount));

	public static void ResetWorld(this Transform transform)
	{
		transform.SetPositionAndRotation(transform.position, Quaternion.identity);
		transform.localScale = Vector3.one;
	}

	public static void ResetLocal(this Transform transform)
	{
		transform.localPosition = Vector3.zero;
		transform.rotation = Quaternion.identity;
		transform.localScale = Vector3.one;
	}
}
