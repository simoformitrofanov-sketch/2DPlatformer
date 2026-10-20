using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _health.Changed += Refresh;
    }

    private void OnDisable()
    {
        _health.Changed -= Refresh;
    }

    private void Start()
    {
        Refresh(_health.Current, _health.Max);
    }

    private void Refresh(int current, int max)
    {
        _slider.value = (float)current / max;
    }
}
