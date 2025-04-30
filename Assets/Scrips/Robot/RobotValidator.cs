using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotValidator : MonoBehaviour
{
    public void CheckRobotCondition(WeaponsData weaponData)
    {
        ConfigLevelRecord configLevelRecord = GameManager.Instance.cur_cf_Level;
        switch (configLevelRecord.ID)
        {
            case 1:
                if (weaponData.movementData.movementType == MovementType.Wheels)
                    RobotController.Instance.runRobot = true;
                else
                    RobotController.Instance.runRobot = false;
                break;
            case 2:
                if (weaponData.movementData.movementType == MovementType.Wheels
                    && weaponData.sensorTypeData.sensorType == SensorsType.HeatSensor
                    && weaponData.manipulatorData.manipulatorType == ManipulatorType.FireExtinguisherSpray)
                    RobotController.Instance.runRobot = true;
                else
                    RobotController.Instance.runRobot = false;
                break;
            case 3:
                if (weaponData.movementData.movementType == MovementType.Wheels
                    && weaponData.sensorTypeData.sensorType == SensorsType.LightSensor
                    && weaponData.manipulatorData.manipulatorType == ManipulatorType.LightBulb)
                    RobotController.Instance.runRobot = true;
                else
                    RobotController.Instance.runRobot = false;
                break;
        }
    }
}
