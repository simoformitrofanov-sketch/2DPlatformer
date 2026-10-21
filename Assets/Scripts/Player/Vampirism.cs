using UnityEngine;
using System.Collections;

[RequireComponent(typeof(VampirismDamager))]
[RequireComponent(typeof(VampirismView))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _cooldown = 4f;

    private Coroutine _abilityRoutine;
    private VampirismDamager _damager;
    private VampirismView _view;

    private void Awake()
    {
        _damager = GetComponent<VampirismDamager>();
        _view = GetComponent<VampirismView>();
    }

    private void OnDisable()
    {
        if (_abilityRoutine != null)
        {
            StopCoroutine(_abilityRoutine);
            _abilityRoutine = null;
        }

        _view.Stop();
    }

    public void Activate()
    {
        if (_abilityRoutine != null)
            return;

        _abilityRoutine = StartCoroutine(AbilityRoutine());
    }

    private IEnumerator AbilityRoutine()
    {
        _view.StartAbility();

        float elapsed = 0f;

        while (elapsed < _duration)
        {
            float deltaTime = Mathf.Min(Time.deltaTime, _duration - elapsed);

            _damager.Tick(deltaTime);
            elapsed += deltaTime;
            _view.SetProgress(1f - elapsed / _duration);
            yield return null;
        }

        _view.StartCooldown();

        elapsed = 0f;

        while (elapsed < _cooldown)
        {
            elapsed += Time.deltaTime;
            _view.SetProgress(elapsed / _cooldown);
            yield return null;
        }

        _view.Stop();
        _abilityRoutine = null;
    }
}