using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorTrigger : MonoBehaviour
{
    [SerializeField] float distanceFire;
    [SerializeField] LayerMask fireLayerMask, objectLayerMask;
    [SerializeField] GameObject obstacleCheck, fireCheck;
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
        ObstacleFire(obstacleCheck.transform.position, Vector2.right, distanceFire, fireLayerMask);
    }
    void ObstacleObject(Vector2 origin, Vector2 direction, float distance, LayerMask layer)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, layer);
        Debug.DrawRay(origin, direction * distance, Color.green);
        if (hit.collider != null)
        {
            Debug.LogError("Hit object");
        }
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
                if(weapons.manipulatorData.manipulatorType == ManipulatorType.FireExtinguisherSpray)
                    StartCoroutine(WaitTimeRun());
                Debug.DrawRay(origin, direction * distance, Color.blue);
            }
        }
    }
    IEnumerator WaitTimeRun()
    {
        yield return new WaitForSeconds(0.2f);
        fireCheck.SetActive(false);
        RobotController.Instance.runRobot = true;
    }
}
