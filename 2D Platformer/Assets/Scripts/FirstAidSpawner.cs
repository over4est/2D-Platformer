using System.Collections.Generic;
using UnityEngine;

public class FirstAidSpawner : MonoBehaviour
{
    [SerializeField] private List<FirstAidSpawnPoint> _spawnPoints;
    [SerializeField] private FirstAid _prefab;
    [SerializeField] private int _aidAmount;

    private ObjectPool<FirstAid> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<FirstAid>(_prefab, _aidAmount, transform);
    }

    private void Start()
    {
        for (int i = 0; i < _aidAmount; i++)
        {
            Spawn();
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
}