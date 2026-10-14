using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(AttackAnimator))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _radius = 0.7f;
    [SerializeField] private int _damage = 25;
    [SerializeField] private float _cooldown = 0.5f;
    [SerializeField] private float _hitDelay = 0.15f;

    private Health _health;
    private AttackAnimator _attackAnimator;
    private Coroutine _attackRoutine;

    public float AttackRadius => _radius;

    private void Awake()
    {
        _health = GetComponent<Health>();
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

            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _radius, _targetLayer);

            if (HasLivingTarget(hits))
            {
                _attackAnimator.PlayAttack();
                yield return hitWait;

                DealDamage(hits);
            }

            yield return wait;
        }
    }

    private bool HasLivingTarget(Collider2D[] hits)
    {
        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out Health target) && target.IsDead == false)
                return true;
        }

        return false;
    }

    private void DealDamage(Collider2D[] hits)
    {
        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out Health target) && target.IsDead == false)
                target.TakeDamage(_damage);
        }
    }
}