using UnityEngine;

[RequireComponent(typeof(Reloader))]
public abstract class Skill : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _damage;
    [SerializeField] private float _reloadTime;

    private bool _isReadyToUse = true;
    private Reloader _reloader;

    protected Reloader Reloader => _reloader;
    protected bool IsReadyToUse => _isReadyToUse;
    protected float Damage => _damage;
    protected float ReloadTime => _reloadTime;
    protected LayerMask TargetLayer => _targetLayer;

    private void Awake()
    {
        _reloader = GetComponent<Reloader>();
    }

    private void OnEnable()
    {
        _reloader.Reloaded += Reload;
    }

    private void OnDisable()
    {
        _reloader.Reloaded -= Reload;
    }

    public abstract void Use();

    protected void SetNotReadyToUse()
    {
        _isReadyToUse = false;
    }

    private void Reload()
    {
        _isReadyToUse = true;
    }
}