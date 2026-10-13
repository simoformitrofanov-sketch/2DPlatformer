using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _radius = 5f;

    public bool SeesPlayer { get; private set; }

    private void FixedUpdate()
    { 
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _radius, _playerLayer);
        SeesPlayer = hit != null;
    }
}
