using System;
using System.Collections.Generic;
using UnityEngine;

public static class Singleton
{
	private static Dictionary<Type, MonoBehaviour> _instances = new Dictionary<Type, MonoBehaviour>();

	public static void AddInstance<T>(T holder, bool persistant) where T : MonoBehaviour
	{
		if (GetInstance<T>() == null)
			_instances.Add(typeof(T), holder);
		else
			UnityEngine.Object.Destroy(holder.gameObject);
		if (persistant)
			UnityEngine.Object.DontDestroyOnLoad(holder.gameObject);

	}

	public static T GetInstance<T>() where T : MonoBehaviour
	{
		if (_instances.TryGetValue(typeof(T), out MonoBehaviour behaviour))
			return (T)behaviour;
		else
			return null;
	}
}