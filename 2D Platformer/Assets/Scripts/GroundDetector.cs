using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _rayDistance;
    [SerializeField] private LayerMask _platformLayer;

    public bool IsGround()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, _rayDistance, _platformLayer);

        return ray != false && ray.transform.TryGetComponent<TilemapCollider2D>(out _);
    }
}