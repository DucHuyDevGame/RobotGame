using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObstacleHander : MonoBehaviour, IObstacleHandler
{
    private RobotController robot;
    private DataController data;
    public void Init(RobotController robot, DataController data)
    {
        this.robot = robot;
        this.data = data;
    }

    public void HandleObstacle(Vector2 origin, Vector2 direction, float distance, LayerMask layer)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, layer);
        Debug.DrawRay(origin, direction * distance, Color.green);
        if (hit.collider == null)
            return;
        WeaponsData weapons = data.ReloadWeapon();
        if(GameManager.Instance.cur_cf_Level.ID != 4)
        {
            if(weapons.movementData.movementType == MovementType.Wheels || weapons.movementData.movementType == MovementType.Tracks)
                robot.runRobot = false;
            else
            {
                if (weapons.sensorTypeData.sensorType != SensorsType.UltrasonicSensor)
                {
                    robot.runRobot = false;
                    DialogManager.Instance.ShowDialog(DialogIndex.DiedDialog);
                    Debug.DrawRay(origin, direction * distance, Color.red);
                    return;
                }
                else
                    robot.Jump();
            }
            
        }
        else
        {
            if (weapons.movementData.movementType == MovementType.Legs)
                robot.Jump();
            else
                robot.runRobot = false;
        }
        
    }
}
