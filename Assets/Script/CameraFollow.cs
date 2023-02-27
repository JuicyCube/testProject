using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // the target to follow
    public float smoothing = 5f;  // how quickly the camera should follow the target
    public Vector3 offset;   // offset between the target and the camera

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;   // calculate the target position with offset
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);   // move the camera to the target position smoothly
    }
}
