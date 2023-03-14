using UnityEngine;
using UnityEngine.Events;

namespace Dynamic.Variables
{
	[CreateAssetMenu(fileName = "New Float", menuName = "Variables/Float")]
	public class FloatVariable : ScriptableObject
	{
		private float _value;

		public float Value
		{
			get => _value; set
			{
				_value = value;
				OnValueChangedUnityEvent?.Invoke(value);
				OnValueChanged?.Invoke(value);
			}
		}

		[SerializeField]
		private UnityEvent<float> OnValueChangedUnityEvent = new UnityEvent<float>();

		public event System.Action<float> OnValueChanged;
	}
}