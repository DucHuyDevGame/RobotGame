using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        dataModel.UpdateData(DataSchema.WEAPON, weaponsData);
    }
    public List<MissionData> GetMissionData()
    {
        return dataModel.ReadData<List<MissionData>>(DataSchema.MISSIONS);
    }
    public void UpdateMissionData(int id, int start)
    {
        var missionDatas = dataModel.ReadData<Dictionary<string, MissionData>>(DataSchema.DIC_MISSION);
        foreach (var key in missionDatas.Keys.ToList())
        {
            var missionData = missionDatas[key];
            if (id == missionData.id)
            {
                missionData.missionComplete = true;
                if (missionData.star < start)
                    missionData.star = start;
            }
            else
            {
                if (id + 1 == missionData.id)
                {
                    missionData.missionComplete = false;
                    missionData.star = 0;
                    break;
                }
            }
        }
        dataModel.UpdateData(DataSchema.DIC_MISSION, missionDatas);

        List<MissionData> missionDatasList = GetMissionData();
        for (int i = 0; i < missionDatasList.Count; i++)
        {
            if (missionDatasList[i].id == id)
            {
                missionDatasList[i].missionComplete = true;
                if (missionDatasList[i].star < start)
                    missionDatasList[i].star = start;
            }
            else
            {
                if (missionDatasList[i].id == id + 1)
                {
                    missionDatasList[i].missionComplete = false;
                    missionDatasList[i].star = 0;
                    break;
                }
            }
        }
        dataModel.UpdateData(DataSchema.MISSIONS, missionDatasList);
    }
}
