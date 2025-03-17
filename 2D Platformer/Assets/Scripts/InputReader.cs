using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);
    private const string Fire1 = nameof(Fire1);
    private const string VampireSkill = nameof(VampireSkill);

    public event Action JumpPressed;
    public event Action AttackPressed;
    public event Action VampireSkillPressed;

    public float XDirection { get; private set; }

    private void Update()
    {
        XDirection = Input.GetAxis(Horizontal);

        if (Input.GetButtonDown(Jump))
        {
            JumpPressed?.Invoke();
        }

        if (Input.GetButtonDown(Fire1))
        {
            AttackPressed?.Invoke();
        }

        if (Input.GetButtonDown(VampireSkill))
        {
            VampireSkillPressed?.Invoke();
        }
    }
}