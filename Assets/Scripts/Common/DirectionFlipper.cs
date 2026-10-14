using UnityEngine;

public class DirectionFlipper : MonoBehaviour
{
    private bool _isFacingRight = true;

    public void SetFacing(float directionX)
    {
        if (directionX == 0f)
        {
            return;
        }

        bool shouldFaceRight = directionX > 0f;

        if (_isFacingRight == shouldFaceRight)
        {
            return;
        }

        transform.Rotate(0f, 180f, 0f);
        _isFacingRight = shouldFaceRight;
    }
}