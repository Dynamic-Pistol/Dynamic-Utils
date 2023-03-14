using UnityEngine;
using UnityEngine.Events;

namespace Dynamic.Variables
{
	[CreateAssetMenu(fileName = "New Int", menuName = "Variables/Int")]
	public class IntVariable : ScriptableObject
	{
		private int _value;

		public int Value
		{
			get => _value; set
			{
				_value = value;
				OnValueChangedUnityEvent?.Invoke(value);
				OnValueChanged?.Invoke(value);
			}
		}


		[SerializeField]
		private UnityEvent<int> OnValueChangedUnityEvent = new UnityEvent<int>();

		public event System.Action<int> OnValueChanged;
	}
}