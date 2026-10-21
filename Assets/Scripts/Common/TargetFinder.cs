using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    public List<Health> FindTargets(float radius, LayerMask targetLayer)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position, radius, targetLayer);

        List<Health> targets = new List<Health>();

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out Health target) == false)
                continue;

            if (target.IsDead)
                continue;

            if (targets.Contains(target))
                continue;

            targets.Add(target);
        }

        return targets;
    }
}