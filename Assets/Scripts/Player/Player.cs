using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerJumper))]
[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Vampirism))]
public class Player : MonoBehaviour
{
    private PlayerInput _input;
    private PlayerMover _mover;
    private PlayerJumper _jumper;
    private Attacker _attacker;
    private GroundChecker _groundChecker;
    private PlayerAnimator _animator;
    private Vampirism _vampirism;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _mover = GetComponent<PlayerMover>();
        _jumper = GetComponent<PlayerJumper>();
        _attacker = GetComponent<Attacker>();
        _groundChecker = GetComponent<GroundChecker>();
        _animator = GetComponent<PlayerAnimator>();
        _vampirism = GetComponent<Vampirism>();

        _animator.SetGroundChecker(_groundChecker);
        _mover.SetInput(_input);
        _jumper.SetDependencies(_input, _groundChecker);
    }

    private void OnEnable()
    {
        _input.VampirismPressed += _vampirism.Activate;
    }

    private void OnDisable()
    {
        _input.VampirismPressed -= _vampirism.Activate;
    }

    private void Update()
    {
        if (_input.enabled)
        {
            _input.Read();
        }

        _animator.Refresh();
    }

    private void FixedUpdate()
    {
        _groundChecker.Check();

        if (_mover.enabled)
        {
            _mover.Move();
        }

        if (_jumper.enabled)
        {
            _jumper.Jump();
        }
    }

    public void SetControlEnabled(bool isEnabled)
    {
        _input.enabled = isEnabled;
        _mover.enabled = isEnabled;
        _jumper.enabled = isEnabled;
        _attacker.enabled = isEnabled;
        _vampirism.enabled = isEnabled;
    }
}