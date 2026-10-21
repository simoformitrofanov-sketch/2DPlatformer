using UnityEngine;
using System.Collections;

public class SmoothHealthBarView : HealthBarView
{
    [SerializeField] private float _duration = 0.4f;

    private Coroutine _animation;

    protected override void OnDisable()
    {
        base.OnDisable();

        if (_animation != null)
        {
            StopCoroutine(_animation);
            _animation = null;
        }
    }

    protected override void Initialize(float current, float max)
    {
        base.Refresh(current, max);
    }

    protected override void Refresh(float current, float max)
    {
        if (_animation != null)
            StopCoroutine(_animation);

        float targetValue = current / max;
        _animation = StartCoroutine(Animate(targetValue));
    }

    private IEnumerator Animate(float targetValue)
    {
        float startValue = Value;
        float elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / _duration);

            Value = Mathf.Lerp(startValue, targetValue, progress);

            yield return null;
        }

        Value = targetValue;
    }
}