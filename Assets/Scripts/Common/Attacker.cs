using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(TargetFinder))]
[RequireComponent(typeof(AttackAnimator))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _radius = 0.7f;
    [SerializeField] private int _damage = 25;
    [SerializeField] private float _cooldown = 0.5f;
    [SerializeField] private float _hitDelay = 0.15f;

    private Health _health;
    private TargetFinder _targetFinder;
    private AttackAnimator _attackAnimator;
    private Coroutine _attackRoutine;

    public float AttackRadius => _radius;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _targetFinder = GetComponent<TargetFinder>();
        _attackAnimator = GetComponent<AttackAnimator>();
    }

    private void OnEnable()
    {
        _attackRoutine = StartCoroutine(AttackLoop());
    }

    private void OnDisable()
    {
        if (_attackRoutine != null)
        {
            StopCoroutine(_attackRoutine);
            _attackRoutine = null;
        }
    }

    private IEnumerator AttackLoop()
    {
        WaitForSeconds wait = new WaitForSeconds(_cooldown);
        WaitForSeconds hitWait = new WaitForSeconds(_hitDelay);

        while (enabled)
        {
            if (_health.IsDead)
            {
                yield return wait;
                continue;
            }

            List<Health> targets = _targetFinder.FindTargets(_radius, _targetLayer);

            if (targets.Count > 0)
            {
                _attackAnimator.PlayAttack();
                yield return hitWait;

                DealDamage(targets);
            }

            yield return wait;
        }
    }

    private void DealDamage(List<Health> targets)
    {
        foreach (Health target in targets)
        {
            if (target == null)
                continue;

            if (target.IsDead)
                continue;

            target.TakeDamage(_damage);
        }
    }
}