using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    [SerializeField] Vector3 offset = new Vector3(0f, 0f, -10f);
    [SerializeField] float smoothTime = 0.15f;
    Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        if (!target.GetComponent<RobotController>().runRobot)
            return;
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
