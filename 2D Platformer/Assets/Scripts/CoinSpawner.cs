using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<CoinSpawnPoint> _spawnPoints;
    [SerializeField] private Coin _prefab;
    [SerializeField] private int _coinAmount;
    [SerializeField] private float _spawnDelay;

    private ObjectPool<Coin> _pool;
    private List<Coin> _coins;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(_prefab, _coinAmount, transform);
        _coins = _pool.GetAllElements();
    }

    private void Start()
    {
        for (int i = 0; i < _coinAmount; i++)
        {
            Spawn();
        }
    }

    private void OnEnable()
    {
        foreach (Coin coin in _coins)
        {
            coin.RespawnNeeded += Disable;
            coin.RespawnNeeded += Spawn;
        }
    }

    private void OnDisable()
    {
        foreach (Coin coin in _coins)
        {
            coin.RespawnNeeded -= Disable;
            coin.RespawnNeeded -= Spawn;
        }
    }

    private void Spawn(Coin _ = null)
    {
        if (_pool.TryGet(out Coin coin))
        {
            int randomIndex = Random.Range(0, _spawnPoints.Count);
            Vector3 randomSpawnPointPosition = _spawnPoints[randomIndex].transform.position;

            coin.transform.position = randomSpawnPointPosition;
        }
    }

    private void Disable(Coin coin)
    {
        _pool.Release(coin);
    }
}