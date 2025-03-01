using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);
    private const string Fire1 = nameof(Fire1);

    private bool _isJump;
    private bool _isAttack;

    public float XDirection { get; private set; }

    private void Update()
    {
        XDirection = Input.GetAxis(Horizontal);

        if (Input.GetButtonDown(Jump))
        {
            _isJump = true;
        }

        if (Input.GetButtonDown(Fire1))
        {
            _isAttack = true;
        }
    }

    public bool GetIsJump()
    {
        return GetBoolAsTrigger(ref _isJump);
    }

    public bool GetIsAttack()
    {
        return GetBoolAsTrigger(ref _isAttack);
    }

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;

        return localValue;
    }
}