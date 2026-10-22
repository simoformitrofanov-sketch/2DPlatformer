using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max = 100;

    public event Action<float, float> Changed;
    public event Action Died;

    public float Max => _max;
    public float CurrentHealth { get; private set; }
    public bool IsDead => CurrentHealth <= 0f;

    private void Awake()
    {
        CurrentHealth = _max;
    }

    public void TakeDamage(float amount)
    {
        if (amount < 0f)
            return;

        if (IsDead)
            return;

        SetCurrent(CurrentHealth - amount);

        if (IsDead)
            Died?.Invoke();
    }

    public void Heal(float amount)
    {
        if (amount < 0f)
            return;

        if (IsDead)
            return;

        SetCurrent(CurrentHealth + amount);
    }

    private void SetCurrent(float value)
    {
        CurrentHealth = Mathf.Clamp(value, 0f, Max);
        Changed?.Invoke(CurrentHealth, Max);
    }
}
