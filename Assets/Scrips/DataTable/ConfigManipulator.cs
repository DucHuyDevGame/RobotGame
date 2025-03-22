using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ManipulatorType
{
    Gripper = 1,
    Crane = 2,
}

[Serializable]
public class ConfigManipulatorRecord : ConfigRecordBase
{
    [SerializeField] ManipulatorType manipulatorType;
    public ManipulatorType ManipulatorType => manipulatorType;
}

public class ConfigManipulator : BYDataTable<ConfigManipulatorRecord>
{
    public override ConfigCompare<ConfigManipulatorRecord> DefindCompare()
    {
        configCompare = new ConfigCompare<ConfigManipulatorRecord>("id");
        return configCompare;
    }
    public List<ConfigManipulatorRecord> GetRecordBuyWeaponType(ManipulatorType ma_Type)
    {
        return records.Where(x => x.ManipulatorType == ma_Type).ToList();
    }
    public ConfigManipulatorRecord GetRecordName(string name)
    {
        return records.Where(x => x.Name.Equals(name)).FirstOrDefault();
    }
}
