using System;
using UnityEngine;

public class FirstAid : MonoBehaviour
{
    [SerializeField] private int _healAmount;

    public event Action<FirstAid> RespawnNeeded;

    public int HealAmount => _healAmount;

    public void CallRespawn()
    {
        RespawnNeeded?.Invoke(this);
    }
}