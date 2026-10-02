using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private PlayerInput _input;
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _body.velocity = new Vector2(_input.Horizontal * _speed, _body.velocity.y);
    }

    public void SetInput(PlayerInput input)
    {
        _input = input;
    }
}
