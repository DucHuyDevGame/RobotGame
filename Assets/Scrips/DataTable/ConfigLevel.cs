using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TaskType 
{ 
    Navigation = 1, 
    Transporting = 2, 
}
public enum EnvironmentType 
{ 
    Water = 1, 
    FlatGround = 2, 
    SoilGround = 3 
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

    [SerializeField] int objectForRobot; // 0 -> false; 1-> true
    public int Object => objectForRobot;

    [SerializeField] string sceneName;
    public string SceneName => sceneName;
}

public class ConfigLevel : BYDataTable<ConfigLevelRecord>
{
    public override ConfigCompare<ConfigLevelRecord> DefindCompare()
    {
        configCompare = new ConfigCompare<ConfigLevelRecord>("id");
        return configCompare;
    }
}
