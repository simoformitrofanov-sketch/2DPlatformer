using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimator : MonoBehaviour
{
    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    private static readonly int IsGroundedHash = Animator.StringToHash("IsGrounded");

    private Animator _animator;
    private Rigidbody2D _body;
    private GroundChecker _groundChecker;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _animator.SetFloat(SpeedHash, Mathf.Abs(_body.velocity.x));
        _animator.SetBool(IsGroundedHash, _groundChecker.IsGrounded);
    }

    public void SetGroundChecker(GroundChecker groundChecker)
    {
        _groundChecker = groundChecker;
    }
}