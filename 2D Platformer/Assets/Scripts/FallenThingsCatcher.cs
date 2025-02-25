using UnityEngine;

public class FallenThingsCatcher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out CharacterMovement characterMovement))
        {
            characterMovement.ResetPosition();
        }
    }
}