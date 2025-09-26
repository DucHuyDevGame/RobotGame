using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDialog : BaseDialog
{
    WinDialogParam dl_param;

    public override void OnShowDialog()
    {
        base.OnShowDialog();
        Time.timeScale = 0;
        ViewManager.Instance.SwitchView(ViewIndex.EmptyView);
    }
    public override void OnHideDialog()
    {
        base.OnHideDialog();
        Time.timeScale = 1;
    }
    public override void Setup(DialogParam param)
    {
        base.Setup(param);
        dl_param = (WinDialogParam)param;
    }
    public void OnClaim()
    {
        DialogManager.Instance.HideDialog(dialogIndex);
        ViewManager.Instance.SwitchView(ViewIndex.EmptyView);
        DataController.Instance.UpdateMissionData(dl_param.cf_level.ID, 3);
        if(dl_param.cf_level.ID == 5)
        {
            LoadSceneManager.Instance.LoadSceneByName("Buffer", false, (success) =>
            {
                if (success)
                    ViewManager.Instance.SwitchView(ViewIndex.HomeView);
            });
        }
        else
        {
            ConfigLevelRecord cf = ConfigManager.Instance.configLevel.GetRecordBykeySearch(dl_param.cf_level.ID + 1);
            GameManager.Instance.cur_cf_Level = cf;
            LoadSceneManager.Instance.LoadSceneByName(cf.SceneName, false, (success) =>
            {
                if (success)
                    ViewManager.Instance.SwitchView(ViewIndex.IngameView);
            });
        }
    }
}
