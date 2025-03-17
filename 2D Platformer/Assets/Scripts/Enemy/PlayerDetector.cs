using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _rayDistance;
    [SerializeField] private LayerMask _characterLayer;

    private EnemyMovement _enemyMovement;

    public bool IsDetected => GetIsDetected();
    public Transform DetectedCharacter { get; private set; }

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private bool GetIsDetected()
    {
        Vector2 viewDirection = new Vector2(_enemyMovement.XMovementDirection, 0f);
        RaycastHit2D ray = Physics2D.Raycast(transform.position, viewDirection, _rayDistance, _characterLayer);

        if (ray != false && ray.transform.TryGetComponent(out Character character))
        {
            DetectedCharacter = character.transform;

            return true;
        }

        return false;
    }
}