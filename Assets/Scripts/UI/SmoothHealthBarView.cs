using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBarView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed = 0.5f;

    private float _targetValue;

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
        _slider.value = _targetValue;
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(
            _slider.value,
            _targetValue,
            _speed * Time.deltaTime);
    }

    private void Refresh(int current, int max)
    {
        _targetValue = (float)current / max;
    }
}