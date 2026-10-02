using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerJumper))]
[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    private void Awake()
    {
        PlayerInput input = GetComponent<PlayerInput>();
        PlayerMover mover = GetComponent<PlayerMover>();
        PlayerJumper jumper = GetComponent<PlayerJumper>();
        GroundChecker groundChecker = GetComponent<GroundChecker>();
        PlayerAnimator animator = GetComponent<PlayerAnimator>();
        animator.SetGroundChecker(groundChecker);

        mover.SetInput(input);
        jumper.SetDependencies(input, groundChecker);
    }
}