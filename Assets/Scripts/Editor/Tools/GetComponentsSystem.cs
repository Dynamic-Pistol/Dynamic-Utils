using System.Collections;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class GetComponentsSystem
{
    [MenuItem("Tools/Get Objects Components")]
    public static void GetComponents()
    {
        var scripts = Object.FindObjectsOfType<MonoBehaviour>();

        foreach (var script in scripts)
        {
            var classType = script.GetType();

            var fields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var attribute = field.GetCustomAttribute(typeof(GetComponentAttribute), true) as GetComponentAttribute;

                if (attribute == null)
                    continue;

				switch (attribute)
				{
					case SelfComponentsAttribute:
						field.SetValue(script, script.GetComponents(field.FieldType));
						break;
					case ParentComponentsAttribute:
						field.SetValue(script, script.GetComponentsInParent(field.FieldType));
						break;
					case ChildrenComponentsAttribute:
						field.SetValue(script, script.GetComponentsInChildren(field.FieldType));
						break;
					case AnyComponentsAttribute:
						field.SetValue(script, Object.FindObjectsOfType(field.FieldType));
						break;
					case SelfComponentAttribute:
						field.SetValue(script, script.GetComponent(field.FieldType));
						break;
					case ParentComponentAttribute:
						field.SetValue(script, script.GetComponentInParent(field.FieldType));
						break;
					case ChildrenComponentAttribute:
						field.SetValue(script, script.GetComponentInChildren(field.FieldType));
						break;
					case AnyComponentAttribute:
						field.SetValue(script, Object.FindObjectOfType(field.FieldType));
						break;
				}
            }
        }
    }
}
