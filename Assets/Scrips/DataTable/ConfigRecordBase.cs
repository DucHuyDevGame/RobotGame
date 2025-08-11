using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConfigRecordBase
{
    [SerializeField] protected int id;
    public int ID => id;

    [SerializeField] protected string image;
    public string Image => image;

    [SerializeField] protected string name;
    public string Name => name;

    [SerializeField] protected string prefabImage;
    public string PrefabImage => prefabImage;

    [SerializeField] protected float sizeDeltaX;
    public float SizeDeltaX => sizeDeltaX;

    [SerializeField] protected float sizeDeltaY;
    public float SizeDeltaY => sizeDeltaY;
}
