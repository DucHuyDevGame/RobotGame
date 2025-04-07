using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageView : BaseView
{   
    public DicMissionUIControl dicMissionUIControl;
    public override void Setup(ViewParam param)
    {
        base.Setup(param);
        dicMissionUIControl.Setup();
    }
    public void OnBack()
    {
        ViewManager.Instance.SwitchView(ViewIndex.HomeView);
    }
    public void PlayGame(int id)
    {
        if (!dicMissionUIControl.items[id - 1].lockMission.activeSelf)
        {
            ConfigLevelRecord cf_level = ConfigManager.Instance.configLevel.GetRecordBykeySearch(id);
            GameManager.Instance.cur_cf_Level = cf_level;
            ViewManager.Instance.SwitchView(ViewIndex.EmptyView);
            LoadSceneManager.Instance.LoadSceneByName(cf_level.SceneName, () =>
            {
                ViewManager.Instance.SwitchView(ViewIndex.IngameView);
            });
        }
    }
}
