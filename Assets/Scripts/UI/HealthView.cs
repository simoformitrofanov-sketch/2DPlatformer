using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Changed += Refresh;
    }

    protected virtual void OnDisable()
    {
        _health.Changed -= Refresh;
    }

    private void Start()
    {
        Initialize(_health.Current, _health.Max);
    }

    protected virtual void Initialize(float current, float max)
    {
        Refresh(current, max);
    }

    protected abstract void Refresh(float current, float max);
}