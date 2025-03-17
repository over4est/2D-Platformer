using System;
using UnityEngine;

[RequireComponent(typeof(ReloadView))]
public class VampirismSkill : Skill
{
    [SerializeField] private float _skillRadius;
    [SerializeField] private VampirismCircle _prefab;

    private ReloadView _reloadView;
    private ObjectPool<VampirismCircle> _pool;
    private int _maxCircles = 1;

    private void Start()
    {
        _pool = new ObjectPool<VampirismCircle>(_prefab, _maxCircles, transform);
        _reloadView = GetComponent<ReloadView>();
    }

    public override void Use()
    {
        if (IsReadyToUse && _pool.TryGet(out VampirismCircle obj))
        {
            SetNotReadyToUse();
            _reloadView.DecreaseValue(obj.Lifetime);

            obj.transform.position = transform.position;
            obj.transform.localScale = Vector3.one * _skillRadius;
            obj.SetDamage(Damage);
            obj.SetLayerMask(TargetLayer);

            obj.DisableNeeded += Disable;
            obj.DisableNeeded += Reload;
        }
    }

    private void Reload(VampirismCircle obj)
    {
        obj.DisableNeeded -= Reload;

        Reloader.Reload(ReloadTime);
        _reloadView.IncreaseValue(ReloadTime);
    }

    private void Disable(VampirismCircle obj)
    {
        obj.DisableNeeded -= Disable;

        _pool.Release(obj);
    }
}