using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float SmoothSpeed = 0.125f;
    public Vector3 offset;
    private void Start()
    {
        transform.position = Target.position + offset;
    }
    private void FixedUpdate()
    {
        if (Target == null)
        {
            return;
        }

        Vector3 desiredPosition = Target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
        transform.position = smoothedPosition;
    }
}
