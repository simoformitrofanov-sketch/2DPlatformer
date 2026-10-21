using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : HealthView
{
    [SerializeField] private Slider _slider;

    protected float Value
    {
        get => _slider.value;
        set => _slider.value = value;
    }

    protected override void Refresh(float current, float max)
    {
        Value = current / max;
    }
}
