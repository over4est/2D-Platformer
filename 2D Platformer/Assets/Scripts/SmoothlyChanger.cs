using System;
using System.Collections;
using UnityEngine;

public class SmoothlyChanger : MonoBehaviour
{
    [SerializeField] private float _changeDuration;

    private Coroutine _corutine;

    public event Action<float> ValueChanged;

    public void ChangeValue(float startValue, float targetValue, float maxValue)
    {
        if (_corutine != null)
            StopCoroutine(_corutine);

        _corutine = StartCoroutine(SmoothlyChange(startValue, targetValue, maxValue));
    }

    private IEnumerator SmoothlyChange(float startValue, float targetValue, float maxValue)
    {
        float tempStartValue = startValue / maxValue;
        float tempTargetValue = targetValue / maxValue;
        float timeElapsed = 0f;

        while (timeElapsed < _changeDuration)
        {
            float delta = timeElapsed / _changeDuration;
            float tempValue = Mathf.Lerp(tempStartValue, tempTargetValue, delta);

            timeElapsed += Time.deltaTime;

            ValueChanged?.Invoke(tempValue);

            yield return null;
        }
    }
}