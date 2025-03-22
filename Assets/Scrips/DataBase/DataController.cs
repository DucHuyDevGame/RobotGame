using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DataController : BYSingletonMono<DataController>
{
    public DataModel dataModel;
    public void InitData(Action callback)
    {
        dataModel.InitData(callback);
    }
    public PlayerInfo GetPlayerInfo()
    {
        PlayerInfo info = dataModel.ReadData<PlayerInfo>(DataSchema.INFO);
        return info;
    }
    public int GetGem()
    { 
        return dataModel.ReadData<int>(DataSchema.GEM);
    }
    public int GetGold()
    {
       return dataModel.ReadData<int>(DataSchema.GOLD);
    }
    public void AddGold(int number)
    {
        int gold = GetGold();
        gold += number;
        if (gold < 0)
            gold = 0;
        dataModel.UpdateData(DataSchema.GOLD, gold);
    }
    public void AddGem(int number)
    {
        int gem = GetGem();
        gem += number;
        if (gem < 0)
            gem = 0;
        dataModel.UpdateData(DataSchema.GEM, gem);
    }
    public void OnShopBuy(ConfigShopRecord cf)
    {
        if(cf.Shop_type==1)
        {
            AddGold(cf.Value);
        }
        else
        {
            AddGem(cf.Value);
        }
    }
    public WeaponsData ReloadWeapon()
    {
        return dataModel.ReadData<WeaponsData>(DataSchema.WEAPON);
    }
    public void AddWeapon(string typeConfig, string name)
    {
        WeaponsData weaponsData = ReloadWeapon();
        if(typeConfig.Equals("Movement"))
        {
            ConfigMovementRecord cf = ConfigManager.Instance.configMovement.GetRecordName(name);
            weaponsData.movementData.image = cf.PrefabImage;
            weaponsData.movementData.movementType = cf.MovementType;
        }
        else if(typeConfig.Equals("Manipulator"))
        {
            ConfigManipulatorRecord cf = ConfigManager.Instance.configManipulator.GetRecordName(name);
            weaponsData.manipulatorData.image = cf.PrefabImage;
            weaponsData.manipulatorData.manipulatorType = cf.ManipulatorType;
        }
        else if(typeConfig.Equals("Sensor"))
        {
            ConfigSensorRecord cf = ConfigManager.Instance.configSensor.GetRecordName(name);
            weaponsData.sensorTypeData.image = cf.PrefabImage;
            weaponsData.sensorTypeData.sensorType = cf.SensorType;
        }
        else if(typeConfig.Equals("PowerSource"))
        {
            ConfigPowerSourceRecord cf = ConfigManager.Instance.configPowerSource.GetRecordName(name);
            weaponsData.powerSourceTypeData.image = cf.PrefabImage;
            weaponsData.powerSourceTypeData.powerSourceType = cf.PowerSourceType;
        }
        dataModel.UpdateData(DataSchema.WEAPON, weaponsData);
    }
}
