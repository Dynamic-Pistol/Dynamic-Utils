using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Bool", menuName = "Variables/Bool")]
public class BoolVariable : ScriptableObject
{
	private bool _value;

	public bool Value => _value;

	[SerializeField]
	private UnityEvent<bool> OnValueChangedUnityEvent = new UnityEvent<bool>();

	public event System.Action<bool> OnValueChanged;

	public void SetValue(bool value)
	{
		_value = value;
		OnValueChangedUnityEvent?.Invoke(_value);
		OnValueChanged?.Invoke(_value);
	}

	public void Toggle()
	{
		_value = !_value;
		OnValueChangedUnityEvent?.Invoke(_value);
		OnValueChanged?.Invoke(_value);
	}
}
