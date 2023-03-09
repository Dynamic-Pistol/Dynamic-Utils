using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Int",menuName = "Variables/Int")]
public class IntVariable : ScriptableObject
{
    private int _value;

    public int Value => _value;

    [SerializeField]
    private UnityEvent<int> OnValueChangedUnityEvent = new UnityEvent<int>();

    public event System.Action<int> OnValueChanged;

    public void SetValue(int value)
    {
        _value = value;
		OnValueChangedUnityEvent?.Invoke(value);
        OnValueChanged?.Invoke(value);
    }
}
