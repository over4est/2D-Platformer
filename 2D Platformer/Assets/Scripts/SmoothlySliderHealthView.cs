using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SmoothlyChanger))]
public class SmoothlySliderHealthView : HealthView
{
    private Slider _slider;
    private SmoothlyChanger _smoothlyChanger;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        _slider.value = MaxValue / MaxValue;

        _smoothlyChanger = GetComponent<SmoothlyChanger>();
        _smoothlyChanger.ValueChanged += SetSliderValue;
    }

    private void OnDisable()
    {
        _smoothlyChanger.ValueChanged -= SetSliderValue;
    }

    protected override void ChangeValue(float value)
    {
        float startValue = _slider.value * MaxValue;

        _smoothlyChanger.ChangeValue(startValue, value, MaxValue);
    }

    private void SetSliderValue(float value)
    {
        _slider.value = value;
    }
}