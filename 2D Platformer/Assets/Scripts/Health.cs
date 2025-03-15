using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;

    private float _currentValue;

    public event Action<float> ValueChanged;

    public float MaxValue => _maxValue;

    private float _minValue = 0f;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            return;
        }

        _currentValue = Mathf.Clamp(_currentValue - damage, _minValue, _maxValue);

        ValueChanged?.Invoke(_currentValue);

        if (_currentValue == 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Heal(float value)
    {
        if (value < 0)
            return;

        _currentValue = Mathf.Clamp(_currentValue + value, _minValue, _maxValue);

        ValueChanged?.Invoke(_currentValue);
    }
}