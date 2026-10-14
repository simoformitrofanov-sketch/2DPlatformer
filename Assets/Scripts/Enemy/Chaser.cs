using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Chaser : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private DirectionFlipper _flipper;
    private Rigidbody2D _body;
    private Attacker _attacker;
    private Transform _target;
    private bool _isActive;

    private void Awake()
    {
        _flipper = GetComponent<DirectionFlipper>();
        _body = GetComponent<Rigidbody2D>();
        _attacker = GetComponent<Attacker>();
    }

    public void SetTarget(Transform target) => _target = target;

    public void StartChase() => _isActive = true;
    public void StopChase()
    {
        _isActive = false;
        _body.velocity = Vector2.zero;
    }

    public void Move()
    {
        if (_isActive == false || _target == null) return;

        if (Vector2.Distance(transform.position, _target.position) <= _attacker.AttackRadius)
        {
            _body.velocity = Vector2.zero;
            return;
        }

        Vector2 direction = (_target.position - transform.position).normalized;
        _body.velocity = direction * _speed;
        _flipper.SetFacing(direction.x);
    }
}