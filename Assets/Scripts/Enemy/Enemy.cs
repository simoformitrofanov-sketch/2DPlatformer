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
        bool sees = _vision.SeesPlayer;

        if (sees == _isChasing) return;

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

    public void StopAll()
    {
        _patrol.StopMove();
        _chaser.StopChase();
    }
}