using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnhancedUI.EnhancedScroller;
public class WeaponListData
{
    public ConfigRecordBase cf;
    public WeaponView weaponView;
}
public class WeaponViewGunList : MonoBehaviour, IEnhancedScrollerDelegate
{
    string typeConfig;
    public WeaponView weaponView;
    /// <summary>
    /// Internal representation of our data. Note that the scroller will never see
    /// this, so it separates the data from the layout using MVC principles.
    /// </summary>
    private List<WeaponListData> data_list;
    Dictionary<ConfigType, List<ConfigRecordBase>> configData = new Dictionary<ConfigType, List<ConfigRecordBase>>();

    /// <summary>
    /// This is our scroller we will be a delegate for
    /// </summary>
    public EnhancedScroller scroller;

    /// <summary>
    /// This will be the prefab of each cell in our scroller. Note that you can use more
    /// than one kind of cell, but this example just has the one type.
    /// </summary>
    public EnhancedScrollerCellView cellViewPrefab;
    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
    {
        // first, we get a cell from the scroller by passing a prefab.
        // if the scroller finds one it can recycle it will do so, otherwise
        // it will create a new cell.
        WeaponViewGunListItem cellView = scroller.GetCellView(cellViewPrefab) as WeaponViewGunListItem;

        // set the name of the game object to the cell's data index.
        // this is optional, but it helps up debug the objects in 
        // the scene hierarchy.
        cellView.name = $"Cell {dataIndex}";

        // in this example, we just pass the data to our cell's view which will update its UI
        cellView.SetDataCell(data_list[dataIndex],typeConfig);

        // return the cell to the scroller
        return cellView;
    }

    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        return 298;
    }

    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        return data_list.Count;
    }
    void Start()
    {
        scroller.Delegate = this;
    }
    void DelayJump()
    {
        scroller.RefreshActiveCellViews();
    }
    public void ButtonOne()
    {
        data_list = new List<WeaponListData>();
        typeConfig = "Movement";
        foreach (ConfigMovementRecord cf in ConfigManager.Instance.configMovement.records)
            data_list.Add(new WeaponListData { cf = cf, weaponView = weaponView });
        scroller.ReloadData();
        scroller.JumpToDataIndex(0);
        Invoke(nameof(DelayJump), 0.1f);
    }
    public void ButtonTwo()
    {
        data_list = new List<WeaponListData>();
        typeConfig = "Manipulator";
        foreach (ConfigManipulatorRecord cf in ConfigManager.Instance.configManipulator.records)
            data_list.Add(new WeaponListData { cf = cf, weaponView = weaponView });
        scroller.ReloadData();
        scroller.JumpToDataIndex(0);
        Invoke(nameof(DelayJump), 0.1f);
    }
    public void ButtonThrid()
    {
        data_list = new List<WeaponListData>();
        typeConfig = "Sensor";
        foreach (ConfigSensorRecord cf in ConfigManager.Instance.configSensor.records)
            data_list.Add(new WeaponListData { cf = cf, weaponView = weaponView });
        scroller.ReloadData();
        scroller.JumpToDataIndex(0);
        Invoke(nameof(DelayJump), 0.1f);
    }
    //public void SetUpConfig(ConfigType type)
    //{
    //    if (type == ConfigType.Movement)
    //        typeConfig = "Movement";
    //    else if (type == ConfigType.Manipulator)
    //        typeConfig = "Manipulator";
    //    else if (type == ConfigType.PowerSource)
    //        typeConfig = "PowerSource";
    //    else if (type == ConfigType.Sensor)
    //        typeConfig = "Sensor";
    //}
}
