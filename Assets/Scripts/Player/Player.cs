using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerJumper))]
[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    private PlayerInput _input;
    private PlayerMover _mover;
    private PlayerJumper _jumper;
    private Attacker _attacker;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _mover = GetComponent<PlayerMover>();
        _jumper = GetComponent<PlayerJumper>();
        _attacker = GetComponent<Attacker>();
        GroundChecker groundChecker = GetComponent<GroundChecker>();
        PlayerAnimator animator = GetComponent<PlayerAnimator>();

        animator.SetGroundChecker(groundChecker);
        _mover.SetInput(_input);
        _jumper.SetDependencies(_input, groundChecker);
    }

    public void SetControlEnabled(bool isEnabled)
    {
        _input.enabled = isEnabled;
        _mover.enabled = isEnabled;
        _jumper.enabled = isEnabled;
        _attacker.enabled = isEnabled;
    }
}