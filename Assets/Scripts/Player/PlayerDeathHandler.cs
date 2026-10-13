using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private float _respawnDelay = 1f;

    private Health _health;
    private Player _player;
    private Rigidbody2D _body;
    private Animator _animator;
    private Collider2D _collider;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _player = GetComponent<Player>();
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        _health.Died += OnDied;
    }

    private void OnDestroy()
    {
        _health.Died -= OnDied;
    }

    private void OnDied()
    {
        StartCoroutine(RespawnRoutine());
    }

    private IEnumerator RespawnRoutine()
    {
        _player.SetControlEnabled(false);
        _body.velocity = Vector2.zero;
        _animator.SetTrigger("Die");

        yield return new WaitForSeconds(_respawnDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}