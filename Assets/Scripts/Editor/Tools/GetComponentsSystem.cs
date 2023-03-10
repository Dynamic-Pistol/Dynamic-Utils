using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class GetComponentsSystem
{
    [MenuItem("Tools/Get Objects Components")]
    public static void GetComponents()
    {
        var scripts = UnityEngine.Object.FindObjectsOfType<MonoBehaviour>();

        foreach (var script in scripts)
        {
            var classType = script.GetType();

            var fields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var attribute = field.GetCustomAttribute(typeof(GetComponentAttribute), true) as GetComponentAttribute;

				if (attribute != null)
                {
                    field.SetValue(script, script.GetComponent(field.FieldType));
                }
            }
        }
    }
}
