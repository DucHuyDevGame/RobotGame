using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicMissionUIControl : MonoBehaviour
{
    public List<DicMisisonItemControl> items;
    void OnEnable()
    {
        DataTrigger.RegisterValueChange(DataSchema.DIC_MISSION, DicDataChange);
        DataTrigger.RegisterValueChange(DataSchema.MISSIONS, DicDataChange);
    }
    
    void OnDisable()
    {
        DataTrigger.UnRegisterValueChange(DataSchema.DIC_MISSION, DicDataChange);
        DataTrigger.UnRegisterValueChange(DataSchema.MISSIONS, DicDataChange);
    }
    void DicDataChange(object data)
    {
        Setup();
    }
    public void Setup()
    {
        List<MissionData> datas = DataController.Instance.GetMissionData();
        items[0].SetUp(datas[0], datas[0].missionComplete);
        for (int i = 1; i < items.Count; i++)
        {
            items[i].SetUp(datas[i], datas[i - 1].missionComplete);
        }
            
    }
}
