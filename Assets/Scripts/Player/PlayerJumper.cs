using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 8f;

    private PlayerInput _input;
    private GroundChecker _groundChecker;
    private Rigidbody2D _body;
    private bool _jumpQueued;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(_jumpQueued && _groundChecker.IsGrounded)
            _body.velocity = new Vector2(_body.velocity.x, _jumpForce);

        _jumpQueued = false;
    }

    private void OnDestroy()
    {
            _input.JumpPressed -= OnJumpPressed;
    }

    public void SetDependencies(PlayerInput input, GroundChecker groundChecker)
    {
        _input = input;
        _groundChecker = groundChecker;
        _input.JumpPressed += OnJumpPressed;
    }

    private void OnJumpPressed()
    {
        _jumpQueued = true;
    }
}
