using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> RespawnNeeded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<FallenThingsCatcher>(out _))
        {
            RespawnNeeded?.Invoke(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<CoinPicker>(out _))
        {
            RespawnNeeded?.Invoke(this);
        }
    }
}