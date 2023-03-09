using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Float",menuName = "Variables/Float")]
public class FloatVariable : ScriptableObject
{
    private float _value;

    public float Value => _value;

    [SerializeField]
    private UnityEvent<float> OnValueChangedUnityEvent = new UnityEvent<float>();

    public event System.Action<float> OnValueChanged;

    public void SetValue(float value)
    {
        _value = value;
		OnValueChangedUnityEvent?.Invoke(value);
        OnValueChanged?.Invoke(value);
    }
}
