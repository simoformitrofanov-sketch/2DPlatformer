using UnityEngine;
using UnityEngine.UI;

public class VampirismBarView : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private Slider _timeBar;

    private void Awake()
    {
        Fill();
    }

    private void OnEnable()
    {
        _vampirism.Started += Fill;
        _vampirism.CooldownStarted += Empty;
        _vampirism.Stopped += Fill;
        _vampirism.ProgressChanged += SetProgress;
    }

    private void OnDisable()
    {
        _vampirism.Started -= Fill;
        _vampirism.CooldownStarted -= Empty;
        _vampirism.Stopped -= Fill;
        _vampirism.ProgressChanged -= SetProgress;
    }

    private void Fill()
    {
        SetProgress(1f);
    }

    private void Empty()
    {
        SetProgress(0f);
    }

    private void SetProgress(float progress)
    {
        _timeBar.value = Mathf.Clamp01(progress);
    }
}