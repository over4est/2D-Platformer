using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private bool _isFacingRight => transform.localScale.x > 0;

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
        float scaleChange = -1f;
        Vector3 tempScale = transform.localScale;

        tempScale.x *= scaleChange;
        transform.localScale = tempScale;
    }
}