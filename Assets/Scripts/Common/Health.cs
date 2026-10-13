using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    private int _currentHealth;

    public event Action<int, int> HealthChanged;
    public event Action Died;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;
    public bool IsDead => _currentHealth <= 0;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (IsDead)
            return;

        _currentHealth = Mathf.Max(_currentHealth - amount, 0);
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (IsDead)
            Died?.Invoke();
    }

    public void FullHeal()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
