using UnityEngine;
using UnityEngine.Events;

namespace Dynamic.Variables
{
	[CreateAssetMenu(fileName = "New Bool", menuName = "Variables/Bool")]
	public class BoolVariable : ScriptableObject
	{
		private bool _value;

		public bool Value
		{
			get => _value; set
			{
				_value = value;
				OnValueChangedUnityEvent?.Invoke(value);
				OnValueChanged?.Invoke(value);
			}
		}

		[SerializeField]
		private UnityEvent<bool> OnValueChangedUnityEvent = new UnityEvent<bool>();

		public event System.Action<bool> OnValueChanged;

		public void Toggle()
		{
			_value = !_value;
			OnValueChangedUnityEvent?.Invoke(_value);
			OnValueChanged?.Invoke(_value);
		}
	}
}