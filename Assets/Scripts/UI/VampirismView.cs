using UnityEngine;
using UnityEngine.UI;

public class VampirismView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _radiusRenderer;
    [SerializeField] private Slider _timeBar;

    private void Awake()
    {
        Stop();
    }

    public void StartAbility()
    {
        _radiusRenderer.enabled = true;
        SetProgress(1f);
    }

    public void StartCooldown()
    {
        _radiusRenderer.enabled = false;
        SetProgress(0f);

    }

    public void Stop()
    {
        _radiusRenderer.enabled = false;
        SetProgress(1f);
    }

    public void SetProgress(float progress)
    {
        _timeBar.value = Mathf.Clamp01(progress);
    }
}