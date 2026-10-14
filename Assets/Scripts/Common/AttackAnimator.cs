using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(AnimatorParameters.Attack);
    }
}