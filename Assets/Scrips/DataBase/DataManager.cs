using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : BYSingletonMono<DataManager>
{
    public WeaponsData dataWeapon;
    public PlayerData InitData()
    {
        PlayerData playerData = new PlayerData();
        PlayerInfo info = new()
        {
            nickname = "Huy",
            level = 1,
            exp = 0
        };
        playerData.info = info;

        PlayerInventory inventory = new()
        {
            gold = 100,
            gem = 10,
            weaponData = dataWeapon,
        };
        playerData.inventory = inventory;

        PlayerMissionData missionData = new()
        {
            currentMission = 1
        };
        playerData.missionData = missionData;
        return playerData;
    }
}
