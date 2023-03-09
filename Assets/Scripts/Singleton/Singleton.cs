using System.Collections.Generic;
using UnityEngine;

public static class Singleton
{
	private static List<Component> _instances = new List<Component>();

	public static void AddInstance<T>(T holder,bool persistant) where T : Component
	{
		if (GetInstance<T>() == null)
			_instances.Add(holder);
		else
			Object.Destroy(holder.gameObject);
		if (persistant)
			Object.DontDestroyOnLoad(holder.gameObject);

	}

	public static T GetInstance<T>() where T : Component => (T)_instances.Find(i => i.GetType() == typeof(T));
}
