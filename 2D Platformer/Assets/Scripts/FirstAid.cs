using System;
using UnityEngine;

public class FirstAid : MonoBehaviour
{
    [SerializeField] private int _healAmount;

    public int HealAmount => _healAmount;

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}