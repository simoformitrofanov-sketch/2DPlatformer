using UnityEngine;

public class VampirismRadiusView : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private SpriteRenderer _radiusRenderer;

    private void Awake()
    {
        Hide();
    }

    private void OnEnable()
    {
        _vampirism.Started += Show;
        _vampirism.CooldownStarted += Hide;
        _vampirism.Stopped += Hide;
    }

    private void OnDisable()
    {
        _vampirism.Started -= Show;
        _vampirism.CooldownStarted -= Hide;
        _vampirism.Stopped -= Hide;

        Hide();
    }

    private void Show()
    {
        _radiusRenderer.enabled = true;
    }

    private void Hide()
    {
        _radiusRenderer.enabled = false;
    }
}