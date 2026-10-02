using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _minX = -8f;
    [SerializeField] private float _maxX = 8f;
    [SerializeField] private float _spawnY = -1.5f;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private int _maxCoins = 5;

    private readonly List<Coin> _coins = new List<Coin>();
    private Coroutine _spawnRoutine;

    private void OnEnable()
    {
        _spawnRoutine = StartCoroutine(SpawnLoop());
    }

    private void OnDisable()
    {
        if (_spawnRoutine != null)
        {
            StopCoroutine(_spawnRoutine);
            _spawnRoutine = null;
        }
    }

    private IEnumerator SpawnLoop()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnInterval);

        while (enabled)
        {
            yield return wait;

            if (_coins.Count < _maxCoins)
                Spawn();
        }
    }

    private void Spawn()
    {
        float x = Random.Range(_minX, _maxX);
        Vector3 position = new Vector3(x, _spawnY, 0f);

        Coin coin = Instantiate(_coinPrefab, position, Quaternion.identity, transform);
        coin.Collected += OnCoinCollected;
        _coins.Add(coin);
    }

    private void OnCoinCollected(Coin coin)
    {
        coin.Collected -= OnCoinCollected;
        _coins.Remove(coin);
        Destroy(coin.gameObject);
    }
}
