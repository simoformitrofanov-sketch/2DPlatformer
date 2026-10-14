using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _body;
    private GroundChecker _groundChecker;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
    }

    public void Refresh()
    {
        _animator.SetFloat(AnimatorParameters.Speed, Mathf.Abs(_body.velocity.x));
        _animator.SetBool(AnimatorParameters.IsGrounded, _groundChecker.IsGrounded);
    }

    public void PlayDeath()
    {
        _animator.SetTrigger(AnimatorParameters.Die);
    }

    public void SetGroundChecker(GroundChecker groundChecker)
    {
        _groundChecker = groundChecker;
    }
}