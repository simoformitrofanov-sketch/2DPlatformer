using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _checkPoint;
    [SerializeField] private float _checkRadius = 0.15f;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded { get; private set; }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(_checkPoint.position, _checkRadius, _groundLayer);
    }
}
