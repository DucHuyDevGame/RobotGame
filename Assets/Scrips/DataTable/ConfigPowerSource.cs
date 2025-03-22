using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum PowerSourceType
{
    PowerCore = 1,
    Battery = 2,
}

[Serializable]
public class ConfigPowerSourceRecord : ConfigRecordBase
{
    [SerializeField] PowerSourceType powerSourceType;
    public PowerSourceType PowerSourceType => powerSourceType;   
}
public class ConfigPowerSource : BYDataTable<ConfigPowerSourceRecord>
{
    public override ConfigCompare<ConfigPowerSourceRecord> DefindCompare()
    {
        configCompare = new ConfigCompare<ConfigPowerSourceRecord>("id");
        return configCompare;
    }
    public List<ConfigPowerSourceRecord> GetRecordBuyWeaponType(PowerSourceType ps_Type)
    {
        return records.Where(x => x.PowerSourceType == ps_Type).ToList();
    }
    public ConfigPowerSourceRecord GetRecordName(string name)
    {
        return records.Where(x => x.Name.Equals(name)).FirstOrDefault();
    }
}
