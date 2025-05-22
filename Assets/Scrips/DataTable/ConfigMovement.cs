using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Flags]
public enum MovementType
{
    None = 0,
    Wheels = 1 << 0,
    Tracks = 1 << 1,
    Legs = 1 << 2,
    All = ~0,
}


[Serializable]
public class ConfigMovementRecord : ConfigRecordBase
{
    [SerializeField] MovementType movementType;
    public MovementType MovementType => movementType;
}

public class ConfigMovement : BYDataTable<ConfigMovementRecord>
{
    public override ConfigCompare<ConfigMovementRecord> DefindCompare()
    {
        configCompare = new ConfigCompare<ConfigMovementRecord>("id");
        return configCompare;
    }
    //public List<ConfigMovementRecord> GetRecordBuyWeaponType(MovementType mv_Type)
    //{
    //    return records.Where(x => x.MovementType == mv_Type).ToList();
    //}
    public ConfigMovementRecord GetRecordName(string name)
    {
        return records.Where(x => x.Name.Equals(name)).FirstOrDefault();
    }
}
