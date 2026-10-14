using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max = 100;

    private int _current;

    public event Action<int, int> Changed;
    public event Action Died;

    public int Max => _max;
    public int Current => _current;
    public bool IsDead => _current <= 0;

    private void Awake()
    {
        _current = _max;
    }

    public void TakeDamage(int amount)
    {
        if (IsDead)
            return;

        _current = Mathf.Max(_current - amount, 0);
        Changed?.Invoke(_current, _max);

        if (IsDead)
            Died?.Invoke();
    }

    public void FullHeal()
    {
        _current = _max;
        Changed?.Invoke(_current, _max);
    }
}
