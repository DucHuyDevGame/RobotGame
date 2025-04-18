using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorTrigger : MonoBehaviour
{
    [SerializeField] float distanceFire;
    [SerializeField] LayerMask fireLayerMask;
    [SerializeField] GameObject obstacleCheck;
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
        if(RobotController.Instance.runRobot)
            ObstacleFire(obstacleCheck.transform.position, Vector2.right, distanceFire, fireLayerMask);
    }
    void ObstacleFire(Vector2 origin, Vector2 direction, float distance, LayerMask layer)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance,layer);
        Debug.DrawRay(origin, direction * distance, Color.green);
        if (hit.collider != null)
        {
            WeaponsData weapons = DataController.Instance.ReloadWeapon();
            if (weapons.sensorTypeData.sensorType != SensorsType.HeatSensor)
            {
                RobotController.Instance.runRobot = false;
                DialogManager.Instance.ShowDialog(DialogIndex.DiedDialog);
                Debug.DrawRay(origin, direction * distance, Color.red);
                return;
            }
            else
            {
                RobotController.Instance.runRobot = false;
                Debug.DrawRay(origin, direction * distance, Color.blue);
            }
        }
    }
}
