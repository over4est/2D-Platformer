using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private bool _isFacingRight = true;

    public void TryFlip(float xDirection)
    {
        if (xDirection > 0 && _isFacingRight == false)
        {
            Flip();
        }
        else if (xDirection < 0 && _isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        float rotateChange = 180f;

        _isFacingRight = !_isFacingRight;
        transform.Rotate(0f, rotateChange, 0f);
    }
}