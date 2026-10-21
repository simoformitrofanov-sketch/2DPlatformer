using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(TargetFinder))]
public class VampirismDamager : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private float _damagePerSecond = 10f;

    private Health _health;
    private TargetFinder _targetFinder;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _targetFinder = GetComponent<TargetFinder>();
    }

    public void Tick(float deltaTime)
    {
        Health target = FindNearestTarget();

        if (target == null)
            return;

        float damage = Mathf.Min(
            _damagePerSecond * deltaTime, target.Current);

        target.TakeDamage(damage);
        _health.Heal(damage);
    }

    private Health FindNearestTarget()
    {
        List<Health> targets = _targetFinder.FindTargets(
            _radius, _targetLayer);

        Health nearestTarget = null;
        float nearestDistance = float.MaxValue;

        foreach (Health target in targets)
        {
            float distance = Vector2.Distance(
                transform.position, target.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestTarget = target;
            }
        }

        return nearestTarget;
    }
}