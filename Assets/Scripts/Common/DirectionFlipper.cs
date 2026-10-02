using UnityEngine;

public class DirectionFlipper : MonoBehaviour
{
    private Vector3 _previousPosition;

    private void Awake()
    {
        _previousPosition = transform.position;
    }

    private void Update()
    {
        float deltaX = transform.position.x - _previousPosition.x;

        if (deltaX != 0)
            SetFacing(deltaX > 0);

        _previousPosition = transform.position;
    }

    private void SetFacing(bool facingRight)
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (facingRight ? 1 : -1);
        transform.localScale = scale;
    }
}