using UnityEngine;

public class FallenThingsCatcher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Character character))
        {
            character.ResetPosition();
        }

        if (collision.transform.TryGetComponent(out Coin coin))
        {
            coin.CallRespawn();
        }
    }
}