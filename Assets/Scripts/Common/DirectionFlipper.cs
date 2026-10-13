using UnityEngine;

public class DirectionFlipper : MonoBehaviour
{
    public void SetFacing(float directionX)
    {
        if (directionX == 0f)
            return;

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (directionX > 0f ? 1f : -1f);
        transform.localScale = scale;
    }
}