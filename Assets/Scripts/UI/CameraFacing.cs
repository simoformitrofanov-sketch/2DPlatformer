using UnityEngine;

public class CameraFacing : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    private void LateUpdate()
    {
        transform.rotation = _cameraTransform.rotation;
    }
}
