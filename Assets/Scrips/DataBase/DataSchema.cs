using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSchema 
{
    public const string INFO = "info";
    public const string INVENTORY = "inventory";
    public const string GOLD = "inventory/gold";
    public const string GEM = "inventory/gem";
    public const string WEAPON = "inventory/weaponData";
    public const string DIC_MISSION = "missionData/dic_mission";
    public const string MISSIONS = "info/missions";
}
[Serializable]
public class PlayerData
{
    [SerializeField]
    public PlayerInfo info;
    [SerializeField]
    public PlayerInventory inventory;
    public PlayerMissionData missionData;
}
[Serializable]
public class PlayerInfo
{
    [SerializeField] public List<MissionData> missions = new List<MissionData>();
}
[Serializable]
public class PlayerInventory
{
    public int gold;
    public int gem;
    [SerializeField] public WeaponsData weaponData;
}
[Serializable]
public class WeaponsData
{
    public MovementData movementData;
    public ManipulatorData manipulatorData;
    public SensorData sensorTypeData;
}
[Serializable]
public class MovementData
{
    public string image;
    public MovementType movementType;
}
[Serializable]
public class ManipulatorData
{
    public string image;
    public ManipulatorType manipulatorType;
}
[Serializable]
public class SensorData
{
    public string image;
    public SensorsType sensorType;
}
[Serializable]
public class PlayerMissionData
{
    [SerializeField]
    public Dictionary<string, MissionData> dic_mission = new Dictionary<string, MissionData>();
}
[Serializable]
public class MissionData
{
    public int id;
    public int star;
    public bool missionComplete;
}