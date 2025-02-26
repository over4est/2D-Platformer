using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundDetector : MonoBehaviour
{
    private readonly string Platforms = "Platforms";

    [SerializeField] private float _rayDistance;

    private LayerMask _platformLayer;

    public bool IsGround => GetIsGround();

    private void Awake()
    {
        _platformLayer = (1 << LayerMask.NameToLayer(Platforms));
    }

    private bool GetIsGround()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, _rayDistance, _platformLayer);

        if (ray != false && ray.transform.TryGetComponent<TilemapCollider2D>(out _))
        {
            return true;
        }

        return false;
    }
}