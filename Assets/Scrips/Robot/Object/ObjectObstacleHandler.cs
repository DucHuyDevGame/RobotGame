using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectObstacleHandler : MonoBehaviour ,IObstacleHandler
{
    private RobotController robot;
    private DataController data;
    private GameObject objectGame;
    public void Init(RobotController robot, DataController data, GameObject objectGame)
    {
        this.robot = robot;
        this.data = data;
        this.objectGame = objectGame;
    }

    public void HandleObstacle(Vector2 origin, Vector2 direction, float distance, LayerMask layer)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, layer);
        Debug.DrawRay(origin, direction * distance, Color.green);
        if (hit.collider == null)
            return;
        WeaponsData weapons = data.ReloadWeapon();

        if (weapons.sensorTypeData.sensorType != SensorsType.UltrasonicSensor)
        {
            robot.runRobot = false;
            return;
        }
        if (weapons.manipulatorData.manipulatorType != ManipulatorType.Gripper)
        {
            robot.runRobot = false;
            return;
        }
        objectGame.SetActive(false);
        CharacterBufferControl.Instance.AddGripperObject();
    }
}
