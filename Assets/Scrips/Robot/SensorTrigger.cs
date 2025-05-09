using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SensorTrigger : MonoBehaviour
{
    [SerializeField] float distanceFire, distanceWall;
    [SerializeField] LayerMask fireLayerMask, wallLayer;
    [SerializeField] GameObject obstacleCheck, fireCheck;
    [SerializeField] FireObstacleHandler fireHandler;
    [SerializeField] WallObstacleHander wallObstacleHander;
    private void Start()
    {
        if(fireHandler != null)
            fireHandler.Init(RobotController.Instance, DataController.Instance, fireCheck);
        if (wallObstacleHander != null)
            wallObstacleHander.Init(RobotController.Instance, DataController.Instance);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(Utilities.CheckPoint))
        {
            collision.GetComponent<Animator>().SetTrigger("activate");
            RobotController.Instance.runRobot = false;
        }
    }
    private void Update()
    {
        if (!RobotController.Instance.runRobot)
            return;
        if (fireHandler!= null)
            fireHandler.HandleObstacle(obstacleCheck.transform.position, Vector2.right, distanceFire, fireLayerMask);
        if (wallObstacleHander!= null)
            wallObstacleHander.HandleObstacle(obstacleCheck.transform.position, Vector2.right, distanceWall, wallLayer);
    }
}
