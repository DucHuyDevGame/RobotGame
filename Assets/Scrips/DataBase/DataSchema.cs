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
    public string nickname;
    public int level;
    public int exp;
}
[Serializable]
public class PlayerInventory
{
    public int gold;
    public int gem;
    [SerializeField] public WeaponsData weaponData;
}
[Serializable]
public class PlayerMissionData
{
    public int currentMission;
    [SerializeField]
    public Dictionary<string, MissionData> dic_mission = new Dictionary<string, MissionData>();
}
[Serializable]
public class MissionData
{
    public int id;
    public int star;
}
[Serializable]
public class WeaponsData
{
    public MovementData movementData;
    public ManipulatorData manipulatorData;
    public SensorData sensorTypeData;
    public PowerSourceData powerSourceTypeData;
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
public class PowerSourceData
{
    public string image;
    public PowerSourceType powerSourceType;
}