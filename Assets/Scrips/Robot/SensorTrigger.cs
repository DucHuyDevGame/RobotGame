using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SensorTrigger : MonoBehaviour
{
    [SerializeField] float distanceFire, distanceWall;
    [SerializeField] LayerMask fireLayerMask, wallLayer, objectLayer;
    [SerializeField] GameObject obstacleCheck, fireCheck, objectCheck;
    [SerializeField] FireObstacleHandler fireHandler;
    [SerializeField] WallObstacleHander wallObstacleHander;
    [SerializeField] ObjectObstacleHandler obstacleHandler;
    private void Start()
    {
        if (fireHandler != null)
            fireHandler.Init(RobotController.Instance, DataController.Instance, fireCheck);
        if (wallObstacleHander != null)
            wallObstacleHander.Init(RobotController.Instance, DataController.Instance);
        if (obstacleHandler != null)
            obstacleHandler.Init(RobotController.Instance, DataController.Instance, objectCheck);
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
        if (obstacleHandler != null)
            obstacleHandler.HandleObstacle(obstacleCheck.transform.position, Vector2.right, distanceWall, objectLayer);
    }
}
