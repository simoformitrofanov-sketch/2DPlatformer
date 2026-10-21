using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max = 100;

    public event Action<float, float> Changed;
    public event Action Died;

    public float Max => _max;
    public float Current { get; private set; }
    public bool IsDead => Current <= 0f;

    private void Awake()
    {
        Current = _max;
    }

    public void TakeDamage(float amount)
    {
        if (amount < 0f)
            return;

        if (IsDead)
            return;

        SetCurrent(Current - amount);

        if (IsDead)
            Died?.Invoke();
    }

    public void Heal(float amount)
    {
        if (amount < 0f)
            return;

        if (IsDead)
            return;

        SetCurrent(Current + amount);
    }

    private void SetCurrent(float value)
    {
        Current = Mathf.Clamp(value, 0f, Max);
        Changed?.Invoke(Current, Max);
    }
}
