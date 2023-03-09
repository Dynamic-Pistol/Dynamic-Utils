using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New String", menuName = "Variables/String")]
public class StringVariable : ScriptableObject
{
	private string _value;

	public string Value => _value;

	[SerializeField]
	private UnityEvent<string> OnValueChangedUnityEvent = new UnityEvent<string>();

	public event System.Action<string> OnValueChanged;

	public void SetValue(string value)
	{
		_value = value;
		OnValueChangedUnityEvent?.Invoke(_value);
		OnValueChanged?.Invoke(_value);
	}
}
