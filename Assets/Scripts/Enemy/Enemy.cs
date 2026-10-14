using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyVision _vision;
    [SerializeField] private PatrolMover _patrol;
    [SerializeField] private Chaser _chaser;
    [SerializeField] private Transform _playerTarget;

    private bool _isChasing;

    private void Start()
    {
        _chaser.SetTarget(_playerTarget);
        _patrol.StartMove();
    }

    private void Update()
    {
        _vision.Check();
        UpdateState();
        UpdateMovement();
    }

    private void FixedUpdate()
    {
        if (_isChasing)
        {
            _chaser.Move();
        }
    }

    public void StopAll()
    {
        _patrol.StopMove();
        _chaser.StopChase();
    }

    private void UpdateState()
    {
        bool sees = _vision.SeesPlayer;

        if (sees == _isChasing)
        {
            return;
        }

        _isChasing = sees;

        if (_isChasing)
        {
            _patrol.StopMove();
            _chaser.StartChase();
        }
        else
        {
            _patrol.StartMove();
            _chaser.StopChase();
        }
    }

    private void UpdateMovement()
    {
        if (_isChasing == false)
        {
            _patrol.Move();
        }
    }
}