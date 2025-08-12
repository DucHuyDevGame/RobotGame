using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiedDialog : BaseDialog
{
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
    public void ReturnGame()
    {
        DialogManager.Instance.HideDialog(dialogIndex);
        LoadSceneManager.Instance.LoadSceneByName(GameManager.Instance.cur_cf_Level.SceneName, false, (success) =>
        {
            if(success)
                ViewManager.Instance.SwitchView(ViewIndex.IngameView);
        });
    }
}
