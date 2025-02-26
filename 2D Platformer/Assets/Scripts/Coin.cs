using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> RespawnNeeded;

    public void CallRespawn()
    {
        RespawnNeeded?.Invoke(this);
    }
}