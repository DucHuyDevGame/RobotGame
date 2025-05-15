using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TaskType 
{
    MoveToPosition = 1,
    ObstacleTraversal = 2,
    DeliverWithTraversal = 3,
    AutoLightOnDark = 4,
    NavigateAndExtinguish = 5,
}
public enum EnvironmentType 
{
    FlatLight = 1,
    FlatLightToDark = 2,
}
[Flags]
public enum ObjectType
{
    None = 0,
    Fire = 1 << 0,    // 1
    Obstacle = 1 << 1, // 2
    Goods = 1 << 2     // 4
}
[Serializable]
public class ConfigLevelRecord
{
    [SerializeField] int id;
    public int ID => id;
    [SerializeField] TaskType taskType;
    public TaskType TaskType => taskType;

    [SerializeField] EnvironmentType environmentType;
    public EnvironmentType EnvironmentType => environmentType;

    [SerializeField] ObjectType objectType;
    public ObjectType ObjectTypes => objectType;

    //[SerializeField] bool objectForRobot;
    //public bool ObjectForRobot => objectForRobot;

    [SerializeField] string sceneName;
    public string SceneName => sceneName;

    [SerializeField] ManipulatorType manipulatorType;
    public ManipulatorType ManipulatorType => manipulatorType;

    [SerializeField] MovementType movementType;
    public MovementType MovementType => movementType;

    [SerializeField] SensorsType sensorsType;
    public SensorsType SensorsType => sensorsType;

    [SerializeField] int start;
    public int Start => start;

    [SerializeField] string missionName;
    public string MisisonName => missionName;

    [SerializeField] float timeFinished;
    public float TimeFinished => timeFinished;
}

public class ConfigLevel : BYDataTable<ConfigLevelRecord>
{
    public override ConfigCompare<ConfigLevelRecord> DefindCompare()
    {
        configCompare = new ConfigCompare<ConfigLevelRecord>("id");
        return configCompare;
    }
}
