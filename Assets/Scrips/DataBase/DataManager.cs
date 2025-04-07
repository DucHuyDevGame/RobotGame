using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : BYSingletonMono<DataManager>
{
    public List<MissionData> missonsData;
    public WeaponsData dataWeapon;
    public PlayerData InitData()
    {
        PlayerData playerData = new PlayerData();
        PlayerInfo info = new()
        {
            missions = missonsData,
        };
        playerData.info = info;

        PlayerInventory inventory = new()
        {
            gold = 100,
            gem = 10,
            weaponData = dataWeapon,
        };
        playerData.inventory = inventory;

        PlayerMissionData missionData = new();
        Dictionary<string, MissionData> missions = new();
        foreach (MissionData mis in missonsData)
            missions.Add(mis.id.Tokey(), mis);
        missionData.dic_mission = missions;
        playerData.missionData = missionData;
        return playerData;
    }
}
