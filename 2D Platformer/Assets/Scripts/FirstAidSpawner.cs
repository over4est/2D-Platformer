using System.Collections.Generic;
using UnityEngine;

public class FirstAidSpawner : MonoBehaviour
{
    [SerializeField] private List<FirstAidSpawnPoint> _spawnPoints;
    [SerializeField] private FirstAid _prefab;
    [SerializeField] private int _aidAmount;
    [SerializeField] private float _spawnDelay;

    private ObjectPool<FirstAid> _pool;
    private List<FirstAid> _firstAids;

    private void Awake()
    {
        _pool = new ObjectPool<FirstAid>(_prefab, _aidAmount, transform);
        _firstAids = _pool.GetAllElements();
    }

    private void Start()
    {
        for (int i = 0; i < _aidAmount; i++)
        {
            Spawn();
        }
    }

    private void OnEnable()
    {
        foreach (FirstAid firstAid in _firstAids)
        {
            firstAid.RespawnNeeded += Disable;
            firstAid.RespawnNeeded += Spawn;
        }
    }

    private void OnDisable()
    {
        foreach (FirstAid coin in _firstAids)
        {
            coin.RespawnNeeded -= Disable;
            coin.RespawnNeeded -= Spawn;
        }
    }

    private void Spawn(FirstAid _ = null)
    {
        if (_pool.TryGet(out FirstAid firstAid))
        {
            int randomIndex = Random.Range(0, _spawnPoints.Count);
            Vector3 randomSpawnPointPosition = _spawnPoints[randomIndex].transform.position;

            firstAid.transform.position = randomSpawnPointPosition;
        }
    }

    private void Disable(FirstAid firstAid)
    {
        _pool.Release(firstAid);
    }
}