using System;
using System.Collections;
using UnityEngine;

public class Reloader : MonoBehaviour
{
    private WaitForSeconds _wait;
    private float _currentDelay;

    public event Action Reloaded;

    public void Reload(float delay)
    {
        if (_currentDelay != delay)
        {
            _wait = new WaitForSeconds(delay);
            _currentDelay = delay;
        }

        StartCoroutine(Countdown(_wait));
    }

    private IEnumerator Countdown(WaitForSeconds wait)
    {
        yield return wait;

        Reloaded?.Invoke();
    }
}