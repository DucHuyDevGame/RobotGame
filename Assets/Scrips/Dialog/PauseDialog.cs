using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseDialog : BaseDialog
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
    public void OnClose()
    {
        DialogManager.Instance.HideDialog(DialogIndex.PauseDialog);
    }
    public void OnQuit()
    {
        DialogManager.Instance.HideDialog(dialogIndex);
        LoadSceneManager.Instance.LoadSceneByName("Buffer", false ,(success) =>
        {
            if (success)
                ViewManager.Instance.SwitchView(ViewIndex.HomeView);
        });
    }
}
