using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Enemy))]
public class EnemyDeathHandler : MonoBehaviour
{
    private Enemy _enemy;
    private Health _health;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _health = GetComponent<Health>();
        _health.Died += OnDied;
    }

    private void OnDestroy()
    {
        _health.Died -= OnDied;
    }

    private void OnDied()
    {
        _enemy.StopAll();
        Destroy(gameObject);
    }
}