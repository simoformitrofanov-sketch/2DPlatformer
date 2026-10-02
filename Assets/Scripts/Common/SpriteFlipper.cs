using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteFlipper : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Vector3 _previousPosition;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _previousPosition = transform.position;
    }

    private void Update()
    {
        float deltaX = transform.position.x - _previousPosition.x;

        if (deltaX != 0)
            _renderer.flipX = deltaX < 0;

        _previousPosition = transform.position;
    }
}
