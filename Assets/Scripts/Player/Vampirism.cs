using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(VampirismDamager))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _cooldown = 4f;

    private Coroutine _abilityRoutine;
    private VampirismDamager _damager;
    private readonly WaitForFixedUpdate _fixedUpdateWait = new WaitForFixedUpdate();

    public event Action Started;
    public event Action CooldownStarted;
    public event Action Stopped;
    public event Action<float> ProgressChanged;

    private void Awake()
    {
        _damager = GetComponent<VampirismDamager>();
    }

    private void OnDisable()
    {
        if (_abilityRoutine != null)
        {
            StopCoroutine(_abilityRoutine);
            _abilityRoutine = null;
        }

        Stopped?.Invoke();
    }

    public void Activate()
    {
        if (_abilityRoutine != null)
            return;

        _abilityRoutine = StartCoroutine(AbilityRoutine());
    }

    private IEnumerator AbilityRoutine()
    {
        yield return DrainRoutine();
        yield return CooldownRoutine();

        Stopped?.Invoke();
        _abilityRoutine = null;
    }

    private IEnumerator DrainRoutine()
    {
        Started?.Invoke();

        float elapsed = 0f;

        while (elapsed < _duration)
        {
            yield return _fixedUpdateWait;

            float deltaTime = Mathf.Min(Time.fixedDeltaTime, _duration - elapsed);

            _damager.DrainHealth(deltaTime);
            elapsed += deltaTime;

            ProgressChanged?.Invoke(1f - elapsed / _duration);
        }
    }

    private IEnumerator CooldownRoutine()
    {
        CooldownStarted?.Invoke();

        float elapsed = 0f;

        while (elapsed < _cooldown)
        {
            yield return _fixedUpdateWait;

            float deltaTime = Mathf.Min(Time.fixedDeltaTime, _cooldown - elapsed);

            elapsed += deltaTime;

            ProgressChanged?.Invoke(elapsed / _cooldown);
        }
    }
}