using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CancelDialog : BaseDialog
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
    public void ReturnHome()
    {
        DialogManager.Instance.HideDialog(dialogIndex);
    }
}
