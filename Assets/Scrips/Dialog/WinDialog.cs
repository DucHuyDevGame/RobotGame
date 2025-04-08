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
        LoadSceneManager.Instance.LoadSceneByName("Buffer", () =>
        {
            DataController.Instance.UpdateMissionData(dl_param.cf_level.ID, 3);
            ViewManager.Instance.SwitchView(ViewIndex.HomeView);
        });
    }
}
