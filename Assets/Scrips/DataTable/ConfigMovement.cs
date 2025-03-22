using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum MovementType
{
    Wheels = 1,
    Tracks = 2,
    Legs = 3,
    JetPack = 4,
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
    public List<ConfigMovementRecord> GetRecordBuyWeaponType(MovementType mv_Type)
    {
        return records.Where(x => x.MovementType == mv_Type).ToList();
    }
    public ConfigMovementRecord GetRecordName(string name)
    {
        return records.Where(x => x.Name.Equals(name)).FirstOrDefault();
    }
}
