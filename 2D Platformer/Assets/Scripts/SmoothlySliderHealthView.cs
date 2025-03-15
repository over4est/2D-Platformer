using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothlySliderHealthView : HealthView
{
    [SerializeField] private float _changeDuration;

    private Coroutine _corutine;
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        _slider.value = MaxValue / MaxValue;
    }

    protected override void ChangeValue(float value)
    {
        if (_corutine != null)
            StopCoroutine(_corutine);

        _corutine = StartCoroutine(SmoothlyChange(value));
    }

    private IEnumerator SmoothlyChange(float value)
    {
        float startValue = _slider.value;
        float targetValue = value / MaxValue;
        float timeElapsed = 0f;

        while (timeElapsed < _changeDuration)
        {
            float delta = timeElapsed / _changeDuration;

            _slider.value = Mathf.Lerp(startValue, targetValue, delta);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }
}