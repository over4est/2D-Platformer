using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReloadView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void DecreaseValue(float delay)
    {
        StartCoroutine(ChangeValue(delay, _slider.minValue));
    }

    public void IncreaseValue(float delay)
    {
        StartCoroutine(ChangeValue(delay, _slider.maxValue));
    }

    private IEnumerator ChangeValue(float delay, float target)
    {
        float curerentValue = _slider.value;
        float timeElapsed = 0f;

        while (timeElapsed < delay)
        {
            float delta = timeElapsed / delay;
            timeElapsed += Time.deltaTime;

            _slider.value = Mathf.Lerp(curerentValue, target, delta);

            yield return null;
        }
    }
}