using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);

    private bool _isJump;

    public float XDirection { get; private set; }

    private void Update()
    {
        XDirection = Input.GetAxis(Horizontal);

        if (Input.GetButtonDown(Jump))
        {
            _isJump = true;
        }
    }

    public bool GetIsJump()
    {
        return GetBoolAsTrigger(ref _isJump);
    }

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;

        return localValue;
    }
}