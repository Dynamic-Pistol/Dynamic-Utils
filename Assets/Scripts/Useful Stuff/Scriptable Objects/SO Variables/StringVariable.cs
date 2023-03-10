using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New String", menuName = "Variables/String")]
public class StringVariable : ScriptableObject
{
	private string _value;

	public string Value
	{
		get => _value; set
		{
			_value = value;
			OnValueChangedUnityEvent?.Invoke(value);
			OnValueChanged?.Invoke(value);
		}
	}

	[SerializeField]
	private UnityEvent<string> OnValueChangedUnityEvent = new UnityEvent<string>();

	public event System.Action<string> OnValueChanged;
}
