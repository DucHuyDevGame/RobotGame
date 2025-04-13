using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseDialog : BaseDialog
{
    public override void OnShowDialog()
    {
        base.OnShowDialog();
        ViewManager.Instance.SwitchView(ViewIndex.EmptyView);
        Time.timeScale = 0;
    }
    public override void OnHideDialog()
    {
        base.OnHideDialog();
        Time.timeScale = 1;
    }
    public void ReturnIngame()
    {
        DialogManager.Instance.HideDialog(dialogIndex);
        LoadSceneManager.Instance.LoadSceneByName(GameManager.Instance.cur_cf_Level.SceneName, false,() =>
        {
            ViewManager.Instance.SwitchView(ViewIndex.IngameView);
        });
    }
}
