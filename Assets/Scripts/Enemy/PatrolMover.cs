using UnityEngine;

public class PatrolMover : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed = 1f;

    private DirectionFlipper _flipper;
    private Transform _currentTarget;
    private bool _isActive;

    private void Start()
    {
        _flipper = GetComponent<DirectionFlipper>();
        _currentTarget = _pointB;
    }

    public void StartMove() => _isActive = true;
    public void StopMove() => _isActive = false;

    private void Update()
    {
        if (_isActive == false) return;

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);
        _flipper.SetFacing(_currentTarget.position.x - transform.position.x);

        if (transform.position == _currentTarget.position)
            _currentTarget = _currentTarget == _pointA ? _pointB : _pointA;
    }
}