using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum SensorsType
{
    Heat = 1,
    Sound = 2,
    Color = 3,
}

[Serializable]
public class ConfigSensorRecord : ConfigRecordBase
{
    [SerializeField] SensorsType sensorType;
    public SensorsType SensorType => sensorType;
}
public class ConfigSensor : BYDataTable<ConfigSensorRecord>
{
    public override ConfigCompare<ConfigSensorRecord> DefindCompare()
    {
        configCompare = new ConfigCompare<ConfigSensorRecord>("id");
        return configCompare;
    }
    public List<ConfigSensorRecord> GetRecordBuyWeaponType(SensorsType s_Type)
    {
        return records.Where(x => x.SensorType == s_Type).ToList();
    }
    public ConfigSensorRecord GetRecordName(string name)
    {
        return records.Where(x => x.Name.Equals(name)).FirstOrDefault();
    }
}
